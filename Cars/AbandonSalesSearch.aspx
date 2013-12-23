<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AbandonSalesSearch.aspx.cs"
    Inherits="AbandonSalesSearch" %>

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

    <script type="text/javascript" language="javascript">
    // Key Event  Start 
        KeyListener = {
        init : function() {
            $('.searchFormHolder2').bind('keypress', function(e) {
                var key = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
                var target = e.target.tagName.toLowerCase();
                if (key === 13 && target === 'input') {
                    e.preventDefault();
                    var button = $('#btnSearchCarID');
                    if (button.length > 0) {
                        if (typeof(button.get(0).onclick) == 'function') {
                            button.trigger('click');
                        }else if (button.attr('href')) {
                            window.location = button.attr('href');
                        }else {
                            button.trigger('click');
                        }
                    }
                   
                }               

            });
        }
    };
    
    KeyListener2 = {
        init : function() {
            $('.searchFormHolder1').bind('keypress', function(e) {
                var key = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
                var target = e.target.tagName.toLowerCase();
                if (key === 13 && target === 'input') {
                    e.preventDefault();
                    var button = $('#btnSearch');
                    if (button.length > 0) {
                        if (typeof(button.get(0).onclick) == 'function') {
                            button.trigger('click');
                        }else if (button.attr('href')) {
                            window.location = button.attr('href');
                        }else {
                            button.trigger('click');
                        }
                    }
                   
                }               

            });
        }
    };
     // Key Event End 
    
        function ValidateVehicleType()
        {
         
            var valid=true;                
//              if (document.getElementById('<%=ddlPackage.ClientID%>').value =="0")
//            {
//                alert('Please select package')
//                valid=false;
//                document.getElementById('ddlPackage').focus();  
//                return valid;
//            }
            
             if( (document.getElementById('<%=txtPhoneNumber.ClientID%>').value.length > 0 ) && (document.getElementById('<%=txtPhoneNumber.ClientID%>').value.length < 10))
             {
                document.getElementById('<%= txtPhoneNumber.ClientID%>').focus();
                alert("Please enter valid phone number");
                 document.getElementById('<%=txtPhoneNumber.ClientID%>').value = ""
                document.getElementById('<%=txtPhoneNumber.ClientID%>').focus()
                valid = false; 
                 return valid;              
             } 
             else if ((document.getElementById('<%=txtEmail.ClientID%>').value.length > 0) && (echeck(document.getElementById('<%=txtEmail.ClientID%>').value) == false) )
             {               
                document.getElementById('<%=txtEmail.ClientID%>').value = ""
                document.getElementById('<%=txtEmail.ClientID%>').focus()
                valid = false;               
           
            }             
            
        
          }    
          
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
            $('#spinner').show();
        }
        function  hideSpinner(){
            $('#spinner').hide();
        } 
    </script>

