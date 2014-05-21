<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HeadderBlogin.ascx.cs"
    Inherits="UserControl_HeadderBlogin" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script src="assets/js/jquery.cookie.js" type="text/javascript"></script>

<script type="text/javascript">
        $(function() {
            var icon = '<link rel="shortcut icon" href="favicon.ico" type="image/x-icon">' +
            '<link rel="icon" href="favicon.ico" type="image/x-icon">';

            $('head').prepend(icon);
            
            
            $('#HeadderBlogin1_usedCarsLi, .footerBuyCar').live('click', function(){
                stopTimer();
                
                if($.cookie('userZip')){
                    $('.buyzip').val($.cookie('userZip'));
                    buySearch();
                }else{
                    $find('HeadderBlogin1_MdlBuyacar').show();
                }
                
                
            })
            
        })
        
        
        
        
     
</script>

<script type="text/javascript">
    function SendValidate()
	  {  
      
            var valid=true;  
            
              if (document.getElementById('<%=ddlmakesp.ClientID%>').value == "0") {
                alert('Please select make')
                valid = false;
                document.getElementById('ddlmakesp').focus();   
                return valid;
            }
            else   if (document.getElementById('<%=ddlmodelsp.ClientID%>').value == "0") {
                alert('Please select model')
                valid = false;
                document.getElementById('ddlmodelsp').focus();
                return valid;
            }
               else   if (document.getElementById('<%=ddlyearp.ClientID%>').value == "0") {
                alert('Please select year')
                valid = false;
                document.getElementById('ddlyearp').focus();
                return valid;
            }
            
            
            if (document.getElementById('<%= txtemail1.ClientID %>').value.length < 1)
             {
                alert("Please enter email address");
                document.getElementById('<%= txtemail1.ClientID %>').focus();
                valid = false;
            } 
                else if (document.getElementById('<%= txtemail1.ClientID %>').value.length < 1)
             {
                alert("Enter email address");
                document.getElementById('<%= txtemail1.ClientID %>').focus();
                valid = false;
            }    
            
             else if (echeck(document.getElementById('<%= txtemail1.ClientID %>').value)==false)
	        {
		        document.getElementById('<%= txtemail1.ClientID %>').value=""
		        document.getElementById('<%= txtemail1.ClientID %>').focus()
		        valid=false;
        		return valid;
	        }                     
            else if(document.getElementById("txtemail1").value.length<1 && echeck(document.getElementById("txtemail1").value)==false)
            {
                alert("Please enter the email address");               
                valid=false;
                document.getElementById("txtemail1").focus();
            } 
         
            return valid;
        } 
	function echeck(str) 
    {

		var at="@"
		var dot="."
		var lat=str.indexOf(at)
		var lstr=str.length
		var ldot=str.indexOf(dot)
		if (str.indexOf(at)==-1){
		   alert("Invalid E-mail ID")
		   return false
		}

		if (str.indexOf(at)==-1 || str.indexOf(at)==0 || str.indexOf(at)==lstr){
		   alert("Invalid E-mail ID")
		   return false
		}

		if (str.indexOf(dot)==-1 || str.indexOf(dot)==0 || str.indexOf(dot)==lstr){
		    alert("Invalid E-mail ID")
		    return false
		}

		 if (str.indexOf(at,(lat+1))!=-1){
		    alert("Invalid E-mail ID")
		    return false
		 }

		 if (str.substring(lat-1,lat)==dot || str.substring(lat+1,lat+2)==dot){
		    alert("Invalid E-mail ID")
		    return false
		 }

		 if (str.indexOf(dot,(lat+2))==-1){
		    alert("Invalid E-mail ID")
		    return false
		 }
		
		 if (str.indexOf(" ")!=-1){
		    alert("Invalid E-mail ID")
		    return false
		 }

 		 return true					
	}
	
	
	
	
	var subTimer;
	
	
	
	function alertCall(){
	    clearInterval(subTimer);
	    $find('HeadderBlogin1_mpesubscribe').show();
	}
	
	
	function stopTimer(){
	    clearInterval(subTimer);
	}
	
	
	function resetTimer(){

	    if($.cookie('PrefCookie') && $.cookie('PrefCookie') == 'Pref'){
	        subTimer = setInterval(function(){alertCall()},parseInt($.trim($('.HdnSubScribeValue').text())));	  
	    }
	  }
	
	$(function(){	
	   if($('#accountLi').length <= 0){
	        resetTimer();
	   }
	
	    	
	    
	    $('#subScribUs1 .cls').live('click', function(){
	        resetTimer();
	    })
	    
	})
	
	
	
	
     
</script>

<header id="header">

