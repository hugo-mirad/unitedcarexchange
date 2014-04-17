<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SellMyCar.aspx.cs" Inherits="Mobile_SellMyCar" %>

<!DOCTYPE html PUBLIC "-//WAPFORUM//DTD XHTML Mobile 1.0//EN" "http://www.wapforum.org/DTD/xhtml-mobile10.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <title>United Car Exchange</title>
    <link href="css/mobile.css" rel="stylesheet" type="text/css" media="handheld,all" />

    <script type="text/javascript" src="js/jquery-1.7.min.js"></script>

    <script src="js/jquery.alphanumeric.js" type="text/javascript"></script>
    
    <style>
        .input1
        {
            margin:0 0 7px 0;	
        }
        
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <!-- MAin Start  -->
    <div class="main">
        <!-- Logo Start -->
        <div class="logo">
            <a href="index.aspx">
                <img src="images/logo.png" alt="" /></a>
            <div class="clear">
                &nbsp;</div>
            &nbsp; Toll-free: <span>888-786-8307</span>
            <div class="clear">
                &nbsp;</div>
            <div class="strip">
                &nbsp;</div>
        </div>
        <!-- Logo End  -->
        <div class="clear">
            &nbsp;</div>
        <!-- Content Start  -->
        <div class="content">
            <h3 class="h2">
                Sell My Car<a href='javascript:history.go(-1)' class='back'>< back</a></h3>
                Please fill up your information and one of our area marketing specialist will contact you.
           
            <div style="margin:15px 0; width:98%;">
                <h4 class="h41">Contact Name <span class="star">*</span></h4>
                <input type="text" class="input1" />
                
                 <h4 class="h41">Phone <span class="star">*</span></h4>
                <input type="text" class="input1" />
                
                 <h4 class="h41">Email Address <span class="star">*</span></h4>
                <input type="text" class="input1" />
                
                <h4 class="h41">City</h4>
                <input type="text" class="input1" />
                
                <div style="width:130px; float:left; margin-right:10px;">
                    <h4 class="h41">State</h4>
                    <input type="text" class="input1" />
                </div>
                <div style="width:65px; float:left;">
                    <h4 class="h41">Zip</h4>
                    <input type="text" class="input1" />
                </div>                
                <div class="clear">&nbsp;</div>
                
                <h4 class="h41">Notes</h4>
                <textarea class="input1" style="height:60px;"></textarea>
                
                <input type="button" value="Send" class="button1"  />
                
            </div>
            <div class="clear">
                &nbsp;</div>
                
                 <!-- Home ADS Atsrt -->
    <div class="homeAds">

        <script type="text/javascript"><!--
google_ad_client = "ca-pub-7372260920181787";
/* MobileHome */
google_ad_slot = "3132050414";
google_ad_width = 320;
google_ad_height = 50;
//-->
        </script>

        <script type="text/javascript" src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
        </script>
        <div class="clear">&nbsp;</div>
    </div>
    <!-- Home ADS end  -->
    
        </div>
        <!-- Content End  -->
        <div class="clear">
            &nbsp;</div>
    </div>
    <!-- MAin End  -->
    <div class="clear">
        &nbsp;</div>
    <div class="clear">
        &nbsp;</div>
    <!-- Footer Start -->
    <div class="footer">
        <a href="index.aspx">Home</a> | <a href="aboutUs.html">About Us</a> | <a href="contactUs.html">
            Contact Us</a> <!-- | <a href="Sellmycar.aspx">Sell My car</a>  -->
        <div class="copyRight">
            &copy; 2012 United Car Exchange</div>
    </div>
    <!-- Footer End  -->
    </form>
</body>
</html>