</head>
<body>
    <form id="Form1" runat="server">
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
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updtPnlSearch"
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
    <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanelBtnSearchCarID"
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
    <div class="headder">
        <uc1:LoginName ID="LoginName1" runat="server" />
        <div class="clear">
            &nbsp;</div>
    </div>
    <div class="main">
        <h1 class="h1">
            Abandon Sales Data</h1>
        <div class="clear">
            &nbsp;</div>
        <table>
            <tr>
                <td style="width: 65%; vertical-align: top;">
                    <div class="searchFormHolder1">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            Phone Number<br />
                                            <asp:TextBox ID="txtPhoneNumber" Width="150px" CssClass="input2 number" MaxLength="10"
                                                runat="server" TabIndex="0"></asp:TextBox>
                                            <%-- <input type="text" class="input2 number" style="width: 150px;" />--%>
                                        </td>
                                        <td>
                                            Customer Name<br />
                                            <asp:TextBox ID="txtCustName" Width="150px" CssClass="input2" MaxLength="30" runat="server"></asp:TextBox>
                                            <%-- <input type="text" class="input2" style="width: 200px;" />--%>
                                        </td>
                                        <td>
                                            Email<br />
                                            <asp:TextBox ID="txtEmail" Width="150px" CssClass="input2" MaxLength="50" runat="server"></asp:TextBox>
                                            <%--<input type="text" class="input2" style="width: 150px;" />--%>
                                        </td>
                                        <td>
                                            Agent Name<br />
                                            <asp:TextBox ID="txtAgentName" Width="150px" CssClass="input2" MaxLength="30" runat="server"></asp:TextBox>
                                            <%--<input type="text" class="input2" style="width: 150px;" />--%>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="clear" style="height: 0px;">
                            &nbsp;</div>
                        <table>
                            <tr>
                                <td>
                                    Make<br />
                                    <asp:UpdatePanel ID="updtMake" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlMake" runat="server" OnSelectedIndexChanged="ddlMake_SelectedIndexChanged"
                                                AutoPostBack="true" Width="150px" CssClass="input1">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <%--<select class="input1" style="width: 150px;">
                        <option>Select make</option>
                    </select>--%>
                                </td>
                                <td>
                                    Model<br />
                                    <asp:UpdatePanel ID="updtpnlModel" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlModel" runat="server" Width="150px" CssClass="input1">
                                                <asp:ListItem Value="0">All Models</asp:ListItem>
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <%--  <select class="input1" style="width: 150px;">
                        <option>Select model</option>
                    </select>--%>
                                </td>
                                <td>
                                    Year<br />
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlYear" runat="server" Width="150px" CssClass="input1">
                                                <asp:ListItem Value="0">Any Year</asp:ListItem>
                                                <asp:ListItem Value="2013">2013</asp:ListItem>
                                                <asp:ListItem Value="2012">2012</asp:ListItem>
                                                <asp:ListItem Value="2011">2011</asp:ListItem>
                                                <asp:ListItem Value="2010">2010</asp:ListItem>
                                                <asp:ListItem Value="2009">2009</asp:ListItem>
                                                <asp:ListItem Value="2008">2008</asp:ListItem>
                                                <asp:ListItem Value="2007">2007</asp:ListItem>
                                                <asp:ListItem Value="2006">2006</asp:ListItem>
                                                <asp:ListItem Value="2005">2005</asp:ListItem>
                                                <asp:ListItem Value="2004">2004</asp:ListItem>
                                                <asp:ListItem Value="2003">2003</asp:ListItem>
                                                <asp:ListItem Value="2002">2002</asp:ListItem>
                                                <asp:ListItem Value="2001">2001</asp:ListItem>
                                                <asp:ListItem Value="2000">2000</asp:ListItem>
                                                <asp:ListItem Value="1999">1999</asp:ListItem>
                                                <asp:ListItem Value="1998">1998</asp:ListItem>
                                                <asp:ListItem Value="1997">1997</asp:ListItem>
                                                <asp:ListItem Value="1996">1996</asp:ListItem>
                                                <asp:ListItem Value="1995">1995</asp:ListItem>
                                                <asp:ListItem Value="1994">1994</asp:ListItem>
                                                <asp:ListItem Value="1993">1993</asp:ListItem>
                                                <asp:ListItem Value="1992">1992</asp:ListItem>
                                                <asp:ListItem Value="1991">1991</asp:ListItem>
                                                <asp:ListItem Value="1990">1990</asp:ListItem>
                                                <asp:ListItem Value="1989">1989</asp:ListItem>
                                                <asp:ListItem Value="1988">1988</asp:ListItem>
                                                <asp:ListItem Value="1987">1987</asp:ListItem>
                                                <asp:ListItem Value="1986">1986</asp:ListItem>
                                                <asp:ListItem Value="1985">1985</asp:ListItem>
                                                <asp:ListItem Value="1984">1984</asp:ListItem>
                                                <asp:ListItem Value="1983">1983</asp:ListItem>
                                                <asp:ListItem Value="1982">1982</asp:ListItem>
                                                <asp:ListItem Value="1981">1981</asp:ListItem>
                                                <asp:ListItem Value="1980">1980</asp:ListItem>
                                                <asp:ListItem Value="1979">1979</asp:ListItem>
                                                <asp:ListItem Value="1978">1978</asp:ListItem>
                                                <asp:ListItem Value="1977">1977</asp:ListItem>
                                                <asp:ListItem Value="1976">1976</asp:ListItem>
                                                <asp:ListItem Value="1975">1975</asp:ListItem>
                                                <asp:ListItem Value="1974">1974</asp:ListItem>
                                                <asp:ListItem Value="1973">1973</asp:ListItem>
                                                <asp:ListItem Value="1972">1972</asp:ListItem>
                                                <asp:ListItem Value="1971">1971</asp:ListItem>
                                                <asp:ListItem Value="1970">1970</asp:ListItem>
                                                <asp:ListItem Value="1969">1969</asp:ListItem>
                                                <asp:ListItem Value="1968">1968</asp:ListItem>
                                                <asp:ListItem Value="1967">1967</asp:ListItem>
                                                <asp:ListItem Value="1966">1966</asp:ListItem>
                                                <asp:ListItem Value="1965">1965</asp:ListItem>
                                                <asp:ListItem Value="1964">1964</asp:ListItem>
                                                <asp:ListItem Value="1963">1963</asp:ListItem>
                                                <asp:ListItem Value="1962">1962</asp:ListItem>
                                                <asp:ListItem Value="1961">1961</asp:ListItem>
                                                <asp:ListItem Value="1960">1960</asp:ListItem>
                                                <asp:ListItem Value="1959">1959</asp:ListItem>
                                                <asp:ListItem Value="1958">1958</asp:ListItem>
                                                <asp:ListItem Value="1957">1957</asp:ListItem>
                                                <asp:ListItem Value="1956">1956</asp:ListItem>
                                                <asp:ListItem Value="1955">1955</asp:ListItem>
                                                <asp:ListItem Value="1954">1954</asp:ListItem>
                                                <asp:ListItem Value="1953">1953</asp:ListItem>
                                                <asp:ListItem Value="1952">1952</asp:ListItem>
                                                <asp:ListItem Value="1951">1951</asp:ListItem>
                                                <asp:ListItem Value="1950">1950</asp:ListItem>
                                                <asp:ListItem Value="1949">1949</asp:ListItem>
                                                <asp:ListItem Value="1948">1948</asp:ListItem>
                                                <asp:ListItem Value="1947">1947</asp:ListItem>
                                                <asp:ListItem Value="1946">1946</asp:ListItem>
                                                <asp:ListItem Value="1945">1945</asp:ListItem>
                                                <asp:ListItem Value="1944">1944</asp:ListItem>
                                                <asp:ListItem Value="1943">1943</asp:ListItem>
                                                <asp:ListItem Value="1942">1942</asp:ListItem>
                                                <asp:ListItem Value="1941">1941</asp:ListItem>
                                                <asp:ListItem Value="1940">1940</asp:ListItem>
                                                <asp:ListItem Value="1939">1939</asp:ListItem>
                                                <asp:ListItem Value="1938">1938</asp:ListItem>
                                                <asp:ListItem Value="1937">1937</asp:ListItem>
                                                <asp:ListItem Value="1936">1936</asp:ListItem>
                                                <asp:ListItem Value="1935">1935</asp:ListItem>
                                                <asp:ListItem Value="1934">1934</asp:ListItem>
                                                <asp:ListItem Value="1933">1933</asp:ListItem>
                                                <asp:ListItem Value="1932">1932</asp:ListItem>
                                                <asp:ListItem Value="1931">1931</asp:ListItem>
                                                <asp:ListItem Value="1930">1930</asp:ListItem>
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <%--<select class="input1" style="width: 150px;">
                        <option>Select year</option>
                    </select>--%>
                                </td>
                                <td>
                                    Package<br />
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlPackage" runat="server" Width="150px" CssClass="input1">
                                                <asp:ListItem Value="0">All Packages</asp:ListItem>
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <%--  <select class="input1" style="width: 150px;">
                        <option>Select package</option>
                    </select>--%>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:UpdatePanel ID="updtPnlSearch" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="g-button g-button-submit"
                                                OnClientClick="return ValidateVehicleType();" OnClick="btnSearch_Click" />
                                            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="g-button g-button-submit"
                                                OnClick="btnClear_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <%-- <input type="button" value="Search" class="g-button g-button-submit" />
                    <input type="button" value="Clear" class="g-button g-button-submit" />--%>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td style="width: 15px;">
                    &nbsp;
                </td>
                <td style="width: 20px; border-left: 1px solid #ccc">
                    &nbsp;
                </td>
                <td style="vertical-align: top">
                    <div class="searchFormHolder2">
                        Car ID<br />
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtCarID" runat="server" CssClass="input2 number" Width="200px"
                                    MaxLength="10"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--<input type="text" class="input2" style="width: 200px;" />--%><br />
                        <%--<input type="button" value="Search" class="g-button g-button-submit" />--%>
                        <asp:UpdatePanel ID="UpdatePanelBtnSearchCarID" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnSearchCarID" runat="server" Text="Search" CssClass="g-button g-button-submit"
                                    OnClick="btnSearchCarID_Click" OnClientClick="return ValidateVehicleType1();" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
            </tr>
        </table>
        <div class="clear" style="height: 20px; margin-top: 10px; border-top: 2px dotted #ccc;">
            &nbsp;</div>
        <table style="width: 100%;">
            <tr>
                <td style="vertical-align: top;">
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
                                        top: 2px; padding-top: 2px; width: 1188px; background: #fff;">
                                        <tr class="tbHed">
                                            <td width="60" align="left">
                                                <asp:LinkButton ID="lnkCarIDSort" runat="server" Text="Car ID &darr; &uarr;" OnClick="lnkCarIDSort_Click"></asp:LinkButton>
                                                <%--Car ID--%>
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
                                                <asp:LinkButton ID="lnkPhoneSort" runat="server" Text="Phone &darr; &uarr;" OnClick="lnkPhoneSort_Click"></asp:LinkButton>
                                            </td>
                                            <td width="180" align="left">
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
                        <div style="width: 1210px; overflow-y: scroll; overflow-x: hidden; padding: 26px 3px 3px 3px;
                            border: #ccc 1px solid; height: 180px">
                            <asp:Panel ID="pnl1" Width="100%" runat="server">
                                <asp:UpdatePanel ID="UpdPnlGrid" runat="server">
                                    <ContentTemplate>
                                        <input style="width: 91px" id="txthdnSortOrder" type="hidden" runat="server" enableviewstate="true" />
                                        <input style="width: 40px" id="txthdnSortColumnId" type="hidden" runat="server" enableviewstate="true" />
                                        <asp:GridView Width="1188px" ID="grdIntroInfo" runat="server" CellSpacing="0" CellPadding="0"
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
                                                        <%--<asp:LinkButton ID="lnkCarID" runat="server" Text='<%# Eval("carid")%>' CommandArgument='<%# Eval("postingID")%>'
                                                            CommandName="EditCar"></asp:LinkButton>--%>
                                                        <asp:Label ID="lblCarID" runat="server" Text='<%# Eval("carid")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="60px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%--<asp:Label ID="lblStatus" runat="server" ></asp:Label>--%>
                                                        <asp:Image ID="ImgStatus" runat="server" />
                                                        <asp:HiddenField ID="hdnStatus" runat="server" Value='<%# Eval("isActive")%>' />
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
                                                        <asp:Label ID="lblAgent" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(objGeneralFunc.ToProper(DataBinder.Eval(Container.DataItem,"ReferCode")),10) %>'></asp:Label>
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
                                                        <%-- <asp:LinkButton ID="lnkbtnName" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"Name"),15)%>'
                                                            CommandArgument='<%# Eval("UId")%>' CommandName="EditCustomer"></asp:LinkButton>--%>
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
                                                        <asp:Label ID="lblEmail" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"email"),25)%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="180px" />
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPmnt" runat="server" Text='<%# Eval("CustomerEmail")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="40px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("StatusName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="45px" />
                                                </asp:TemplateField>--%>
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
</html>
