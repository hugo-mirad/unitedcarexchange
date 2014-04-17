<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TermsandConditions.aspx.cs"
    Inherits="TermsandConditions" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Src="UserControl/LoginName.ascx" TagName="LoginName" TagPrefix="uc2" %>
<%@ Register Src="UserControl/CarsHeader.ascx" TagName="CarsHeader" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <title>..:: United Car Exchange ::..</title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="css/tabbed.css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/layout.css" rel="stylesheet" type="text/css" />
    <link href="css/jqtransform.css" rel="stylesheet" type="text/css" />
    <link href="css/svwp_style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="js/jquery-1.7.min.js"></script>

    <script type="text/javascript" src="js/cufon-yui.js"></script>

    <script type="text/javascript" src="js/jquery.vticker.js" charset="utf-8"></script>

    <script type="text/javascript" src="js/jquery.slideViewerPro.1.5.js"></script>

    <script type="text/javascript" src="js/jquery.timers.js"></script>

    <!--[if lt IE 7]>
  <script type="text/javascript" src="js/ie_png.js"></script>
  <script type="text/javascript">
  ie_png.fix('.png, .container p');
  </script>
  <link href="ie.css" rel="stylesheet" type="text/css" />
<![endif]-->

    <script src="js/jquery.idTabs.min.js" type="text/javascript" charset="utf-8"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/FillMasterDataNew.js" type="text/javascript"></script>

    <script src="js/Filter.js" type="text/javascript"></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

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
    
    var make1='All makes' ;
    var Modal1='All models';
    var ZipCode1='' ;
    var WithinZipNew=3 ; 
    
       
   function pageLoad() {
        GetRecentListings();
        GetMakes();
        GetModelsInfo();     
        //GetZips();  
   }
    
    
    function KeyDownHandler(btn)
    {
      if (event.keyCode == 13)
      {
        event.returnValue=false;
        //event.cancel = true;
        //btn.click();
      }
    }

  
    KeyListener = {
        init : function() {
            $('#searchFormHolder').bind('keypress', function(e) {
                var key = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
                var target = e.target.tagName.toLowerCase();
                if (key === 13 && target === 'input') {
                    e.preventDefault();
                    var button = $('.but1');
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

            $(document).ready(function() {
                KeyListener.init()
            });
            
    
    </script>

    <!-- Look at the configuration -->

    <script src="js/watermark.js" type="text/javascript"></script>

</head>
<body id="page1">
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    <div>
        <div id="main-bg">
            <div id="main">
                <!-- header -->
                <div id="header" style="height: 77px">
                    <a href="http://UnitedCarExchange.com">
                        <img src="images/logo2.png" id="logo" alt="" /></a>
                    <div class="loginStat">
                        <%--<asp:Label ID="lblWelcome" runat="server" Text="Welcome" Visible="false"></asp:Label>
                        &nbsp;&nbsp;<asp:Label ID="lblUserName" runat="server" Visible="false"></asp:Label>
                        <asp:LinkButton ID="lnkBtnLogout" runat="server" CssClass="login" Text="Logout" Visible="false"
                            OnClick="lnkBtnLogout_Click"></asp:LinkButton>
                        <asp:LinkButton ID="lnkLogin" runat="server" CssClass="login" Text="Login" PostBackUrl="~/Login.aspx"></asp:LinkButton>--%>
                        <!-- <a href="#"><div  id="gomobile">Go mobile <img src="images/mobile.png" alt="" /></div></a>  -->
                        <uc2:LoginName ID="LoginName1" runat="server" />
                    </div>
                    <div id="menu">
                        <uc3:CarsHeader ID="CarsHeader1" runat="server" />
                    </div>
                </div>
                <!-- content -->
                <div id="content">
                    <div class="wrapper-1">
                        <!-- column Left Div Start  -->
                        <div id="column-left">
                            <div class="indent" style="padding-top: 5px;">
                                <div class="wrapper">
                                    <!-- Recent Used Car Listings  start -->
                                    <div class="leftBox1">
                                        <h3 class="h3">
                                            Recent Used Car Listings</h3>
                                        <em class="i1">Most recent Used Cars listed for sale</em>
                                        <!-- Ticker1 Div Start  -->
                                        <div class="ticker1">
                                            <ul>
                                                <li>
                                                    <div>
                                                        <a href="#"><strong></strong></a>
                                                        <br />
                                                    </div>
                                                </li>
                                            </ul>
                                        </div>
                                        <!-- Ticker1 Div End  -->
                                    </div>
                                    <!-- Recent Used Car Listings end  -->
                                    <div class="clear">
                                        &nbsp;</div>
                                    <!-- Left Brand Ads Satrt -->
                                    <div id="div250X250" runat="server" style="padding: 3px; margin: 5px auto; width: 250px;
                                        height: 250px">
                                    </div>
                                    <div id="lBrandAds2" style="width: 250px; padding: 3px; margin: 5px auto; text-align: left;">
                                        <!-- Begin: adBrite, Generated: 2012-05-09 5:53:51  -->
                                        <style type="text/css">
                                            .adHeadline
                                            {
                                                font: bold 10pt Arial;
                                                text-decoration: underline;
                                                color: #0000FF;
                                            }
                                            .adText
                                            {
                                                font: normal 10pt Arial;
                                                text-decoration: none;
                                                color: #000000;
                                            }
                                        </style>

                                        <script type="text/javascript">
try{var AdBrite_Iframe=window.top!=window.self?2:1;var AdBrite_Referrer=document.referrer==''?document.location:document.referrer;AdBrite_Referrer=encodeURIComponent(AdBrite_Referrer);}catch(e){var AdBrite_Iframe='';var AdBrite_Referrer='';}
document.write(String.fromCharCode(60,83,67,82,73,80,84));document.write(' src="http://ads.adbrite.com/mb/text_group.php?sid=2100989&br=1&ifr='+AdBrite_Iframe+'&ref='+AdBrite_Referrer+'" type="text/javascript">');document.write(String.fromCharCode(60,47,83,67,82,73,80,84,62));</script>

                                        <div>
                                            <a class="adHeadline" target="_top" href="http://www.adbrite.com/mb/commerce/purchase_form.php?opid=2100989&afsid=1">
                                                Your Ad Here</a></div>
                                        <!-- End: adBrite -->
                                    </div>
                                    <div class="clear">
                                        &nbsp;</div>
                                    <!-- Left Brand Ads End -->
                                    <!-- Advantage of Buying Used Cars Start -->
                                    <div class="leftBox1">
                                        <h3 class="h3">
                                            Advantage of Buying Used Cars
                                        </h3>
                                        <em class="i1">Must read tips &amp; advices on used cars</em><br />
                                        <ul class="bullet" style="margin-left: 10px;">
                                            <li><a href="tips.aspx">Used Car buying tips</a></li>
                                        </ul>
                                    </div>
                                    <!-- Advantage of Buying Used Cars End -->
                                </div>
                            </div>
                        </div>
                        <!-- column Left Div End  -->
                        <div id="column-right" class="column-indent">
                            <div class="indent">
                                <div class="wrapper">
                                    <!--  -->
                                    <div class="info-box" style="background: #fff;">
                                        <div class="wrapper">
                                            <table>
                                                <tr>
                                                    <td style="padding-right: 20px; padding-top: 10px;">
                                                        <h2>
                                                            Terms & Conditions
                                                        </h2>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div style="border-top: #ccc 1px solid; padding: 15px 10px; width: 95%;">
                                                <h3>
                                                    PLEASE READ THIS DOCUMENT CAREFULLY! IT CONTAINS VERY IMPORTANT INFORMATION ABOUT
                                                    YOUR RIGHTS AND OBLIGATIONS, AS WELL AS LIMITATIONS AND EXCLUSIONS THAT MAY APPLY
                                                    TO YOU.</h3>
                                                <span class="style1">
                                                    <br clear="all" />
                                                </span>
                                                <p class="style1">
                                                    These Terms of Sale apply to your purchase of online ads that are offered through
                                                    UnitedCarExchange.com and its' affiliated websites' "sell your vehicle", "sell your
                                                    car" or similar services. By placing an order for any ad appearing through the Sell
                                                    Your Car or similar service, you accept and are bound by these terms and conditions.
                                                    If you do not wish to be bound by these terms and conditions, you should not place
                                                    an order for an ad through this service.</p>
                                                <p class="style1">
                                                    <h3 class="border1">
                                                        1. General Rules</h3>
                                                    <b>1.1</b> Sell Your Car ads are available only to private sellers who want to list
                                                    their personally owned vehicle(s) for sale. UnitedCarExchange.com and its affiliates
                                                    reserve the right (but assume no obligation) to delete, move, or edit (without refund)
                                                    any ads or posting(s) that come to our attention that we consider unacceptable or
                                                    inappropriate, whether for legal or other reasons.<br />
                                                    <br />
                                                    <b>1.2</b> You may not list more than five (5) vehicles simultaneously through the
                                                    Sell Your Car service. Individuals who seek to list more than five (5) vehicles
                                                    on the UnitedCarExchange.com website simultaneously, as well as all dealers, brokers,
                                                    businesses or persons otherwise engaged in the commercial sale of vehicles or offering
                                                    vehicles for sale as a paid service to a seller or title holder, must make other
                                                    arrangements with us and our affiliates to place such commercial ads. Please visit
                                                    our UnitedCarExchange.com Dealer page to find out more about dealer listings and
                                                    advertising opportunities on UnitedCarExchange.com and our affiliated products and
                                                    services.<br />
                                                    <br />
                                                    <b>1.3</b> By using the Sell Your Car service, you represent that you are at least
                                                    eighteen (18) years old. You also represent that you are not a motor vehicle dealer,
                                                    broker, business or person otherwise engaged in the commercial sale of vehicles.
                                                    You further represent that you are not offering vehicles for sale as a paid service
                                                    to a seller or title holder of a vehicle, and that you are not listing a vehicle
                                                    for sale in your capacity as an employee or representative of a dealer, broker,
                                                    business or person otherwise engaged in the commercial sale of vehicles. Likewise,
                                                    you represent that you are not acting as a broker or agent for a private seller
                                                    that placed an ad through the Sell Your Car service. Additionally, you represent
                                                    that neither you nor anyone acting on your behalf will list more than five (5) vehicles
                                                    for sale simultaneously through the Sell Your Car service.<br />
                                                    <br />
                                                    <b>1.4</b> UnitedCarExchange.com and its affiliates reserve the right to deny use
                                                    of their respective online and offline products and services, which includes this
                                                    website, to anyone who does not comply with these Terms of Sale or who otherwise
                                                    use such online and/or offline products or services, including this website, in
                                                    a manner we consider inappropriate.<br />
                                                    <br />
                                                    <b>1.5</b> Our used car listings include vehicles that have been &quot;certified&quot;
                                                    as meeting certain standards established by manufacturers and/or dealers in connection
                                                    with their pre-owned vehicle programs.&nbsp; Ads purchased by private sellers through
                                                    the Sell Your Car service will not appear in any &quot;certified&quot; area of our
                                                    website or any similar area within our affiliated products and services.&nbsp; Our
                                                    &quot;certified&quot; ads apply only to vehicles certified by the automobile manufacturers
                                                    and/or dealers with which we have partnerships.</p>
                                                <p class="style1">
                                                    <br />
                                                    <h3 class="border1">
                                                        2.Using the &quot;Sell Your Car&quot; Service</h3>
                                                    <b>2.1</b> When you offer a vehicle for sale through the Sell Your Car service,
                                                    you must be prepared to sell that vehicle at the price at which, and the terms on
                                                    which, you've listed it. You must have possession of the actual vehicle listed and
                                                    the ability to transfer title.<br />
                                                    <br />
                                                    <b>2.2</b> To list a vehicle for sale through the Sell Your Car service, you are
                                                    required to provide certain identifying and contact information. The information
                                                    in your ad must accurately identify you and the method of contact must permit buyers
                                                    to communicate directly with you; you may not include in your ad the name, telephone
                                                    number or email address of any agent, broker or dealer. Only your personal contact
                                                    information may appear in your ad.<br />
                                                    <br />
                                                    <b>2.3</b> You may not charge any potential buyer for information about any vehicle
                                                    listed for sale on UnitedCarExchange.com, nor may you use our website to promote,
                                                    without our prior written permission, any other website, product or service. Any
                                                    rights and obligations you maintain under these Terms of Sale to access and use
                                                    the Sell Your Car service are personal to you. Consequently, you may not assign
                                                    or delegate any such rights or obligations to any third party, which includes agents,
                                                    brokers or dealers.<br />
                                                    <br />
                                                    <b>2.4</b> Ad(s) placed through the Sell Your Car service may not be used to advertise
                                                    more than one (1) vehicle per ad purchased, regardless of the type of advertising
                                                    package you select or the duration of its publication. For this reason, you may
                                                    not edit your vehicle's Year, Make, Model and VIN once you purchase your ad. Always
                                                    double-check this information before submitting your ad. If you believe you made
                                                    an error while submitting your vehicle's Year, Make, Model or VIN, you must promptly
                                                    contact UnitedCarExchange.com customer support.<br />
                                                    <br />
                                                    <b>2.5</b> Responsibility for the information contained in your ad lies with you,
                                                    the seller. You alone are responsible for material you post online, and for the
                                                    content of all text messages transmitted through the online portions of the Sell
                                                    Your Car service.</p>
                                                <p class="style1">
                                                    <br />
                                                    <h3 class="border1">
                                                        3.Quality Assurance</h3>
                                                    <b>3.1</b> Though we can't monitor every transaction that originates on or takes
                                                    place through the Sell Your Car service, we may perform random quality assurance
                                                    tests to confirm that those who offer vehicles for sale through the Sell Your Car
                                                    service are prepared to sell the vehicles they advertise at the prices at which,
                                                    and the terms on which, they advertise them.<br />
                                                    <br />
                                                    <b>3.2</b> Photos submitted as part of any ad placed through the Sell Your Car service
                                                    must correspond to the actual vehicle being offering for sale. As part of our random
                                                    quality assurance tests, if we encounter a photo that we believe does not accurately
                                                    represent the actual vehicle you are offering for sale through the Sell Your Car
                                                    service, we maintain the right to immediately remove such photo(s) and/or your corresponding
                                                    ad. If you believe your photo(s) and/or your corresponding ad was removed in error,
                                                    you must promptly contact one of our customer service representatives.<br />
                                                    <br />
                                                    <b>3.3</b> By using the Sell Your Car service, you agree to cooperate in these random
                                                    quality assurance tests. If our tests reveal, or we otherwise learn, that you are
                                                    engaging in &quot;bait and switch&quot; or other unfair or deceptive practices,
                                                    UnitedCarExchange.com and/or its affiliates reserve the right to deny you use of
                                                    the Sell Your Car service.<br />
                                                    <br />
                                                    <b>3.4</b> In connection with our efforts to combat fraud, some ads may be screened
                                                    before being posted publicly. This process may delay display of your ad listing(s)
                                                    for up to 24 hours from the time we accept your ad. If your ad does not appear on
                                                    UnitedCarExchange.com after 24 hours, you must promptly contact one of our customer
                                                    service representatives.<br />
                                                    <br />
                                                    <b>3.5</b> Although UnitedCarExchange.com cannot monitor all the ads processed through
                                                    the Sell Your Car service, we reserve the right (but assume no obligation) to delete,
                                                    move, or edit (without refund) any ads, postings or other electronic communications
                                                    that come to our attention that we consider unacceptable or inappropriate, whether
                                                    for legal or other reasons.<br />
                                                    <br />
                                                    <b>3.6</b> By placing ads through the Sell Your Car service you agree not to post
                                                    or transmit any defamatory, abusive, obscene, threatening, misleading, or illegal
                                                    material, or any other material that infringes on the rights of others or interferes
                                                    with the ability of others to enjoy UnitedCarExchange.com or our affiliated products
                                                    and services. UnitedCarExchange.com and our affiliates retain the right to deny
                                                    access to anyone who we believe has violated these Terms of Sale, which includes
                                                    our Visitor Agreement.<br />
                                                    <br />
                                                    <b>3.7</b> Except as otherwise provided under these Terms of Sale, which include
                                                    our Visitor Agreement, UnitedCarExchange.com and our affiliates will not, in the
                                                    ordinary course of business, review the content of private electronic messages that
                                                    are not addressed to UnitedCarExchange.com or any of our affiliates. However, UnitedCarExchange.com
                                                    and our affiliates may occasionally release information concerning such communications
                                                    when release is appropriate to comply with law (including disclosure in response
                                                    to a request from a law enforcement agency), to enforce these Terms of Sale, which
                                                    includes our Visitor Agreement, or to protect the rights, property or safety of
                                                    visitors to our site, our advertisers, our affiliates, the public or UnitedCarExchange.com.</p>
                                                <p class="style1">
                                                    <br />
                                                    <h3 class="border1">
                                                        4. Fees, Payments and Refunds. Premiums, Promotions and Free Services</h3>
                                                    <b>4.1</b> By placing an ad through the Sell Your Car service, you agree to pay
                                                    all fees and charges incurred at the rates in effect for the billing period covering
                                                    the advertising package(s) you obtain, regardless of whether your vehicle sells
                                                    as a result of the ad package(s) you purchase. All fees and charges will be applied
                                                    against the form of payment you provide as part of the ad selection process and
                                                    you agree to pay such fees and charges. You also agree to pay any applicable taxes
                                                    relating to your use of the Sell Your Car service. At its sole discretion, UnitedCarExchange.com
                                                    reserves the right at any time to offer the Sell Your Car service at a discount
                                                    or to provide premiums and promotions as incentives, up to and including free Sell
                                                    Your Car Services<br />
                                                    <br />
                                                    <b>4.2</b> Should UnitedCarExchange.com offer Sell Your Car ads at no charge on
                                                    our website and/or via our call center(s), we may, at our sole discretion, offer
                                                    these ads nationally, in a limited number of markets, to a limited number of advertisers,
                                                    or for a limited period of time. When you list a car for sale using any free Sell
                                                    Your Car advertising service that we may offer, you will be asked for information
                                                    on the car you are selling and on how you can be contacted by potential buyers.
                                                    We may also ask you for other personally identifying information for security purposes.
                                                    We may use this information to contact you about your listing, or for marketing
                                                    and other promotional purposes, including offers of additional paid ad services.
                                                    By placing a free Sell Your Car ad on UnitedCarExchange.com you agree to be contacted
                                                    by us about your listing, or for marketing and other promotional purposes, via any
                                                    of the contact methods that you supply, including telephone, email and snail mail.
                                                    We may also share, or sell, the contact information you provide with companies who
                                                    advertise on our website, or who otherwise compensate us for this information, including
                                                    vehicle manufacturers. If you do not wish to share your email address or other contact
                                                    information with either UnitedCarExchange.com or our advertisers for the purpose
                                                    of receiving marketing and promotional offers, you should not use our free Sell
                                                    Your Car service.<br />
                                                    <br />
                                                    <b>4.3</b> You must use care when selecting your ad package and inputting your ad
                                                    information; listing fees are generally not refundable, even if you provide erroneous
                                                    information or fail to sell your vehicle. Since you place the order for &quot;online
                                                    only&quot; ads through the Sell Your Car service, UnitedCarExchange.com and its
                                                    affiliates cannot be responsible for your ad listing errors and, therefore, we cannot
                                                    offer refunds on any fees or charges to list your ad(s).<br />
                                                    <br />
                                                    <b>4.4</b> Except as provided under Section 4.5, below, UnitedCarExchange.com and
                                                    its affiliates will not provide any refund for any reason if UnitedCarExchange.com
                                                    or one of its affiliates receives the request for refund after your ad is published
                                                    on this website.&nbsp; However, UnitedCarExchange.com will reasonably assist you
                                                    to correct certain mistakes made by you in placing your ad (for example, Year, Make,
                                                    Model, or VIN).<br />
                                                    <b>4.5</b> UnitedCarExchange.com will provide you a refund or credit only for the
                                                    reasons identified in Subsection 4.5.1 through 4.5.3, below:<br />
                                                    <br />
                                                    <b>4.5.1</b> You may be entitled to a refund or credit if your ad has not been posted
                                                    on this website within the first 72 hours from the time we accept your order for
                                                    an ad. In that case, you must immediately contact UnitedCarExchange.com customer
                                                    service to request a refund or credit. <u>You may not request, and we will not issue,
                                                        a cancellation and refund or credit due to non-publication of your ad within the
                                                        first 24 hours, starting from the time we accept your order for an ad, which includes
                                                        the time you take to post your vehicle's photo within the Sell Your Car service;
                                                        you agree that UnitedCarExchange.com will maintain at least 24 hours to fully process
                                                        your entire ad listing through the Sell Your Car service, which includes clearing
                                                        your ad listing through the Sell Your Car service's anti-fraud filters</u>.
                                                    Please note that our office is not open during weekends and statutory holidays;
                                                    weekends, evenings, nights and statutory holidays do not count toward the time limits
                                                    specified here.<br />
                                                    <br />
                                                    <b>4.5.2</b> You may be entitled to a refund or credit if you mistakenly order and
                                                    pay for duplicate ads through the Sell Your Car service and seek to cancel and obtain
                                                    a refund or credit on the duplicate ad only. You are not entitled and we cannot
                                                    provide you a refund or credit on the original ad listing.<br />
                                                    <br />
                                                    <b>4.5.3</b> You will be entitled to a refund with respect to an ad with the Money-Back
                                                    Guarantee feature under the following circumstances:&nbsp; (i) your ad with the
                                                    Money-Back Guarantee feature has run on UnitedCarExchange.com for a period of at
                                                    least 90 consecutive days from the date UnitedCarExchange.com completed processing
                                                    of your ad as described in Section 4.5.1 above; (ii) you fully complete and submit
                                                    to us a refund request form, available from the UnitedCarExchange.com website, which
                                                    is postmarked 91-105 days after placing the ad; (iii) at the time you submit your
                                                    refund request form, the vehicle advertised in your ad with the Money-Back Guarantee
                                                    feature is still for sale by you and the title to the vehicle is held by you or
                                                    by a lien holder on your behalf; (iv) once we receive your refund request form,
                                                    we will review your request to determine, in our sole discretion, whether you have
                                                    complied with all terms and conditions; (v) if we determine that you have satisfied
                                                    all the terms and conditions, we will refund the profiling fees you paid subject
                                                    to a deduction of listing and administrative fee of $100.00. The money will be refunded
                                                    using the same method of payment you used to purchase the ad; and (vi) after we
                                                    process your refund, your ad will be removed from the UnitedCarExchange.com site.<br />
                                                    <br />
                                                    <b>4.6</b> Except as provided under Subsections 4.5.1 through 4.5.3, above, UnitedCarExchange.com
                                                    and its affiliates cannot provide a refund or credit for any other reason, even
                                                    if you contact us within 72 hours from the time we accept your order for an ad.
                                                    For example, we cannot provide you a refund or credit if you change your mind about
                                                    publishing your ad, its content or any enhancements you purchased in relation to
                                                    your ad selection. You are not entitled to a refund or credit if you wish to change
                                                    to a less expensive ad package. We cannot provide you a refund or credit if you
                                                    made mistakes while submitting your ad information or if you fail to receive any
                                                    inquiries or offers to purchase your vehicle through the use of the Sell Your Car
                                                    service. No refund or credit will be issued if you sold your vehicle through other
                                                    means. Likewise, you are not entitled to a refund or credit if you place an ad on
                                                    the Sell Your Car service through a third party source (for example, newspapers
                                                    or third party websites) and you also place a similar or identical ad directly with
                                                    UnitedCarExchange.com. Such ads are not considered &quot;duplicates&quot; and you
                                                    will not be entitled to cancel any such ads nor will you be entitled to a refund
                                                    or credit of any fees or charges associated with any such ads.<br />
                                                    <br />
                                                    <b>4.7</b> Except as provided under Subsections 4.5.1 through 4.5.3, while UnitedCarExchange.com
                                                    and its affiliates cannot provide you a refund or credit in cases where we have
                                                    made mistakes in the connection with the publication of your ad(s), UnitedCarExchange.com
                                                    will use reasonable efforts to correct any mistakes we might have made in placing
                                                    your ad; provided, that you contact UnitedCarExchange.com customer support within
                                                    the first 72 hours from the time we accept your order for an ad.<br />
                                                    <br />
                                                    <b>4.8</b> If you make a mistake while submitting an ad through the Sell Your Car
                                                    service, we will use reasonable efforts to make corrections (i.e., ads we reasonably
                                                    determine are duplicative, or contain erroneous ad information). You may incur an
                                                    added charge if you wish to order enhancements to your initial ad order. If your
                                                    ad on UnitedCarExchange.com was purchased through a third party source (for example,
                                                    a newspaper or third party website), we do not have the authority to make any changes
                                                    to your ad and we cannot provide you a credit or refund for such ads.</p>
                                                <p class="style1">
                                                    <br />
                                                    <h3 class="border1">
                                                        5.Added Value Services</h3>
                                                    <b>5.1</b> When you list a vehicle for sale through the Sell Your Car service, we
                                                    may obtain additional distribution for your ad listing through our relationships
                                                    with other websites. At this time, neither UnitedCarExchange.com nor any website
                                                    through which we distribute your listing will charge you any additional fee for
                                                    this additional exposure. It's just added value from UnitedCarExchange.com.</p>
                                                <p class="style1">
                                                    <br />
                                                    <h3 class="border1">
                                                        6.Ads with &quot;Run 'til It Sells&quot; Feature</h3>
                                                    <b>6.1</b> Subject to these Terms of Sale, ads which can be purchased through the
                                                    Sell Your Car service and which include a &quot;Run 'til It Sells&quot; feature
                                                    may not be published or available for publication through the Sell Your Car service
                                                    for a period greater than 365 consecutive days in the aggregate.<br />
                                                    <br />
                                                    <b>6.2</b>In all cases, your right to publish each Run'til It Sells ad will expire,
                                                    and such ad will be removed from our website and our other affiliated services on
                                                    the 365th day from the date you placed your original order for such ad through this
                                                    website.&nbsp; To extend the publication of a Run 'til It Sells ad beyond its 365
                                                    day lifespan, you must contact UnitedCarExchange.com customer support. UnitedCarExchange.com
                                                    and/or its affiliates may require that you provide additional information about
                                                    your vehicle in order determine whether an extension will be granted.&nbsp; Additionally,
                                                    UnitedCarExchange.com and its affiliates may require that you remit an additional
                                                    payment to extend your Run 'til It Sells ad listing beyond its initial 365 day lifespan.</p>
                                                <p class="style1">
                                                    <br />
                                                    <h3 class="border1">
                                                        7.Disclaimer of Warranties, Limitation of Liability, and Indemnification</h3>
                                                    <b>7.1</b> IF YOU RELY ON THIS WEBSITE OR ANY INFORMATION, PRODUCT OR SERVICE AVAILABLE
                                                    THROUGH THIS WEBSITE, YOU DO SO AT YOUR OWN RISK. YOU UNDERSTAND THAT THERE MAY
                                                    BE DELAYS, OMISSIONS, INTERRUPTIONS, INACCURACIES, AND/OR OTHER PROBLEMS WITH THE
                                                    INFORMATION, PRODUCTS, AND SERVICES PUBLISHED ON OR PROMOTED OVER THIS SITE AND/OR
                                                    THROUGH AFFILIATED PRODUCTS OR SERVICES. THIS WEBSITE AND ANY AFFILIATED PRODUCTS
                                                    AND SERVICES ARE PROVIDED TO YOU &quot;AS IS.&quot; UnitedCarExchange.com AND ITS
                                                    AFFILIATES, AGENTS AND LICENSORS CANNOT AND DO NOT WARRANT THE ACCURACY, COMPLETENESS,
                                                    CURRENTNESS, NONINFRINGEMENT, MERCHANTABILITY OR FITNESS FOR A PARTICULAR PURPOSE
                                                    OF THE INFORMATION AVAILABLE THROUGH THIS WEBSITE OR ANY AFFILIATED PRODUCT OR SERVICE
                                                    (OR ANY INFORMATION, GOODS OR SERVICES THAT ARE REFERRED TO, ADVERTISED OR PROMOTED
                                                    ON, OR SOLD THROUGH THIS WEBSITE). NOR DO WE OR THEY GUARANTEE THAT THE WEBSITE
                                                    AND/OR ANY AFFILIATED PRODUCT OR SERVICE WILL BE ERROR FREE, OR CONTINUOUSLY AVAILABLE,
                                                    OR THAT THE WEBSITE WILL BE FREE OF VIRUSES OR OTHER HARMFUL COMPONENTS.<br />
                                                    <br />
                                                    <b>7.2</b> UNDER NO CIRCUMSTANCES WILL UnitedCarExchange.com OR ITS AFFILIATES,
                                                    AGENTS OR LICENSORS BE LIABLE TO YOU OR ANYONE ELSE FOR ANY DAMAGES OTHER THAN DIRECT
                                                    DAMAGES, ARISING OUT OF YOUR USE OF THIS WEBSITE OR ANY AFFILIATED PRODUCT OR SERVICE
                                                    ASSOCIATED WITH OR OTHERWISE LINKED TO OR FROM THIS WEBSITE, OR ADVERTISED OR PROMOTED
                                                    ON THIS WEBSITE, INCLUDING, WITHOUT LIMITATION, CONSEQUENTIAL, SPECIAL, INCIDENTAL,
                                                    INDIRECT, PUNITIVE, EXEMPLARY, OR OTHER DAMAGES OF ANY KIND (INCLUDING LOST REVENUES
                                                    OR PROFITS, LOSS OF BUSINESS OR LOSS OF DATA), EVEN IF WE ARE ADVISED BEFOREHAND
                                                    OF THE POSSIBILITY OF SUCH DAMAGES. YOU AGREE THAT THE LIABILITY OF UnitedCarExchange.com
                                                    AND ITS AFFILIATES, AGENTS AND LICENSORS, IF ANY, ARISING OUT OF ANY KIND OF LEGAL
                                                    CLAIM ARISING OUT OF OR OTHERWISE RELATED TO THIS WEBSITE, THE SELL YOUR CAR SERVICE,
                                                    AND/OR ANY AFFILIATED PRODUCTS OR SERVICES WILL NOT EXCEED THE AMOUNT YOU PAID,
                                                    IF ANY, FOR THE USE OF THE WEBSITE OR THE USE OF THE SELL YOUR CAR SERVICE, OUT
                                                    OF WHICH SUCH LIABILITY ALLEGEDLY ARISES. BECAUSE SOME STATES/JURISDICTIONS DO NOT
                                                    ALLOW THE EXCLUSION OR LIMITATION OF LIABILITY FOR CONSEQUENTIAL OR INCIDENTAL DAMAGES,
                                                    SOME OF THESE LIMITATIONS MAY NOT APPLY TO YOU. YOU AGREE TO INDEMNIFY AND HOLD
                                                    HARMLESS UnitedCarExchange.com, ITS AFFILIATES, AND THEIR RESPECTIVE EMPLOYEES,
                                                    OWNERS, REPRESENTATIVES, AND LICENSEES AGAINST ANY AND ALL CLAIMS, OF WHATEVER NATURE,
                                                    THAT ARISE OUT OF ANY LISTING YOU PLACE OR ATTEMPT TO PLACE THROUGH THE SELL YOUR
                                                    CAR SERVICE.</p>
                                                <p class="style1">
                                                    <br />
                                                    <h3 class="border1">
                                                        8. Miscellaneous</h3>
                                                    <b>8.1</b> These Terms of Sale has been made in, and will be construed in accordance
                                                    with the laws of, the State of New Jersey. By accessing this website and/or using
                                                    the Sell Your Car service, you consent to the exclusive jurisdiction and venue of
                                                    the state and federal courts in Middlesex County, NJ in all disputes arising out
                                                    of or relating to these Terms of Sale, the use of this website, which includes the
                                                    use of the Sell Your Car service.<a name="_GoBack" id="_GoBack"></a></p>
                                            </div>
                                            <div class="clear">
                                            </div>
                                        </div>
                                    </div>
                                    <!-- -->
                                </div>
                            </div>
                            <!-- Results Start -->
                            <div id="div88X720" runat="server" style="height: 88px; width: 720px; margin: 10px auto;
                                border: #999 1px solid; padding: 1px; background: white;">
                            </div>
                            <!-- 
                            <div class="bottomAdd" style="margin-left: 1px;">
                               

                                <script type="text/javascript">
var AdBrite_Title_Color = '0000FF';
var AdBrite_Text_Color = '000000';
var AdBrite_Background_Color = 'FFFFFF';
var AdBrite_Border_Color = 'CCCCCC';
var AdBrite_URL_Color = '008000';
try{var AdBrite_Iframe=window.top!=window.self?2:1;var AdBrite_Referrer=document.referrer==''?document.location:document.referrer;AdBrite_Referrer=encodeURIComponent(AdBrite_Referrer);}catch(e){var AdBrite_Iframe='';var AdBrite_Referrer='';}
                                </script>

                                <span style="white-space: nowrap;">

                                    <script type="text/javascript">document.write(String.fromCharCode(60,83,67,82,73,80,84));document.write(' src="http://ads.adbrite.com/mb/text_group.php?sid=2102343&zs=3732385f3930&ifr='+AdBrite_Iframe+'&ref='+AdBrite_Referrer+'" type="text/javascript">');document.write(String.fromCharCode(60,47,83,67,82,73,80,84,62));</script>

                                    <a target="_top" href="http://www.adbrite.com/mb/commerce/purchase_form.php?opid=2102343&afsid=1">
                                        <img src="http://files.adbrite.com/mb/images/adbrite-your-ad-here-leaderboard.gif"
                                            style="background-color: #CCCCCC; border: none; padding: 0; margin: 0;" alt="Your Ad Here"
                                            width="14" height="90" border="0" /></a></span>
                                
                            </div>
                            -->
                            <!-- Results End -->
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </div>
                <!-- footer -->
                <div id="footer">
                    <uc1:Footer ID="Footer1" runat="server" />
                </div>
            </div>
        </div>
    </div>
    <!-- Processiong Popup Start -->
    <div id="spinner" style="display: none;">
        <h4>
            <div>
                Processing
                <img src="images/loading.gif" />
            </div>
        </h4>
    </div>
    <!-- Processiong
    Popup End -->
    </form>

    <script type="text/ecmascript" language="javascript">
	/* var make = [['All Makes',0],['Acura',20001],['Alfa Romeo',20047],['Am General',20002],['Aston Martin',20003],['Audi',20049],['Avanti Motors',20050],['Bentley',20051],['BMW',20005],['Bugatti',33583],['Buick',20006],['Cadillac',20052],['Chevrolet',20053],['Chrysler',20008]];
	
	var models = [['All Models',0],['Acadia',20607],['Accent',20605],['Acclaim',20609],['Accord',20606],['Accord Crosstour',34203],['Accord Hybrid',20611],['Achieva',20610],['Aerio',20619],['Aero 8',20621]];  
	
	*/
	
	var within = ['10','25','50','100','Anywhere'];
	
	
	var slideImg = ['images/large/zr1review_01.jpg',
					'images/large/zr1review_02.jpg',
					'images/large/zr1review_03.jpg',
					'images/large/zr1review_04.jpg',
					'images/large/zr1review_05.jpg',
					'images/large/zr1review_06.jpg',
					'images/large/zr1review_07.jpg',
					'images/large/zr1review_08.jpg',
					'images/large/zr1review_09.jpg',
					'images/large/zr1review_10.jpg',
					'images/large/zr1review_11.jpg',
					'images/large/zr1review_12.jpg',
					'images/large/zr1review_13.jpg',
					'images/large/zr1review_14.jpg',
					'images/large/zr1review_15.jpg',
					'images/large/zr1review_16.jpg',					
					];
					
	// var carDetails = ['car1','Chevrolet Corvette ZR1',2009,'450,000','Coupe','Red','Gray',1,'00000009113300157','Gasoline','3.0L 6 Cylinder','5-Speed Manual',2,'The Honorable Charles W. Anderson (Dear Mr. Ambassador:), Department of State, 2050 Bamako Place, Washington, DC 20521-2050',0,0,'Honda of Princeton','866-649-7910'];
	
	
	
	
				  
	    var ad1 = ['images/ads/ad-v1.jpg','images/ads/ad-v2.jpg','images/ads/ad-v3.jpg','images/ads/ad-v4.jpg','images/ads/ad-v5.jpg','images/ads/ad-v6.jpg','images/ads/ad-v7.jpg','images/ads/ad-v8.jpg','images/ads/ad-v9.jpg','images/ads/ad-v10.jpg'];
	
	var ad2 = ['images/ads/ad-h1.jpg','images/ads/ad-h2.jpg','images/ads/ad-h3.jpg','images/ads/ad-h4.jpg','images/ads/ad-h5.jpg','images/ads/ad-h6.jpg','images/ads/ad-h7.jpg'];
					  
	var ad1left = ['images/ads/ads-l1.jpg','images/ads/ads-l2.jpg','images/ads/ads-l3.jpg'];
	
	 // lBrandAds
		if(ad1left.length>0){
			var img = '';
			var imgPath = ad1left[Math.floor(Math.random() * ad1left.length)];			
			img += "<img src='"+imgPath+"' width='180' />";
			$('#lBrandAds').empty();
			$('#lBrandAds').append(img);
		};
				 
	$(function() {
		$("div.svwp").prepend("<img src='images/svwloader.gif' class='ldrgif' alt='loading...'/ >");
		
		// Vertical Ticker
		
		
		
		$('.sample4').numeric();
        //$('.sample5').numeric({allow:"."});
        //$('.sample1').alphanumeric();	
		
		
		$('#make, #model, #within, #makeA, #modelA, #withinA, #makeB, #modelB, #withinB').empty();
		$('#yourZip, #yourZipA, #yourZipB').val('');
		
		$('#model, #modelA, #modelB').attr('disabled',true);
		
		
	
	
		$("li input[type=checkbox]").click(function() {
			
			if ($(this).is (':checked')){
				$(this).parent().css('color','#ffb619').css('font-weight','bold');
			}else{
				$(this).parent().css('color','#333').css('font-weight','normal');				
			}			
			// $(this).parent().toggleClass('li-hover');
		});
		
		
		
		
	
				
		
		
		
		
		
		// lBrandAds
		/*
		if(ad1.length>0){
			var img = '';
			var imgPath = leftAd[Math.floor(Math.random() * leftAd.length)];			
			img += "<img src='"+imgPath+"' />";
			$('#lBrandAds').empty();
			$('#lBrandAds').append(img);
		};
		*/
		
		 
		
	});	
		
		
    </script>

    <script type="text/javascript">
        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-28766349-1']);
        _gaq.push(['_trackPageview']);
        (function() {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();
    </script>

</body>
</html>
