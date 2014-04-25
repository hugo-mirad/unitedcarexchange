<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="Dealer_Usercontrol_Header" %>


<!--[if lt IE 9]>
    <div style=' clear: both; text-align:center; position: relative;'>
        <a href="http://windows.microsoft.com/en-US/internet-explorer/products/ie/home?ocid=ie6_countdown_bannercode">
        	<img src="http://storage.ie6countdown.com/assets/100/images/banners/warning_bar_0000_us.jpg" border="0" height="42" width="820" alt="You are using an outdated browser. For a faster, safer browsing experience, upgrade for free today." />
        </a>
    </div>
    <![endif]-->
<link href='http://fonts.googleapis.com/css?family=Gabriela' rel='stylesheet' type='text/css'>
<div class="head">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: auto; text-align: left; padding-left: 10px">
                <a href="home.aspx">
                    <asp:Image runat="server"  ID="imgLogo" class="logoImg" onerror="loadLogo();" style="height:32px; width:auto; margin:3px 0 0 10px" />
                    <asp:Label ID="dealerLogo" runat="server" Style=""></asp:Label>
                </a>
            </td>
            <td style="text-align: left; position: relative;">
                <table style="text-align: left; width: 600px; float: left; position: relative;" class="searchBlock-Holder">
                    <tr>
                        <td style="text-align: left">
                            <table class="searchBlock">
                                <tr>
                                    <td>
                                        <input type="text" class="input1 search" id="txtMainSearch" maxlength="50" />
                                    </td>
                                    <td width="90">
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="100" style="text-align: left">
                            <input type="button" value="Search" onclick="javascript:inventoryIdSearch();" id="mainSearch"
                                class="g-button g-button-submit" />
                        </td>
                    </tr>
                </table>
            </td>
            <td style="text-align: right; padding-right: 10px;">
                <table >
                    <tr>
                        <td>
                            <asp:Label ID="lblDealerID1" runat="server"></asp:Label>
                        </td>
                        <td style="width: 13px;">
                            <span class="userPic">&nbsp; </span>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
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
<!-- Processiong Popup End -->
<!-- Logout Popup  Start  -->
<div class="logOutHolder">
    <span class="UpArrow"></span>
    <div class="profile">
        <table>
            <tr>
                <td style="width: 96px;">
                    <asp:Image ID="lblImage" runat="server" class="popupPic" />
                </td>
                <td style="padding-left: 15px; text-align: left;">
                    <h1 class="name">
                        <asp:Label ID="lblDealerID" runat="server"></asp:Label>
                    </h1>
                    <h4>
                        <asp:Label ID="lblDealerID2" runat="server"></asp:Label>
                    </h4>
                    Dealer code:
                    <asp:Label ID="lblDealerCode" runat="server"></asp:Label><br />
                    <br />
                    <span class="delAddress">
                        <asp:Label ID="lblDealerAddress" runat="server"></asp:Label><br />
                        <asp:Label ID="City" runat="server"></asp:Label><br />
                        <br />
                        <a href="javascript:alert('Please contact your administrator for enabling this feature.')">Billing Info</a>
                </td>
            </tr>
        </table>
    </div>
    <div class="actions">
        <asp:Button ID="btnManageAccount" Text="Manage Account" class="g-button left" 
            runat="server" onclick="btnManageAccount_Click" />
        <asp:Button ID="BtnSignout" runat="server" Text="Sign out" class="g-button right"
            OnClick="BtnSignout_Click" />
        <div class="clear">
            &nbsp;</div>
    </div>
</div>
<!-- Logout Popup End  -->
<!-- Advanced Search Popup Start  -->
<div class="adSearch">
    <a href="#" class="close"></a>
    <table class="searchFields">
        <tr>
            <td>
                <h4>
                    Make</h4>
                <select id="make">
                    <option value="0">All makes</option>
                </select>
            </td>
        </tr>
        <tr>
            <td>
                <h4>
                    Model</h4>
                <select id="model" disabled="disabled">
                    <option value="0">All models</option>
                </select>
            </td>
        </tr>
        <tr>
            <td>
                <h4>
                    Year</h4>
                <select id="year" class="mySel" disabled="disabled">
                    <option>Select</option>
                    <option>2013</option>
                    <option>2012</option>
                </select>
            </td>
        </tr>
        <tr>
            <td>
                <h4>
                    VehicleType Trim</h4>
                <input type="text" class="input1" id="vTrim" />
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td style="width: 48%">
                            <h4>
                                Price range</h4>
                            <select id="priceRange">
                                <option value="ASC">Low to high</option>
                                <option value="DESC">High to low</option>
                            </select>
                        </td>
                        <td width="4%">
                            &nbsp;
                        </td>
                        <td>
                            <h4>
                                Margin range</h4>
                            <select id="marginRange">
                                <option value="ASC">Low to high</option>
                                <option value="DESC">High to low</option>
                            </select>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td style="width: 48%">
                            <h4>
                                # of days active</h4>
                            <select id="numOfDays">
                                <option value="1">1 Day</option>
                                <option value="3">3 Days</option>
                                <option value="7">1 Week</option>
                                <option value="14">2 Weeks</option>
                                <option value="30">1 Month</option>
                                <option value="60">2 Months</option>
                                <option value="180">6 Months</option>
                                <option value="364">1 year</option>
                            </select>
                        </td>
                        <td width="4%">
                            &nbsp;
                        </td>
                        <td>
                            <h4>
                                Status</h4>
                            <select id="status">
                                <option value="1">Active</option>
                                <option value="0">Inactive</option>
                            </select>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td style="padding-top: 10px;">
                <input id="search" type="button" value="Search" class="g-button g-button-submit" />
            </td>
        </tr>
    </table>
</div>
<!-- Advanced Search Popup End  -->
<style type="text/css">
    #Header1_dealerLogo
    {
        font-size: 20px;
        color: #232323;
        text-shadow: 0 0 3px rgba(0,0,0,0.1);
        font-weight: bold;
        font-family: 'Gabriela' , serif;
        display: none;
        text-decoration: none;
        text-transform: capitalize;
        line-height: 40px;
    }
    .head a
    {
        text-decoration: none;
    }
</style>

<script type="text/javascript" language="javascript">
    $(function() {
    $('#Header1_imgLogo').hide();
        KeyListener.init();
    })
    function loadLogo() {
        $('.logoImg').hide();
        $('#Header1_dealerLogo').show();        
    }
    function KeyDownHandler(btn) {
        if (event.keyCode == 13) {
            event.returnValue = false;
            //event.cancel = true;
            //btn.click();
        }
    }


    KeyListener = {
        init: function() {
            $('.searchBlock-Holder').bind('keypress', function(e) {
                var key = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
                var target = e.target.tagName.toLowerCase();
                if (key === 13 && target === 'input') {
                    e.preventDefault();
                    var button = $('#mainSearch');
                    if (button.length > 0) {
                        if (typeof (button.get(0).onclick) == 'function') {
                            inventoryIdSearch();
                        } else if (button.attr('href')) {
                            window.location = button.attr('href');
                        } else {
                            inventoryIdSearch();
                        }
                    }

                }

            });
        }
    };

                    
                    
</script>

