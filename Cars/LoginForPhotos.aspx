<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginForPhotos.aspx.cs" Inherits="LoginForPhotos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>..:: United Car Exchange ::..</title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link href="Static/Css/Smartzstyle.css" rel="stylesheet" type="text/css" />
    <link href="Static/Css/menu.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">window.history.forward(1);</script>

    <script type="text/javascript" language="javascript" src="js/jquery-1.7.min.js"></script>

    <script type="text/javascript" language="javascript" src="js/sliding_effect.js"></script>

    <script type="text/javascript" language="javascript">
      
      function ValidateDetails()
        {
        debugger
            var valid=true;
     
             if (document.getElementById("txtUserName").value=="")
            {
                alert('Please enter username')
                valid=false;
                document.getElementById('txtUserName').focus();  
               if(document.getElementById('lblError') != null)
                {
                document.getElementById('lblError').outerText = "";    
                }
                             
                
            }
             
           else if(document.getElementById("txtPassword").value=="")
            {
                alert("Please enter password"); 
                valid=false;
                document.getElementById('txtPassword').focus();  
              if(document.getElementById('lblError') != null)
                {
                document.getElementById('lblError').outerText = "";    
                } 
            }    
            return valid;
        }

    </script>

</head>
<body>
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="SM" runat="server">
    </asp:ScriptManager>
    <div class="headder">
        <table style="width: 100%">
            <td style="width: 250px;">
                <a href="#">
                    <img src="Static/Images/logo2b.png" /></a>
            </td>
            <td>
                <h1 class="h11">
                    Smartz Customer Service System</h1>
            </td>
            <td style="width: 250px;">
                <div class="loginStat">
                    <%--  <a href="#">Login</a></div>--%>
            </td>
        </table>
        <div class="clear">
            &nbsp;</div>
    </div>
    <div class="main">
        <div class="clear">
            &nbsp;</div>
        <div style="margin: 60px auto; padding: 70px 0 0 60px; background: url(static/images/loginBack1.jpg);
            width: 388px; height: 135px">
            <table style="width: 100%;" cellspacing="0" cellpadding="0" border="0">
                <tr id="methodOfContactEmail">
                    <td style="width: 120px; vertical-align: top; line-height: 30px">
                        User Name
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtUserName" runat="server" MaxLength="50" CssClass="input1" Width="200px"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--<input value="" name="contactEmail" maxlength="150" type="text" class="input1" style="width: 200px" />--%>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr id="methodOfContactConfirmEmail">
                    <td style="vertical-align: top; line-height: 30px">
                        Password
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtPassword" runat="server" MaxLength="30" CssClass="input1" Width="200px"
                                    TextMode="Password"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%-- <input value="" name="confirmContactEmail" maxlength="150" type="text" class="input1"
                            style="width: 200px" />--%>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td style="padding-top: 5px;">
                        <asp:Button ID="btnLogin" runat="server" CssClass="g-button g-button-submit" Text="Login"
                            OnClick="btnLogin_Click" OnClientClick="return ValidateDetails();" />
                        <%--<input type="button" class="g-button g-button-submit" value="Login" />--%>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="2">
                        <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
            &nbsp;</div>
        <br />
    </div>
    <%--  <div class="footer">
        United Car Exchange © 2012</div>--%>
    </form>
</body>
</html>
