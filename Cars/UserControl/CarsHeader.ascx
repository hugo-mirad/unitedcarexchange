<script type="text/javascript" language="javascript"  >

    $(window).load(function() {
    $(function() {
        $('.default-value').each(function() {
            var default_value = this.value;
            $(this).css('color', '#999')
            $(this).focus(function() {
                $(this).css('color', '#333')
                if (this.value == default_value) {
                    this.value = '';
                    $(this).css('color', '#333')
                } else { $(this).css('color', '#333') }
            });
            $(this).blur(function() {
                if (this.value == '') {
                    this.value = default_value;
                    $(this).css('color', '#999')
                } else { $(this).css('color', '#333') }
            });
        });
    })
});   


</script>


<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CarsHeader.ascx.cs" Inherits="UserControl_CarsHeader" %>
<ul>
    <li>
        <asp:LinkButton ID="lnkbtnHome" runat="server" PostBackUrl="http://UnitedCarExchange.com/Default.aspx" Text="Home"></asp:LinkButton>
    </li>
    <li>
        <asp:LinkButton ID="lnkbtnUsedcars" runat="server" PostBackUrl="http://UnitedCarExchange.com/UsedCars.aspx"
            Text="Used Cars"></asp:LinkButton>
    </li>
    <li>
        <asp:LinkButton ID="lnkbtnNewCars" runat="server" PostBackUrl="http://UnitedCarExchange.com/NewCars.aspx" Text="New Cars"></asp:LinkButton>
    </li>
    <li class="last">
        <asp:LinkButton ID="lnkbtnSellACar" runat="server" PostBackUrl="http://UnitedCarExchange.com/Packages.aspx"
            Text="Sell A Car"></asp:LinkButton>
        <ul>
            <li><a href="http://UnitedCarExchange.com/Packages.aspx">Private Seller</a></li>
            <li><a href="http://UnitedCarExchange.com/Dealer.aspx">Dealer</a></li>
        </ul>
    </li>
</ul>
<%--<a href="https://itunes.apple.com/us/app/uce-car-finder/id675061949?ls=1&amp;mt=8" target="_blank" >
<img src="http://ucecarfinder.unitedcarexchange.com/images/Download_on_the_App_Store_Badge_US-UK_135x40.png" style="float: right; width: auto; height: 23px; margin: 5px; "/>
</a>

<a href="https://play.google.com/store/apps/details?id=com.unitedcars.home" target="_blank" >
<img src="http://ucecarfinder.unitedcarexchange.com/images/google_play_en.png" style="float: right; margin: 5px 0; height: 23px; width: auto;" />
</a>--%>

<a href="#" target="_blank" >
<img src="http://ucecarfinder.unitedcarexchange.com/images/Download_on_the_App_Store_Badge_US-UK_135x40.png" style="float: right; width: auto; height: 23px; margin: 5px; "/>
</a>

<a href="https://play.google.com/store/apps/details?id=com.unitedcars.home" target="_blank" >
<img src="http://ucecarfinder.unitedcarexchange.com/images/google_play_en.png" style="float: right; margin: 5px 0; height: 23px; width: auto;" />
</a>