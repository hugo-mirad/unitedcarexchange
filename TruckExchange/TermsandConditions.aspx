<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TermsandConditions.aspx.cs"
    Inherits="TermsandConditions" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/TruckLogin.ascx" TagName="TruckLogin" TagPrefix="uc1" %>
<%@ Register Src="UserControl/TruckHeader.ascx" TagName="TruckHeader" TagPrefix="uc2" %>
<%@ Register Src="UserControl/TruckFooter.ascx" TagName="TruckFooter" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title id="Title1" runat="server"></title>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic' rel='stylesheet'
        type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:800' rel='stylesheet'
        type='text/css'>
    <link rel="stylesheet" type="text/css" href="css/demo.css" />
    <link href="css/page1.css" rel="stylesheet" type="text/css" />
    <link href="css/layout.css" rel="stylesheet" type="text/css" />
    <link href="css/searchBlock.css" rel="stylesheet" type="text/css" />
    <link href="css/PaginationStyle.css" rel="stylesheet" type="text/css" />
    <link href="css/gallery.css" rel="stylesheet" type="text/css" />

    <script src="js/FillMasterData.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/jquery-1.7.min.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>
   <script type="text/javascript">
       function pageLoad() {
           GetRecentListings();
       }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    <!-- Main Start  -->
    <div class="main">
        <!-- head1 start  -->
        <div class="hed1">
            <table style="width: 100%;" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="middle">
                        <a href="http://UnitedTruckExchange.com/">
                            <img src="images/logo.png" class="logo" /></a>
                    </td>
                    <td valign="top">
                        <uc1:TruckLogin ID="TruckLogin1" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <!-- head1 End  -->
        <div class="clear">
            &nbsp;</div>
        <!-- Menu Start  -->
        <div class="menu">
            <uc2:TruckHeader ID="TruckHeader1" runat="server" />
        </div>
        <!-- Menu End  -->
        <div class="clear">
            &nbsp;</div>
        <table style="width: 100%; position: relative; border-collapse: collapse; margin-bottom: 20px;"
            cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 270px; background: #eee; vertical-align: top; padding: 0 5px 5px 5px">
                    <div class="leftBox1">
                    <h2 style="margin-bottom: 5px; padding-bottom: 0px; color: #555; font-size: 16px;">
                        Recent Used Truck Listings</h2><small><e style="font-size:11px;">Most recent Used Trucks listed for sale</e></small>
                    <!-- Left Brand Ads Satrt -->
                    <div class="ticker1">
                        <ul></ul>
                    </div>
                    <div class="clear">
                        &nbsp;</div>
                    </div>
                    <!-- End: adBrite -->
                    <div class="clear">
                        &nbsp;</div>
                </td>
                <td style="vertical-align: top; padding-left: 10px;">
                    <!-- Right Content Start  -->
                    <!-- Login Page Start  DINESH----------------------------------------------------------------------------------------------------------------------->
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
                                    UnitedTruckExchange.com and its' affiliated websites' "sell your vehicle", "sell
                                    your truck" or similar services. By placing an order for any ad appearing through
                                    the Sell Your Truck or similar service, you accept and are bound by these terms
                                    and conditions. If you do not wish to be bound by these terms and conditions, you
                                    should not place an order for an ad through this service.</p>
                                <p class="style1">
                                    <h3 class="border1">
                                        1. General Rules</h3>
                                    <b>1.1</b> Sell Your Truck ads are available only to private sellers who want to
                                    list their personally owned vehicle(s) for sale. UnitedTruckExchange.com and its
                                    affiliates reserve the right (but assume no obligation) to delete, move, or edit
                                    (without refund) any ads or posting(s) that come to our attention that we consider
                                    unacceptable or inappropriate, whether for legal or other reasons.<br />
                                    <br />
                                    <b>1.2</b> You may not list more than five (5) vehicles simultaneously through the
                                    Sell Your Truck service. Individuals who seek to list more than five (5) vehicles
                                    on the UnitedTruckExchange.com website simultaneously, as well as all dealers, brokers,
                                    businesses or persons otherwise engaged in the commercial sale of vehicles or offering
                                    vehicles for sale as a paid service to a seller or title holder, must make other
                                    arrangements with us and our affiliates to place such commercial ads. Please visit
                                    our UnitedTruckExchange.com Dealer page to find out more about dealer listings and
                                    advertising opportunities on UnitedTruckExchange.com and our affiliated products
                                    and services.<br />
                                    <br />
                                    <b>1.3</b> By using the Sell Your Truck service, you represent that you are at least
                                    eighteen (18) years old. You also represent that you are not a motor vehicle dealer,
                                    broker, business or person otherwise engaged in the commercial sale of vehicles.
                                    You further represent that you are not offering vehicles for sale as a paid service
                                    to a seller or title holder of a vehicle, and that you are not listing a vehicle
                                    for sale in your capacity as an employee or representative of a dealer, broker,
                                    business or person otherwise engaged in the commercial sale of vehicles. Likewise,
                                    you represent that you are not acting as a broker or agent for a private seller
                                    that placed an ad through the Sell Your Truck service. Additionally, you represent
                                    that neither you nor anyone acting on your behalf will list more than five (5) vehicles
                                    for sale simultaneously through the Sell Your Truck service.<br />
                                    <br />
                                    <b>1.4</b> UnitedTruckExchange.com and its affiliates reserve the right to deny
                                    use of their respective online and offline products and services, which includes
                                    this website, to anyone who does not comply with these Terms of Sale or who otherwise
                                    use such online and/or offline products or services, including this website, in
                                    a manner we consider inappropriate.<br />
                                    <br />
                                    <b>1.5</b> Our used truck listings include vehicles that have been &quot;certified&quot;
                                    as meeting certain standards established by manufacturers and/or dealers in connection
                                    with their pre-owned vehicle programs.&nbsp; Ads purchased by private sellers through
                                    the Sell Your Truck service will not appear in any &quot;certified&quot; area of
                                    our website or any similar area within our affiliated products and services.&nbsp;
                                    Our &quot;certified&quot; ads apply only to vehicles certified by the automobile
                                    manufacturers and/or dealers with which we have partnerships.</p>
                                <p class="style1">
                                    <br />
                                    <h3 class="border1">
                                        2.Using the &quot;Sell Your Truck&quot; Service</h3>
                                    <b>2.1</b> When you offer a vehicle for sale through the Sell Your Truck service,
                                    you must be prepared to sell that vehicle at the price at which, and the terms on
                                    which, you've listed it. You must have possession of the actual vehicle listed and
                                    the ability to transfer title.<br />
                                    <br />
                                    <b>2.2</b> To list a vehicle for sale through the Sell Your Truck service, you are
                                    required to provide certain identifying and contact information. The information
                                    in your ad must accurately identify you and the method of contact must permit buyers
                                    to communicate directly with you; you may not include in your ad the name, telephone
                                    number or email address of any agent, broker or dealer. Only your personal contact
                                    information may appear in your ad.<br />
                                    <br />
                                    <b>2.3</b> You may not charge any potential buyer for information about any vehicle
                                    listed for sale on UnitedTruckExchange.com, nor may you use our website to promote,
                                    without our prior written permission, any other website, product or service. Any
                                    rights and obligations you maintain under these Terms of Sale to access and use
                                    the Sell Your Truck service are personal to you. Consequently, you may not assign
                                    or delegate any such rights or obligations to any third party, which includes agents,
                                    brokers or dealers.<br />
                                    <br />
                                    <b>2.4</b> Ad(s) placed through the Sell Your Truck service may not be used to advertise
                                    more than one (1) vehicle per ad purchased, regardless of the type of advertising
                                    package you select or the duration of its publication. For this reason, you may
                                    not edit your vehicle's Year, Make, Model and VIN once you purchase your ad. Always
                                    double-check this information before submitting your ad. If you believe you made
                                    an error while submitting your vehicle's Year, Make, Model or VIN, you must promptly
                                    contact UnitedTruckExchange.com customer support.<br />
                                    <br />
                                    <b>2.5</b> Responsibility for the information contained in your ad lies with you,
                                    the seller. You alone are responsible for material you post online, and for the
                                    content of all text messages transmitted through the online portions of the Sell
                                    Your Truck service.</p>
                                <p class="style1">
                                    <br />
                                    <h3 class="border1">
                                        3.Quality Assurance</h3>
                                    <b>3.1</b> Though we can't monitor every transaction that originates on or takes
                                    place through the Sell Your Truck service, we may perform random quality assurance
                                    tests to confirm that those who offer vehicles for sale through the Sell Your Truck
                                    service are prepared to sell the vehicles they advertise at the prices at which,
                                    and the terms on which, they advertise them.<br />
                                    <br />
                                    <b>3.2</b> Photos submitted as part of any ad placed through the Sell Your Truck
                                    service must correspond to the actual vehicle being offering for sale. As part of
                                    our random quality assurance tests, if we encounter a photo that we believe does
                                    not accurately represent the actual vehicle you are offering for sale through the
                                    Sell Your Truck service, we maintain the right to immediately remove such photo(s)
                                    and/or your corresponding ad. If you believe your photo(s) and/or your corresponding
                                    ad was removed in error, you must promptly contact one of our customer service representatives.<br />
                                    <br />
                                    <b>3.3</b> By using the Sell Your Truck service, you agree to cooperate in these
                                    random quality assurance tests. If our tests reveal, or we otherwise learn, that
                                    you are engaging in &quot;bait and switch&quot; or other unfair or deceptive practices,
                                    UnitedTruckExchange.com and/or its affiliates reserve the right to deny you use
                                    of the Sell Your Truck service.<br />
                                    <br />
                                    <b>3.4</b> In connection with our efforts to combat fraud, some ads may be screened
                                    before being posted publicly. This process may delay display of your ad listing(s)
                                    for up to 24 hours from the time we accept your ad. If your ad does not appear on
                                    UnitedTruckExchange.com after 24 hours, you must promptly contact one of our customer
                                    service representatives.<br />
                                    <br />
                                    <b>3.5</b> Although UnitedTruckExchange.com cannot monitor all the ads processed
                                    through the Sell Your Truck service, we reserve the right (but assume no obligation)
                                    to delete, move, or edit (without refund) any ads, postings or other electronic
                                    communications that come to our attention that we consider unacceptable or inappropriate,
                                    whether for legal or other reasons.<br />
                                    <br />
                                    <b>3.6</b> By placing ads through the Sell Your Truck service you agree not to post
                                    or transmit any defamatory, abusive, obscene, threatening, misleading, or illegal
                                    material, or any other material that infringes on the rights of others or interferes
                                    with the ability of others to enjoy UnitedTruckExchange.com or our affiliated products
                                    and services. UnitedTruckExchange.com and our affiliates retain the right to deny
                                    access to anyone who we believe has violated these Terms of Sale, which includes
                                    our Visitor Agreement.<br />
                                    <br />
                                    <b>3.7</b> Except as otherwise provided under these Terms of Sale, which include
                                    our Visitor Agreement, UnitedTruckExchange.com and our affiliates will not, in the
                                    ordinary course of business, review the content of private electronic messages that
                                    are not addressed to UnitedTruckExchange.com or any of our affiliates. However,
                                    UnitedTruckExchange.com and our affiliates may occasionally release information
                                    concerning such communications when release is appropriate to comply with law (including
                                    disclosure in response to a request from a law enforcement agency), to enforce these
                                    Terms of Sale, which includes our Visitor Agreement, or to protect the rights, property
                                    or safety of visitors to our site, our advertisers, our affiliates, the public or
                                    UnitedTruckExchange.com.</p>
                                <p class="style1">
                                    <br />
                                    <h3 class="border1">
                                        4. Fees, Payments and Refunds. Premiums, Promotions and Free Services</h3>
                                    <b>4.1</b> By placing an ad through the Sell Your Truck service, you agree to pay
                                    all fees and charges incurred at the rates in effect for the billing period covering
                                    the advertising package(s) you obtain, regardless of whether your vehicle sells
                                    as a result of the ad package(s) you purchase. All fees and charges will be applied
                                    against the form of payment you provide as part of the ad selection process and
                                    you agree to pay such fees and charges. You also agree to pay any applicable taxes
                                    relating to your use of the Sell Your Truck service. At its sole discretion, UnitedTruckExchange.com
                                    reserves the right at any time to offer the Sell Your Truck service at a discount
                                    or to provide premiums and promotions as incentives, up to and including free Sell
                                    Your Truck Services<br />
                                    <br />
                                    <b>4.2</b> Should UnitedTruckExchange.com offer Sell Your Truck ads at no charge
                                    on our website and/or via our call center(s), we may, at our sole discretion, offer
                                    these ads nationally, in a limited number of markets, to a limited number of advertisers,
                                    or for a limited period of time. When you list a Truck for sale using any free Sell
                                    Your Truck advertising service that we may offer, you will be asked for information
                                    on the Truck you are selling and on how you can be contacted by potential buyers.
                                    We may also ask you for other personally identifying information for security purposes.
                                    We may use this information to contact you about your listing, or for marketing
                                    and other promotional purposes, including offers of additional paid ad services.
                                    By placing a free Sell Your Truck ad on UnitedTruckExchange.com you agree to be
                                    contacted by us about your listing, or for marketing and other promotional purposes,
                                    via any of the contact methods that you supply, including telephone, email and snail
                                    mail. We may also share, or sell, the contact information you provide with companies
                                    who advertise on our website, or who otherwise compensate us for this information,
                                    including vehicle manufacturers. If you do not wish to share your email address
                                    or other contact information with either UnitedTruckExchange.com or our advertisers
                                    for the purpose of receiving marketing and promotional offers, you should not use
                                    our free Sell Your Truck service.<br />
                                    <br />
                                    <b>4.3</b> You must use care when selecting your ad package and inputting your ad
                                    information; listing fees are generally not refundable, even if you provide erroneous
                                    information or fail to sell your vehicle. Since you place the order for &quot;online
                                    only&quot; ads through the Sell Your Truck service, UnitedTruckExchange.com and
                                    its affiliates cannot be responsible for your ad listing errors and, therefore,
                                    we cannot offer refunds on any fees or charges to list your ad(s).<br />
                                    <br />
                                    <b>4.4</b> Except as provided under Section 4.5, below, UnitedTruckExchange.com
                                    and its affiliates will not provide any refund for any reason if UnitedTruckExchange.com
                                    or one of its affiliates receives the request for refund after your ad is published
                                    on this website.&nbsp; However, UnitedTruckExchange.com will reasonably assist you
                                    to correct certain mistakes made by you in placing your ad (for example, Year, Make,
                                    Model, or VIN).<br />
                                    <b>4.5</b> UnitedTruckExchange.com will provide you a refund or credit only for
                                    the reasons identified in Subsection 4.5.1 through 4.5.3, below:<br />
                                    <br />
                                    <b>4.5.1</b> You may be entitled to a refund or credit if your ad has not been posted
                                    on this website within the first 72 hours from the time we accept your order for
                                    an ad. In that case, you must immediately contact UnitedTruckExchange.com customer
                                    service to request a refund or credit. <u>You may not request, and we will not issue,
                                        a cancellation and refund or credit due to non-publication of your ad within the
                                        first 24 hours, starting from the time we accept your order for an ad, which includes
                                        the time you take to post your vehicle's photo within the Sell Your Truck service;
                                        you agree that UnitedTruckExchange.com will maintain at least 24 hours to fully
                                        process your entire ad listing through the Sell Your Truck service, which includes
                                        clearing your ad listing through the Sell Your Truck service's anti-fraud filters</u>.
                                    Please note that our office is not open during weekends and statutory holidays;
                                    weekends, evenings, nights and statutory holidays do not count toward the time limits
                                    specified here.<br />
                                    <br />
                                    <b>4.5.2</b> You may be entitled to a refund or credit if you mistakenly order and
                                    pay for duplicate ads through the Sell Your Truck service and seek to cancel and
                                    obtain a refund or credit on the duplicate ad only. You are not entitled and we
                                    cannot provide you a refund or credit on the original ad listing.<br />
                                    <br />
                                    <b>4.5.3</b> You will be entitled to a refund with respect to an ad with the Money-Back
                                    Guarantee feature under the following circumstances:&nbsp; (i) your ad with the
                                    Money-Back Guarantee feature has run on UnitedTruckExchange.com for a period of
                                    at least 90 consecutive days from the date UnitedTruckExchange.com completed processing
                                    of your ad as described in Section 4.5.1 above; (ii) you fully complete and submit
                                    to us a refund request form, available from the UnitedTruckExchange.com website,
                                    which is postmarked 91-105 days after placing the ad; (iii) at the time you submit
                                    your refund request form, the vehicle advertised in your ad with the Money-Back
                                    Guarantee feature is still for sale by you and the title to the vehicle is held
                                    by you or by a lien holder on your behalf; (iv) once we receive your refund request
                                    form, we will review your request to determine, in our sole discretion, whether
                                    you have complied with all terms and conditions; (v) if we determine that you have
                                    satisfied all the terms and conditions, we will refund the profiling fees you paid
                                    subject to a deduction of listing and administrative fee of $100.00. The money will
                                    be refunded using the same method of payment you used to purchase the ad; and (vi)
                                    after we process your refund, your ad will be removed from the UnitedTruckExchange.com
                                    site.<br />
                                    <br />
                                    <b>4.6</b> Except as provided under Subsections 4.5.1 through 4.5.3, above, UnitedTruckExchange.com
                                    and its affiliates cannot provide a refund or credit for any other reason, even
                                    if you contact us within 72 hours from the time we accept your order for an ad.
                                    For example, we cannot provide you a refund or credit if you change your mind about
                                    publishing your ad, its content or any enhancements you purchased in relation to
                                    your ad selection. You are not entitled to a refund or credit if you wish to change
                                    to a less expensive ad package. We cannot provide you a refund or credit if you
                                    made mistakes while submitting your ad information or if you fail to receive any
                                    inquiries or offers to purchase your vehicle through the use of the Sell Your Truck
                                    service. No refund or credit will be issued if you sold your vehicle through other
                                    means. Likewise, you are not entitled to a refund or credit if you place an ad on
                                    the Sell Your Truck service through a third party source (for example, newspapers
                                    or third party websites) and you also place a similar or identical ad directly with
                                    UnitedTruckExchange.com. Such ads are not considered &quot;duplicates&quot; and
                                    you will not be entitled to cancel any such ads nor will you be entitled to a refund
                                    or credit of any fees or charges associated with any such ads.<br />
                                    <br />
                                    <b>4.7</b> Except as provided under Subsections 4.5.1 through 4.5.3, while UnitedTruckExchange.com
                                    and its affiliates cannot provide you a refund or credit in cases where we have
                                    made mistakes in the connection with the publication of your ad(s), UnitedTruckExchange.com
                                    will use reasonable efforts to correct any mistakes we might have made in placing
                                    your ad; provided, that you contact UnitedTruckExchange.com customer support within
                                    the first 72 hours from the time we accept your order for an ad.<br />
                                    <br />
                                    <b>4.8</b> If you make a mistake while submitting an ad through the Sell Your Truck
                                    service, we will use reasonable efforts to make corrections (i.e., ads we reasonably
                                    determine are duplicative, or contain erroneous ad information). You may incur an
                                    added charge if you wish to order enhancements to your initial ad order. If your
                                    ad on UnitedTruckExchange.com was purchased through a third party source (for example,
                                    a newspaper or third party website), we do not have the authority to make any changes
                                    to your ad and we cannot provide you a credit or refund for such ads.</p>
                                <p class="style1">
                                    <br />
                                    <h3 class="border1">
                                        5.Added Value Services</h3>
                                    <b>5.1</b> When you list a vehicle for sale through the Sell Your Truck service,
                                    we may obtain additional distribution for your ad listing through our relationships
                                    with other websites. At this time, neither UnitedTruckExchange.com nor any website
                                    through which we distribute your listing will charge you any additional fee for
                                    this additional exposure. It's just added value from UnitedTruckExchange.com.</p>
                                <p class="style1">
                                    <br />
                                    <h3 class="border1">
                                        6.Ads with &quot;Run 'til It Sells&quot; Feature</h3>
                                    <b>6.1</b> Subject to these Terms of Sale, ads which can be purchased through the
                                    Sell Your Truck service and which include a &quot;Run 'til It Sells&quot; feature
                                    may not be published or available for publication through the Sell Your Truck service
                                    for a period greater than 365 consecutive days in the aggregate.<br />
                                    <br />
                                    <b>6.2</b>In all cases, your right to publish each Run'til It Sells ad will expire,
                                    and such ad will be removed from our website and our other affiliated services on
                                    the 365th day from the date you placed your original order for such ad through this
                                    website.&nbsp; To extend the publication of a Run 'til It Sells ad beyond its 365
                                    day lifespan, you must contact UnitedTruckExchange.com customer support. UnitedTruckExchange.com
                                    and/or its affiliates may require that you provide additional information about
                                    your vehicle in order determine whether an extension will be granted.&nbsp; Additionally,
                                    UnitedTruckExchange.com and its affiliates may require that you remit an additional
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
                                    AND SERVICES ARE PROVIDED TO YOU &quot;AS IS.&quot; UnitedTruckExchange.com AND
                                    ITS AFFILIATES, AGENTS AND LICENSORS CANNOT AND DO NOT WARRANT THE ACCURACY, COMPLETENESS,
                                    CURRENTNESS, NONINFRINGEMENT, MERCHANTABILITY OR FITNESS FOR A PARTICULAR PURPOSE
                                    OF THE INFORMATION AVAILABLE THROUGH THIS WEBSITE OR ANY AFFILIATED PRODUCT OR SERVICE
                                    (OR ANY INFORMATION, GOODS OR SERVICES THAT ARE REFERRED TO, ADVERTISED OR PROMOTED
                                    ON, OR SOLD THROUGH THIS WEBSITE). NOR DO WE OR THEY GUARANTEE THAT THE WEBSITE
                                    AND/OR ANY AFFILIATED PRODUCT OR SERVICE WILL BE ERROR FREE, OR CONTINUOUSLY AVAILABLE,
                                    OR THAT THE WEBSITE WILL BE FREE OF VIRUSES OR OTHER HARMFUL COMPONENTS.<br />
                                    <br />
                                    <b>7.2</b> UNDER NO CIRCUMSTANCES WILL UnitedTruckExchange.com OR ITS AFFILIATES,
                                    AGENTS OR LICENSORS BE LIABLE TO YOU OR ANYONE ELSE FOR ANY DAMAGES OTHER THAN DIRECT
                                    DAMAGES, ARISING OUT OF YOUR USE OF THIS WEBSITE OR ANY AFFILIATED PRODUCT OR SERVICE
                                    ASSOCIATED WITH OR OTHERWISE LINKED TO OR FROM THIS WEBSITE, OR ADVERTISED OR PROMOTED
                                    ON THIS WEBSITE, INCLUDING, WITHOUT LIMITATION, CONSEQUENTIAL, SPECIAL, INCIDENTAL,
                                    INDIRECT, PUNITIVE, EXEMPLARY, OR OTHER DAMAGES OF ANY KIND (INCLUDING LOST REVENUES
                                    OR PROFITS, LOSS OF BUSINESS OR LOSS OF DATA), EVEN IF WE ARE ADVISED BEFOREHAND
                                    OF THE POSSIBILITY OF SUCH DAMAGES. YOU AGREE THAT THE LIABILITY OF UnitedTruckExchange.com
                                    AND ITS AFFILIATES, AGENTS AND LICENSORS, IF ANY, ARISING OUT OF ANY KIND OF LEGAL
                                    CLAIM ARISING OUT OF OR OTHERWISE RELATED TO THIS WEBSITE, THE SELL YOUR TRUCK SERVICE,
                                    AND/OR ANY AFFILIATED PRODUCTS OR SERVICES WILL NOT EXCEED THE AMOUNT YOU PAID,
                                    IF ANY, FOR THE USE OF THE WEBSITE OR THE USE OF THE SELL YOUR TRUCK SERVICE, OUT
                                    OF WHICH SUCH LIABILITY ALLEGEDLY ARISES. BECAUSE SOME STATES/JURISDICTIONS DO NOT
                                    ALLOW THE EXCLUSION OR LIMITATION OF LIABILITY FOR CONSEQUENTIAL OR INCIDENTAL DAMAGES,
                                    SOME OF THESE LIMITATIONS MAY NOT APPLY TO YOU. YOU AGREE TO INDEMNIFY AND HOLD
                                    HARMLESS UnitedTruckExchange.com, ITS AFFILIATES, AND THEIR RESPECTIVE EMPLOYEES,
                                    OWNERS, REPRESENTATIVES, AND LICENSEES AGAINST ANY AND ALL CLAIMS, OF WHATEVER NATURE,
                                    THAT ARISE OUT OF ANY LISTING YOU PLACE OR ATTEMPT TO PLACE THROUGH THE SELL YOUR
                                    TRUCK SERVICE.</p>
                                <p class="style1">
                                    <br />
                                    <h3 class="border1">
                                        8. Miscellaneous</h3>
                                    <b>8.1</b> These Terms of Sale has been made in, and will be construed in accordance
                                    with the laws of, the State of New Jersey. By accessing this website and/or using
                                    the Sell Your Truck service, you consent to the exclusive jurisdiction and venue
                                    of the state and federal courts in Middlesex County, NJ in all disputes arising
                                    out of or relating to these Terms of Sale, the use of this website, which includes
                                    the use of the Sell Your Truck service.<a name="_GoBack" id="_GoBack"></a></p>
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                    </div>
                    <!-- Login Page End  DINESH----------------------------------------------------------------------------------------------------------------------->
                    <div class="clear">
                        &nbsp;</div>
                    <!-- Bottom Ads Start -->
                    <div class="bottomAdd " id="add730" style="width: 730px; margin: 10px 0; font-size: 11px;">
                        <!-- Begin: adBrite, Generated: 2012-05-09 5:52:57 -->
                        <!-- End: adBrite -->
                    </div>
                    <!-- Bottom Ads End  -->
                    <!-- Right Content End  -->
                </td>
            </tr>
        </table>
    </div>
    <!-- Footer Start  -->
    <div class="footer">
        <uc3:TruckFooter ID="TruckFooter1" runat="server" />
    </div>
    <!-- Footer End  -->
    <!-- Processiong Popup Start -->
    <div id="spinner" style="display: none;">
        <h4>
            <div>
                Processing
                <img src="images/loading.gif" />
            </div>
        </h4>
    </div>
    <!-- Processiong Popup End -->
    </form>

    <script type="text/javascript">
    
     
	$(function() {
	
		$('a').each(function(){
			if($(this).attr('href') == '#'){
				$(this).attr('href','javascript:void(0)')
			}
		});	 
		
	});	
    
    
   
    </script>

</body>
</html>
