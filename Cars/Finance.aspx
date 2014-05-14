<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Finance.aspx.cs" Inherits="Finance"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Src="UserControl/HeadderBlogin.ascx" TagName="HeadderBlogin" TagPrefix="uc2" %>
<!doctype html>
<html>
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta name="description" content="">
    <meta name="keywords" content="">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" type="text/css" href="assets/css/bootstrap.min.css" media="screen, projection">
    <link rel="stylesheet" type="text/css" href="libraries/pictopro-outline/pictopro-outline.css"
        media="screen, projection">
    <link rel="stylesheet" type="text/css" href="libraries/pictopro-normal/pictopro-normal.css"
        media="screen, projection">
    <link rel="stylesheet" type="text/css" href="libraries/colorbox/colorbox.css" media="screen, projection">
    <link rel="stylesheet" type="text/css" href="js/jslider/jquery.slider.min.css" media="screen, projection">
    <link href="js/jslider/jquery.slider.min.css" rel="stylesheet" type="text/css" media="screen, projection" />
    <link rel="stylesheet" type="text/css" href="assets/css/carat.css" media="screen, projection">
    <link href="http://fonts.googleapis.com/css?family=Source+Sans+Pro:100,400,700,400italic,700italic"
        rel="stylesheet" type="text/css" media="screen, projection">
         <link href="Static/Css/calender.css" rel="stylesheet" type="text/css" />
    <title>MobiCarz</title>

    <script src="assets/js/jquery.js"></script>

    <script src="assets/js/jquery-migrate-1.2.1.js"></script>

    <script src="assets/js/jquery.ui.js"></script>

    <script src="assets/js/bootstrap.js"></script>

    <script src="assets/js/cycle.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    <uc2:HeadderBlogin ID="HeadderBlogin1" runat="server" />
    <div id="page-heading">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="heading">
                        <div class="title">
                            <h1>
                                Finance Options</h1>
                        </div>
                        <!-- /.title -->
                    </div>
                    <!-- /.heading -->
                </div>
                <!-- /.col-md-8 -->
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container -->
    </div>
    <!-- /#page-heading -->
    <div id="content" class="page-about">
        <div class="section gray-light">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="row">
                            <div class="article">
                                <div class="col-xs-12 col-sm-12 col-md-8">
                                    <div class="description">
                                        <p>
                                            No matter what situation you are in, financing a used vehicle is aroad we must all
                                            cross at some point in our lives. Whether you have good credit, bad credit, or none
                                            at all, you're just a click away from getting into your new ride! We at MobiCarz
                                            provide you various Financing options as listed below:
                                        </p>
                                    </div>
                                    <p>
                                        &nbsp;</p>
                                    <div class="row description">
                                        <div class="col-sm-12 col-md-3">
                                            <div class="picture">
                                                <img src="imagesOld/Second.jpg" style="float: left; margin: 5px 10px 0 0">
                                            </div>
                                        </div>
                                        <div class="col-sm-12 col-md-9">
                                            <h3>
                                                <a href="http://www.secondcarloans.com" target="_blank">www.secondcarloans.com</a>
                                            </h3>
                                            <p>
                                                We Specialize in used car loans Travel in the luxury of a car of your own and make
                                                your dream car a reality. Even if you have a history of bad credit, no credit, bankruptcy
                                                or repossession, we can get you financed for your used car.</p>
                                        </div>
                                    </div>
                                    <div class="row description">
                                        <div class="col-sm-12 col-md-3">
                                            <div class="picture">
                                                <img src="imagesOld/NationWideAutoLending_Logo.jpg">
                                            </div>
                                        </div>
                                        <div class="col-sm-12 col-md-9">
                                            <h3>
                                                <a href="http://www.nationwideautolending.com" target="_blank">www.nationwideautolending.com</a></h3>
                                            <p>
                                                You can get pre-approved for a new or used auto loan online with our free auto loan
                                                application. We specialize in bad credit auto loans and bad credit auto financing
                                                in all 50 states with our local auto finance credit centers.</p>
                                        </div>
                                    </div>
                                    <div class="row description">
                                        <div class="col-sm-12 col-md-3">
                                            <div class="picture">
                                                <img src="imagesOld/RoadLoans.gif" style="float: left; margin: 0 10px 0 0">
                                            </div>
                                        </div>
                                        <div class="col-sm-12 col-md-9">
                                            <h3>
                                                <a href="http://www.roadloans.com" target="_blank">www.roadloans.com</a>
                                            </h3>
                                            <p>
                                                RoadLoans is the internet auto lending division of Santander Consumer USA Inc. We
                                                specialize in financing and servicing new and used auto loans for customers with
                                                less than perfect credit.</p>
                                        </div>
                                    </div>
                                    <div class="row description">
                                        <div class="col-sm-12 col-md-3">
                                            <div class="picture">
                                                <img src="imagesOld/AutoLoan.jpg" style="float: left; margin: 5px 10px 0 0">
                                            </div>
                                        </div>
                                        <div class="col-sm-12 col-md-9">
                                            <h3>
                                                <a href="http://www.autoloanlocator.com" target="_blank">www.autoloanlocator.com</a>
                                            </h3>
                                            <p>
                                                What sets Auto Loan Locator apart from other online prime and sub prime lending
                                                locator companies offering similar services is our customer service. We are committed
                                                to building AAA auto loan lender relationships by understanding our customers’ needs
                                                and striving to deliver solutions to meet those needs.</p>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xs-12 col-sm-12 col-md-4 ">
                                    <div class="block-inner white block-shadow sidebar">
                                        <div class="block-title" style="border-bottom: 1px solid #D9D9D9; margin-bottom: 15px;">
                                            <h2 style="margin: 0 0 15px 0; font-size: 24px;">
                                                Apply For Loan</h2>
                                        </div>
                                        <!-- Form Start  -->
                                        <div class="row">
                                            <div class="col-xs-12 col-sm-6 col-md-12 col-lg-12">
                                                <h4 style="margin: 5px 0; padding: 5px 0; font-size: 19px; color: #003e55l">
                                                    Buyer's Information</h4>
                                                <div class="form-section">
                                                    <div class="form-group ">
                                                        <label>
                                                            First Name <span class="star">*</span></label>
                                                        <asp:TextBox ID="txt_Fname" TabIndex="1" class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>
                                                            Last Name <span class="star">*</span></label>
                                                        <asp:TextBox MaxLength="20" ID="txt_LName" TabIndex="2" class="form-control"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>
                                                            Email Address <span class="star">*</span></label>
                                                        <asp:TextBox ID="txt_email" TabIndex="3" class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>
                                                            Primary Phone <span class="star">*</span></label>
                                                        <asp:TextBox ID="txt_prim1" TabIndex="4" class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label style="display:block;" >
                                                            Date of Birth <span class="star">*</span></label>
                                                             <asp:TextBox ID="txtStartDate" runat="server" class="input1 form-control" MaxLength="10" onkeypress="return isNumberKeyForDt(event)"
                                                         style="width:150px; display:inline-block "></asp:TextBox>&nbsp;
                                                        
                                                        
                                                        
                                                    <img id="imgcal" runat="server" style="border-right: 0px; border-top: 0px; border-left: 0px;
                                                        border-bottom: 0px" title="Calendar Control" onclick="displayCalendar(document.forms[0].txtStartDate,'mm/dd/yyyy',this);"
                                                        alt="Calendar Control" src="images/Calender.gif" width="18" />
                                                        
                                                             <asp:TextBox ID="txtEndDate" runat="server" class="input1 " MaxLength="10" onkeypress="return isNumberKeyForDt(event)"
                                                        Width="70px" Visible="false"></asp:TextBox>&nbsp;
                                                    <img id="img1" visible="false" runat="server" style="border-right: 0px; border-top: 0px; border-left: 0px;
                                                        border-bottom: 0px" title="Calendar Control" onclick="displayCalendar(document.forms[0].txtStartDate,'mm/dd/yyyy',this);"
                                                        alt="Calendar Control" src="images/Calender.gif" width="18" />
                                                            
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-xs-12 col-sm-6 col-md-12 col-lg-12">
                                                <h4 style="margin: 5px 0; padding: 5px 0; font-size: 19px; color: ##003e55">
                                                    Residential Information</h4>
                                                <div class="form-section">
                                                    <div class="form-group ">
                                                        <label>
                                                            Street Address<span class="star">*</span></label>
                                                        <asp:TextBox ID="StrAdd" TabIndex="13" class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>
                                                            City <span class="star">*</span></label>
                                                        <asp:TextBox ID="City" TabIndex="14" class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>
                                                            State/Province <span class="star">*</span></label>
                                                        <asp:TextBox ID="Sate" TabIndex="15" class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>
                                                            Zip Code <span class="star">*</span></label>
                                                        <asp:TextBox ID="Zipcode" TabIndex="16" MaxLength="7" class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                            <asp:Button id="btnsubmits" runat="server" Text="SUBMIT APPLICATION"  OnClientClick="return validateSend();" CssClass="btn btn-primary2"/>
                                            
                                              
                                            </div>
                                        </div>
                                        <!-- Form End  -->
                                    </div>
                                    <!-- /.inner -->
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- /.col-md-12 -->
                </div>
                <!-- /.row -->
                <div id="content-bottom">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="row white block-shadow" style="margin: 30px 0; padding: 10px 10px 20px 10px;">
                                <div class="col-sm-6 col-md-9">
                                    <h3 class="h3">
                                        Sell Your Car- Easy & Fast With Our Premium Packages</h3>
                                    <p>
                                        More then a million cars sold, already - Sign up for MobiCarz Premium Packages.</p>
                                    <input type="button" class="btn btn-primary" value="Sign Up for Premium Packages"
                                        style="display: inline-block; width: auto" onclick="window.location.href='Premium.aspx' " />
                                </div>
                                <div class="col-sm-6 col-md-3">
                                    <h3 class="h3">
                                        Used Cars Advertising</h3>
                                    <i class="i1">We help you grow your business</i><div class="clear">
                                    </div>
                                    View our <a href="Packages.aspx">Advertising Plans</a>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <!-- /.block -->
                        </div>
                        <!-- /.col-md-12 -->
                    </div>
                    <!-- /.row -->
                </div>
                <!-- /#content-bottom -->
            </div>
            <!-- /.container -->
        </div>
        <!-- /.section -->
    </div>
    <div id="footer">
        <uc1:Footer ID="Footer1" runat="server" />
    </div>

    <script src="libraries/jquery.bxslider/jquery.bxslider.js"></script>

    <script src="libraries/easy-tabs/lib/jquery.easytabs.min.js"></script>

    <script src="libraries/star-rating/jquery.rating.js"></script>

    <script src="libraries/colorbox/jquery.colorbox-min.js"></script>

    <script src="js/jslider/jquery.slider.min.js" type="text/javascript"></script>

    <script src="libraries/ezMark/js/jquery.ezmark.js"></script>

    <script type="text/javascript" src="libraries/flot/jquery.flot.js"></script>

    <script type="text/javascript" src="libraries/flot/jquery.flot.canvas.js"></script>

    <script type="text/javascript" src="libraries/flot/jquery.flot.resize.js"></script>

    <script type="text/javascript" src="libraries/flot/jquery.flot.time.js"></script>

    <script src="assets/js/carat.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/jquery.vticker.js"></script>

    <script src="js/FillMasterDataNew.js" type="text/javascript"></script>
     <script src="Static/JS/calendar.js" type="text/javascript"></script>

   

    <script type="text/javascript">
        var models;
        within = [10, 25, 50, 100, 'Anywhere'];
        var SearchResults;
        LoadingPage = 1;
        page = 1;
        PageResultsCount = 25;
        //hideSpinner();
        startNum = 1;
        var endNum = 25;
        maxPages = 0;
        totalTesults = 0;
        resultsLength = 0;
        //var ZipCodes = [];

        var make1 = 'All makes';
        var Modal1 = 'All models';
        var ZipCode1 = '';
        var WithinZipNew = 3;


        function pageLoad() {
            GetRecentListings();           
        }


        
            
    
    </script>
   <script type="text/javascript" language="javascript">
     function isNumberKey(evt)
        {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;
          return true;
        }
    
     function isAlphaKey(e)
        {
	        isIE=document.all? 1:0
	        keyEntry = !isIE? e.which:event.keyCode;
	        if(((keyEntry >= '65') && (keyEntry <= '90')) || ((keyEntry >= '97') && (keyEntry <= '122')) || (keyEntry=='46') || (keyEntry=='32') || keyEntry=='45' ) 
		        return true;  
	        else
		        return false;
        }
    function isNumberKeyWithDot(evt) {

            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46)
                return false;

            return true;
        }
    function validateSend()
	  {  
        debugger     
            var valid=true;  
    
           
            if(document.getElementById('txt_Fname').value.length<1)
            {
                alert("Please enter the First Name.");               
                valid=false;
                document.getElementById("txt_Fname").focus();
            }
            else if(document.getElementById('txt_Fname').value.trim().length<1)
            {
                alert("Please enter the valid name.");               
                valid=false;
                document.getElementById("txt_Fname").value="";
                document.getElementById("txt_Fname").focus();
            }
           
            
           else if(document.getElementById('txt_LName').value.length<1)
            {
                alert("Please enter the Last Name.");               
                valid=false;
                document.getElementById("txt_LName").focus();
            }
            else if(document.getElementById('txt_LName').value.trim().length<1)
            {
                alert("Please enter the valid name.");               
                valid=false;
                document.getElementById("txt_LName").value="";
                document.getElementById("txt_LName").focus();
            }
          
                                   
             else if (document.getElementById('<%= txt_email.ClientID %>').value.length < 1)
             {
                alert("Please enter email address");
                document.getElementById('<%= txt_email.ClientID %>').focus();
                valid = false;
            } 
                else if (document.getElementById('<%= txt_email.ClientID %>').value.length < 1)
             {
                alert("Enter email address");
                document.getElementById('<%= txt_email.ClientID %>').focus();
                valid = false;
            }    
            
             else if (echeck(document.getElementById('<%= txt_email.ClientID %>').value)==false)
	        {
		        document.getElementById('<%= txt_email.ClientID %>').value=""
		        document.getElementById('<%= txt_email.ClientID %>').focus()
		        valid=false;
        		return valid;
	        }                     
            else if(document.getElementById("txt_email").value.length<1 && echeck(document.getElementById("txt_email").value)==false)
            {
                alert("Please enter the email address");               
                valid=false;
                document.getElementById("txt_email").focus();
                
            } 
             else if(document.getElementById('txt_prim1').value.length<1)
            {
                alert("Please enter the phone number.");               
                valid=false;
                document.getElementById("txt_prim1").focus();
            }    
            else if(document.getElementById('txt_prim1').value.trim().length<1)
            {
                alert("Please enter valid phone number.");               
                valid=false;
                document.getElementById("txt_prim1").value="";
                document.getElementById("txt_prim1").focus();
            }      
          
            else if(document.getElementById('StrAdd').value.length<1)
            {
                alert("Please enter the Street Address.");               
                valid=false;
                document.getElementById("StrAdd").focus();
            }
            else if(document.getElementById('StrAdd').value.trim().length<3)
            {
                alert("Please enter the Street Address.");               
                valid=false;
                document.getElementById("StrAdd").value="";
                document.getElementById("StrAdd").focus();
            }
           else if(document.getElementById('City').value.length<1)
            {
                alert("Please enter the City Name.");               
                valid=false;
                document.getElementById("City").focus();
            }
            else if(document.getElementById('City').value.trim().length<1)
            {
                alert("Please enter the City Name.");               
                valid=false;
                document.getElementById("City").value="";
                document.getElementById("City").focus();
            }
            else if(document.getElementById('Sate').value.length<1)
            {
                alert("Please enter the State.");               
                valid=false;
                document.getElementById("Sate").focus();
            }
            else if(document.getElementById('Sate').value.trim().length<1)
            {
                alert("Please enter the State.");               
                valid=false;
                document.getElementById("Sate").value="";
                document.getElementById("Sate").focus();
            }
             else if(document.getElementById('Zipcode').value.length<1)
            {
                alert("Please enter the ZipCode.");               
                valid=false;
                document.getElementById("Zipcode").focus();
            }
            else if(document.getElementById('Zipcode').value.trim().length<1)
            {
                alert("Please enter the Zipcode.");               
                valid=false;
                document.getElementById("Zipcode").value="";
                document.getElementById("Zipcode").focus();
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
	
     
    </script>

  <script type="text/javascript" language="javascript">
    
       function poptastic(url)
{
	newwindow=window.open(url,'name','directories=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,height=420,width=300');
	    if (window.focus) {newwindow.focus()}
    }
    
     function isNumberKeyForDt(evt) {	

                    var charCode = (evt.which) ? evt.which : event.keyCode
                    if (charCode > 31 && (charCode < 48 || charCode > 57)&& charCode != 47)
                    return false;
                    return true;
                    }
    
    
        function ValidateData() {
            var valid = true;
            var today = new Date();
            var month = today.getMonth() + 1
            var day = today.getDate()
            var year = today.getFullYear()
            today = month + "/" + day + "/" + year
            var today = new Date(today);
            var SDate = document.getElementById('<%= txtStartDate.ClientID %>').value;
            var EDate = document.getElementById('<%= txtEndDate.ClientID %>').value;
            var endDate = new Date(EDate);
            var startDate = new Date(SDate);
            var Startmonth = startDate.getMonth() + 1
            var Startday = startDate.getDate()
            var Startyear = startDate.getFullYear()
            startDate = Startmonth + "/" + Startday + "/" + Startyear
            var startDate = new Date(startDate);

            var Endmonth = endDate.getMonth() + 1
            var Endday = endDate.getDate()
            var Endyear = endDate.getFullYear()
            var oneDay = 24 * 60 * 60 * 1000;

            endDate = Endmonth + "/" + Endday + "/" + Endyear

            var endDate = new Date(endDate);

            var ValidOldData = Math.abs((startDate.getTime() - today.getTime()) / (oneDay));
            var ValidDates = Math.abs((startDate.getTime() - endDate.getTime()) / (oneDay));
            
          
            if (SDate == '') {
                alert("Please enter start date");

                valid = false;
                return valid;
            }
            if (EDate == '') {

                alert("Please enter end date");
                valid = false;
                return valid;
            }
            var dtFromDt = document.getElementById('<%=txtStartDate.ClientID%>').value;
            if (isDate(dtFromDt) == false) {
                document.getElementById('<%=txtStartDate.ClientID%>').focus();
                valid = false;
                return valid;
            }

            var dtTodt = document.getElementById('<%=txtEndDate.ClientID%>').value;
            if (isDate(dtTodt) == false) {
                document.getElementById('<%=txtEndDate.ClientID%>').focus();
                valid = false;
                return valid;
            }                   
            
            if (SDate != '' && EDate != '' && startDate > endDate) {
                alert("Start date is greater than end date");
                valid = false;
                return valid;
            }
            if (startDate > today) {
                alert("Start date should not be greater Than current date");
                valid = false;
                return valid;
            }
            if (endDate > today) {

                alert("End date should not be greater than current date");
                valid = false;
                return valid;
            }
            if (ValidOldData >= 365) {
                alert("Report can be generated for maximum of one year prior. Please change the dates and resubmit again");
                document.getElementById("<%=txtStartDate.ClientID%>").focus();
                valid = false;
                return valid;
            }
            return valid;
        }


        var dtCh = "/";
        var Chktoday = new Date();
        var minYear = Chktoday.getFullYear() - 1;
        var maxYear = Chktoday.getFullYear();

        function isInteger(s) {
            var i;
            for (i = 0; i < s.length; i++) {
                // Check that current character is number.
                var c = s.charAt(i);
                if (((c < "0") || (c > "9"))) return false;
            }
            // All characters are numbers.
            return true;
        }

        function stripCharsInBag(s, bag) {
            var i;
            var returnString = "";
            // Search through string's characters one by one.
            // If character is not in bag, append to returnString.
            for (i = 0; i < s.length; i++) {
                var c = s.charAt(i);
                if (bag.indexOf(c) == -1) returnString += c;
            }
            return returnString;
        }

        function daysInFebruary(year) {
            // February has 29 days in any year evenly divisible by four,
            // EXCEPT for centurial years which are not also divisible by 400.
            return (((year % 4 == 0) && ((!(year % 100 == 0)) || (year % 400 == 0))) ? 29 : 28);
        }
        function DaysArray(n) {
            for (var i = 1; i <= n; i++) {
                this[i] = 31
                if (i == 4 || i == 6 || i == 9 || i == 11) { this[i] = 30 }
                if (i == 2) { this[i] = 29 }
            }
            return this
        }

        function isDate(dtStr) {
            var daysInMonth = DaysArray(12)
            var pos1 = dtStr.indexOf(dtCh)
            var pos2 = dtStr.indexOf(dtCh, pos1 + 1)
            var strMonth = dtStr.substring(0, pos1)
            var strDay = dtStr.substring(pos1 + 1, pos2)
            var strYear = dtStr.substring(pos2 + 1)
            strYr = strYear
            if (strDay.charAt(0) == "0" && strDay.length > 1) strDay = strDay.substring(1)
            if (strMonth.charAt(0) == "0" && strMonth.length > 1) strMonth = strMonth.substring(1)
            for (var i = 1; i <= 3; i++) {
                if (strYr.charAt(0) == "0" && strYr.length > 1) strYr = strYr.substring(1)
            }
            month = parseInt(strMonth)
            day = parseInt(strDay)
            year = parseInt(strYr)
            if (pos1 == -1 || pos2 == -1) {
                alert("The date format should be : mm/dd/yyyy")
                return false
            }
            if (strMonth.length < 1 || month < 1 || month > 12) {
                alert("Please enter a valid month")
                return false
            }
            if (strDay.length < 1 || day < 1 || day > 31 || (month == 2 && day > daysInFebruary(year)) || day > daysInMonth[month]) {
                alert("Please enter a valid day")
                return false
            }

            if (strYear.length != 4 || year == 0 || year < minYear || year > maxYear) {
                //alert("Enter only these years "+minYear+" "+maxYear+" to get data");		
                alert("Report can be generated for maximum of one year prior. Please change the dates and resubmit again");
                return false
            }
            if (dtStr.indexOf(dtCh, pos2 + 1) != -1 || isInteger(stripCharsInBag(dtStr, dtCh)) == false) {
                alert("Please enter a valid date")
                return false
            }
            return true
        }
    
    </script>

    </form>
</body>
</html>
