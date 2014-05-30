<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MultiSiteBulkUploads.aspx.cs"
    Inherits="MultiSiteBulkUploads" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
    
      
      
    </script>

    <script type="text/javascript" language="javascript">    
         
         function validationDataFirst()
        {
        debugger
                         
            if(document.getElementById("<%=txtMultiSiteBulkUpload.ClientID%>").value.length<1)
            {                    
            alert("Please enter data");
            document.getElementById("<%=txtMultiSiteBulkUpload.ClientID%>").focus();
            valid=false;
            return valid;
            } 
            
             if(document.getElementById("<%=ddlBrandName.ClientID%>")!=null)
             {
                if(document.getElementById("<%=ddlBrandName.ClientID%>").value=="0")
                {                    
                alert("Please select brand ");
                document.getElementById("<%=ddlBrandName.ClientID%>").focus();
                valid=false;
                return valid;
                } 
            }
            var Lines = document.getElementById("<%=txtMultiSiteBulkUpload.ClientID%>").value
            var ctrlLines=Lines.split('\n');                    
            if (ctrlLines.length>100)
            {
            alert('More than 100 lines not allowed for save');                     
            valid=false;
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
    <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="updtpnlSave"
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
            Bulk Upload of multi-site Listings</h1>
        <div class="clear">
            &nbsp;</div>
        <table width="100%">
            <tr>
                <td align="right" style="padding-right: 15px;">
                    <div align="right" style="float: left">
                        <asp:Label ID="lblRedirectBy" runat="server"></asp:Label>
                        
                        &nbsp; <asp:Label ID="lblBrand" runat="server" style="font-weight:bold;"></asp:Label><asp:DropDownList ID="ddlBrandName" runat="server"></asp:DropDownList>
                        
                    </div>
                    <div>
                        Max 100 records at a time
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    Ex:1902 http://www.justsonatacars.com/search_results_large.php?alldetails=726685985
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtMultiSiteBulkUpload" runat="server" CssClass="textarea" TextMode="MultiLine"
                        MaxLength="5000" Style="height: 400px;"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right: 15px;">
                    <asp:UpdatePanel ID="updtpnlSave" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="g-button g-button-submit"
                                OnClick="btnSave_Click" OnClientClick="return validationDataFirst();" />
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

<script type="text/javascript" language="javascript">     
    $(window).load(function(){    
        $('#spinner1').hide();
    });
</script>

</html>