<asp:Label ID="HdnSubScribeValue" CssClass="HdnSubScribeValue"  runat="server"   style=" display:none " ></asp:Label>
	<div class="header-inner">
		<div class="container" >
			<div class="row">
				<div class="col-md-12 clearfix">
					<div class="brand">
						<div class="logo">
							<a href="default.aspx">
								<img src="assets/img/logo.png" alt="Carat HTML Template">
							</a>
						</div><!-- /.logo -->

						<div class="slogan">The best way to sell/buy a car in your local area and<br />
across the country using web, mobile & social media
</div><!-- /.slogan -->
					</div><!-- /.brand -->
					
					<button class="navbar-toggle" type="button" data-toggle="collapse" data-target=".navbar-collapse">
					    <span class="sr-only">Toggle navigation</span>
					    <span class="icon-bar"></span>
					    <span class="icon-bar"></span>
					    <span class="icon-bar"></span>
					</button>

					<nav class="collapse navbar-collapse navbar-collapse" role="navigation">
						<ul class="navigation">
						<li runat="server" id="homeLi"><a href="default.aspx">Home</a></li>				
						
						<li runat="server" id="usedCarsLi"><a href="javascript:void(0);">Buy A Car</a></li>
                        <li runat="server" id="newCarsLi"><a href="SellRegi.aspx">Sell A Car</a></li>
                         <li runat="server" id="Finaqnce"><a href="Finance.aspx">Finance</a></li>
                        
                        
						<%--<li class="menuparent has-regularmenu" runat="server" visible="false" id="sellLi" style="display:none;" > 
						    <a href="#">Sell A Car</a>
						    <div class="regularmenu">
								<ul class="regularmenu-inner">
									<li><a href="Packages.aspx">Private Seller</a></li>
									<li><a href="Dealer.aspx">Dealer</a></li>
								</ul><!-- /.regularmenu-inner -->
							</div>						
						</li>	--%>					
						<%--<li><a href="contact.html">Contact</a></li>--%>
						<li runat="server" visible="false" id="accountLi"><a href="Account.aspx" >My Account</a></li>
						<li runat="server" visible="false" id="reviewLi" style=" display:none; " ><a href="Reviews.aspx" >Reviews</a></li>
						<li runat="server" visible="false" id="loginLi" ><a href="login.aspx"><i class='icon icon-normal-turn-off'></i>Login</a></li>
						<li runat="server" visible="false" id="logoutLi"><asp:LinkButton ID="lnkBtnLogout" runat="server" CssClass="login" Text="<i class='icon icon-normal-turn-off'></i> Logout" OnClick="lnkBtnLogout_Click"></asp:LinkButton></li>
						
						
						
						
						</ul><!-- /.nav -->
					</nav>
				</div><!-- /.col-md-12 -->
			</div><!-- /.row -->
		</div><!-- /.container -->
	</div><!-- /.header-inner -->
</header>
<!-- /#header -->
<div class="infobar">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <ol class="breadcrumb pull-left">
                    <li><a href="#">Home</a></li>
                    <li><a href="#">Featured Cars</a></li>
                    <li class="active">Buy</li>
                </ol>
                <div class="contact pull-right">
                   <!-- /.phone -->
                    <div class="contact-item mail">
                        <div class="label">
                            <i class="icon icon-normal-mail"></i>
                        </div>
                        <!-- /.label -->
                        <div class="value">
                            <a href="mailto:example@example.com">info@mobicarz.com</a></div>
                        <!-- /.value -->
                    </div>
                    <div class="contact-item phone">
                        <div class="label">
                            <i class="icon icon-normal-mobile-phone"></i>
                        </div>
                        <!-- /.label -->
                        <div class="value">
                            888-465-6693 <small>(Mon - Fri : 9:00 AM - 5:00 PM)</small></div>
                        <!-- /.value -->
                    </div>
                 
                    <!-- /.mail -->
                    <div class="contact-item opening" style="display:none;">
                        <div class="label">
                            <i class="icon icon-normal-clock"></i>
                        </div>
                        <!-- /.label -->
                        <div class="value">
                            Mon - Fri: 9:00 AM - 5:00 PM</div>
                        <!-- /.value -->
                    </div>
                    <div class="contact-item opening">
                        <!-- /.label -->
                        <div class="value">
                            <asp:UpdatePanel ID="usub" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btnsubscr" runat="server" Text="Sign Up For Alerts" Style="margin-bottom: 2px;
                                        margin-left: 25px;" class="btn btn-danger  btn-xs " OnClick="btnsubscr_click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <!-- /.value -->
                    </div>
                    <!-- /.opening -->
                </div>
                <!-- /.contact -->
            </div>
            <!-- /.col-md-12 -->
        </div>
        <!-- /.row -->
    </div>
    <!-- /.container -->
</div>
<!-- /.infobar -->
<!----  Subscribe popup-------------->
<cc1:ModalPopupExtender ID="mpesubscribe" runat="server" PopupControlID="subScribUs1"
    BackgroundCssClass="ModalPopupBG" TargetControlID="hdnSubscribe" OkControlID="btnsubScribUs">
</cc1:ModalPopupExtender>
<asp:HiddenField ID="hdnSubscribe" runat="server" />
<div id="subScribUs1" class="alert" style="height: auto; padding-bottom: 15px; max-width: 550px;
    width: 70%; display: none;">
    <h4 id="">
        Sign up to receive email alerts.
        <asp:LinkButton ID="btnsubScribUs" runat="server" class="cls" Text="" Style="border-width: 0px;"></asp:LinkButton>
    </h4>
    <div class="data">
        <div class="row" style="color: #333;">
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                Any time if we see a car that matches your interest. Our automated robo system will keep you updated with emails.
                <br />
            </div>
        
            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                <div class="title">
                    <h3>
                        My Preference</h3>
                </div>
                <div class="form-section">
                    <div class="form-group " id="delearBox" runat="server">
                        <label>
                            Make <span class="star">*</span></label>
                        <asp:UpdatePanel ID="m1" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlmakesp" class="form-control" runat="server" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlmakesp_SelectedIndexChanged1">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="form-group ">
                        <label>
                            Model <span class="star">*</span></label>
                        <asp:UpdatePanel ID="mpu2" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlmodelsp" class="form-control" runat="server" AutoPostBack="true"
                                    Enabled="false">
                                    <asp:ListItem>Select</asp:ListItem>
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="form-group ">
                        <label>
                            Year <span class="star">*</span></label>
                        <asp:UpdatePanel ID="upyeas" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlyearp" class="form-control" runat="server">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                <div class="title">
                    <h3>
                        Personal Info</h3>
                </div>
                <div class="form-section">
                    <asp:UpdatePanel ID="u1" runat="server">
                        <ContentTemplate>
                            <div class="form-group " id="Div1" runat="server">
                                <label>
                                    First Name</label>
                                <asp:TextBox ID="txtfnamep" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group ">
                                <label>
                                    Last Name
                                </label>
                                <asp:TextBox ID="txtlastnamep" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group ">
                                <label>
                                    Email <span class="star">*</span></label>
                                <asp:TextBox ID="txtemail1" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div style="text-align: right; margin: 10px 0;">
            <div style="float: right; width: 80px;">
                <asp:UpdatePanel ID="Supbtn" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnSubok" runat="server" Text="Submit" class="btn btn-primary2 "
                            OnClientClick="return SendValidate();" OnClick="btnSubok_click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            &nbsp; &nbsp;
            <div style="float: right; width: 80px;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btncancelp" runat="server" Text="Cancel" class="btn btn-default "
                            OnClick="btncancelp_click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</div>


<!---- ------------------ Buy a cra Prompt page ---------------------------------->

<cc1:ModalPopupExtender ID="MdlBuyacar" runat="server" PopupControlID="Buyacarpopup"
    BackgroundCssClass="ModalPopupBG" TargetControlID="hdnBuyacar" OkControlID="btnBuyScribUs">
</cc1:ModalPopupExtender>
<asp:HiddenField ID="hdnBuyacar" runat="server" />
<div id="Buyacarpopup" class="alert" style="height: auto; padding-bottom: 15px; max-width: 550px;
    width: 70%; display: none;">
    <h4 id="H1">
        Buy a Car
        <asp:LinkButton ID="btnBuyScribUs" OnClick="btncancelpopclick_click" runat="server" class="cls" Text="" Style="border-width: 0px;"></asp:LinkButton>
    </h4>
    <div class="data">
        <div class="row" style="color: #333;">
            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                
                <div class="form-section">
                    <div class="form-group " id="Div3" runat="server">
                        <label>
                            ZIP <span class="star">*</span></label>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>                               
                                
                                <asp:TextBox ID="buyzip" MaxLength="5" CssClass="form-control buyzip sample4" runat="server"></asp:TextBox>
                                
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                  
                </div>
            </div>
           
        </div>
        <div style="text-align: right; margin: 10px 0;">
            <div style="float: right; width: 80px;">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="Button1" runat="server" Text="Submit" class="btn btn-primary2 "
                            OnClientClick="return buySearch();" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            &nbsp; &nbsp;
            <div style="float: right; width: 80px;">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btncancelpopclick" runat="server" Text="Cancel" class="btn btn-default "
                            OnClick="btncancelpopclick_click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</div>