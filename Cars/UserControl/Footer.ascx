<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Footer.ascx.cs" Inherits="UserControl_Footer" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!-- 

<script src="assets/js/jquery.js"></script>
<script src="assets/js/jquery-migrate-1.2.1.js"></script>
<script src="assets/js/jquery.ui.js"></script>
<script src="assets/js/bootstrap.js"></script>
<script src="assets/js/cycle.js"></script>
-->

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

<script type="text/javascript" language="javascript">
    TimerRunning = false;
    function validateSubScribe() {
        StopTimer();
        valid = true;

        var SelectedMake = $('.makeModelSel #row0 select:eq(0)').val();
        var SelectedModel = $('.makeModelSel #row0 select:eq(1)').val();

        if (SelectedMake == 0) {
            alert("Please select make ");
            $('makeModelSel #row0 select:eq(0)').focus();
            valid = false;
            return valid;
        }

        if (SelectedModel == 0) {
            alert("Please select model");
            $('makeModelSel #row0 select:eq(1)').focus();
            valid = false;
            return valid;
        }

        if ($('#Footer1_txtName').val().trim() == 'Your Name') {
            alert("Please enter your full name");
            $('#Footer1_txtName').focus();
            valid = false;
            return valid;
        }
        if ($('#Footer1_txtEmailAlert').val().trim() == 'Your Email') {
            alert("Please enter your email address to signup");
            $('#Footer1_txtEmailAlert').focus();
            valid = false;
            return valid;
        }
        if (($('#Footer1_txtEmailAlert').val().trim().length > 0) && (echeck($('#Footer1_txtEmailAlert').val().trim()) == false)) {
            document.getElementById('Footer1_txtEmailAlert').value = ""
            document.getElementById('Footer1_txtEmailAlert').focus()
            valid = false;
            return valid;

        }
        /*if ($('#Footer1_txtPhoneNo').val().trim().length < 10) {
        alert("Please valid phone no");
        $('#Footer1_txtPhoneNo').focus();
        valid = false;
        return valid;
        }
        if ($('#Footer1_txtZip').val().trim().length < 4) {
        alert("Please valid ZIP");
        $('#Footer1_txtZip').focus();
        valid = false;
        return valid;
        }*/

        if (valid) {

            var sName = $('#Footer1_txtName').val();
            var sEmail = $('#Footer1_txtEmailAlert').val();
            var sPhoneNo = $('#Footer1_txtPhoneNo').val();
            var sZip = $('#Footer1_txtZip').val();

            SubScribe(0, sZip, sName, sEmail, sPhoneNo);
        }

        //$find('Footer1_mpesubscribe').hide();
        showSpinner();
        //return valid;

    }


    // Saving Preference ....
    function savePref(sPrefernceID) {
        ////console.log('sPrefernceID:' + sPrefernceID);
        var visibleCount = 0; ;
        for (i = 0; i < 5; i++) {
            if ($('.makeModelSel #row' + i).is(':visible')) {
                visibleCount++;
            }
        }

        for (i = 0; i < 5; i++) {
            if ($('.makeModelSel #row' + i).is(':visible')) {
                var SelectedMake = $('.makeModelSel #row' + i + ' select:eq(0)').val();
                var SelectedModel = $('.makeModelSel #row' + i + ' select:eq(1)').val();
                var SelectedRange = $('.makeModelSel #row' + i + ' select:eq(2)').val();
                ////console.log(SelectedMake, SelectedModel, SelectedRange);
                visibleCount--;
                SubscribeItems(SelectedMake, SelectedModel, SelectedRange, sPrefernceID, 0, visibleCount);
                // SubscribeItems(SelectedMake, SelectedModel, SelectedRange, sPrefernceID, '');
            }
            if (i == 4) {
                hideSpinner();
                $find('Footer1_mpesubscribe').hide();


            }
        }
    }

    function prefSuccess() {

        $('#Footer1_lblAlertMsg').text('Thank you for signing up for automatic email alerts..')
        $find('Footer1_mpealert').show();

    }






    function StopTimer() {
        if (TimerRunning)
            clearTimeout(TimerID);
        TimerRunning = false;
    }

    function CancelShowSubScribe() {
        TimerRunning = true;

        //setTimeout(function() { $find('Footer1_mpesubscribe').show() }, 10000);

    }
</script>

<div class="container">
    <div class="row">
        <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12">
            <div class="block random-cars">
                <div class="title">
                    <h2>
                        Contact</h2>
                </div>
                <!-- /.title -->
                <div class="items">
                    <div class="teaser-item-wrapper" style="font-size: 13px;">
                        <div class="title">
                            <a href="#" style="font-size: 15px; font-weight: bold;">MobiCarz</a>
                        </div>
                        <!-- <b>Address:</b><br />  -->
                        400 S Warren St Trenton, NJ 08608, USA
                        <br />
                        <br />
                        <div class="title">
                            <b>Customer Service</b></div>
                        Phone: xxx-xxx-xxxx
                        <br />
                    </div>
                    <!-- /.teaser-item-wrapper -->
                    <div class=" emailSubscribe " style="display: none;">
                        <div class="title">
                            <h2 style="margin: 30px 0 10px 0;">
                                Subscribe to Newsletter</h2>
                        </div>
                        <!-- /.title -->
                        <div class="input-group">
                            <input type="email" class="form-control" placeholder="Your e-mail address">
                            <span class="input-group-btn">
                                <button class="btn btn-default" type="button">
                                    Submit</button><!-- /.btn -->
                            </span>
                            <!-- /.input-group-btn -->
                        </div>
                        <!-- /.input-group -->
                    </div>
                </div>
                <!-- /.items -->
            </div>
            <!-- /.block -->
        </div>
        <!-- /.col-md-4 -->
        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 ">
            <div class="block">
                <div class="title ">
                    <h2>
                        BUYING & SELLING</h2>
                </div>
                <!-- /.title -->
                <ul class=" footerNav">
                    <li><a href="http://www.mobicarz.com/Default.aspx">Home</a></li>
                    <li><a href="http://www.mobicarz.com/UsedCars.aspx">Used Cars</a></li>
                    <li><a href="http://www.mobicarz.com/NewCars.aspx">New Cars</a></li>
                    <li><a href="http://www.mobicarz.com/Packages.aspx">Sell A Car</a></li>
                    <li><a href="http://www.mobicarz.com/Dealer.aspx">Car Dealers</a></li>
                    <%--<li><a href="ContactUs.aspx">Contact Us</a></li>--%>
                    <li><a href="http://www.mobicarz.com/Finance.aspx">Finance</a></li>
                    <li><a href="http://www.mobicarz.com/HowItWorks.aspx">How It Works</a></li>
                    <li><a href="http://www.mobicarz.com/Testimonials.aspx">Testimonials</a></li>
                    <li><a href="http://www.mobicarz.com/TermsandConditions.aspx">T&amp;C</a></li>
                    <%-- <li><a href="http://www.mobicarz.com/ReturnPolicy.aspx">Return Policy</a></li>
                    <li><a href="http://www.mobicarz.com/MONEY BACK FORM.pdf" target="_blank">Money Back
                        Form</a></li>--%>
                </ul>
            </div>
            <!-- /.block -->
        </div>
        <!-- /.col-md-4 -->
    </div>
    <!-- /.row -->
</div>
<!-- /.container -->
<div class="footer-bottom">
    <div class="container">
        <div class="row">
            <div class="col-md-12 clearfix">
                <div class="col-sm-6 col-md-6 col-lg-6" style="text-align: left">
                    &copy; MobiCarz
                </div>
                <div class="col-sm-6 col-md-6 col-lg-6">
                    <div class="social" style="float: right;">
                        <div class="inner">
                            <ul class="social-links">
                                <li class="social-icon google-plus"><a href="https://plus.google.com/115003070237722437232"
                                    rel="publisher" target="_blank">Google+</a></li>
                                <li class="social-icon twitter"><a href="https://twitter.com/MobiCarz" target="_blank">
                                    Twitter</a></li>
                                <li class="social-icon pinterest"><a href="http://www.pinterest.com/mobicarz/" target="_blank">
                                    Pinterest</a></li>
                                <li class="social-icon facebook"><a href="https://www.facebook.com/pages/Mobi-Carz/681212045251583?skip_nax_wizard=true"
                                    target="_blank">Facebook</a></li>
                            </ul>
                            <!-- /.social-links -->
                        </div>
                        <!-- /.inner -->
                    </div>
                    <!-- /.social -->
                </div>
                <!-- /.pull-left -->
            </div>
            <!-- /.col-md-12 -->
        </div>
        <!-- /.row -->
    </div>
    <!-- /.container -->
</div>
<!-- /.footer-bottom -->
<!-- /#footer -->
<!-- Old Start -->
<!--
<div class="footer-block">
    <div class="clear">
        &nbsp;</div>
    <div class="footer">
        <table class="block">
            <tr>
                <td style="width: 240px; padding-right: 70px">
                    <h3>
                        <b>MobiCarz</b></h3>
                    <b>Address:</b><br />
                    P.O. Box #504<br />
                    Iselin, NJ 08830-0504
                    <br />
                    <br />
                    <b>Customer Service</b><br />
                    Phone: 888-786-8307
                    <br />
                    Working Hours: 9 AM to 5 PM EST (Mon-Fri)<br />
                </td>
                <td style="width: 360px; padding-right: 70px">
                    <h3>
                        Buying & <b>Selling</b></h3>
                    <ul>
                        <li><a href="http://www.mobicarz.com/Default.aspx">Home</a></li>
                        <li><a href="http://www.mobicarz.com/UsedCars.aspx">Used Cars</a></li>
                        <li><a href="http://www.mobicarz.com/NewCars.aspx">New Cars</a></li>
                        <li><a href="http://www.mobicarz.com/Packages.aspx">Sell A Car</a></li>
                        <li><a href="http://www.mobicarz.com/Dealer.aspx">Car Dealers</a></li>
                        <li><a href="http://www.mobicarz.com/ContactUs.aspx">Contact Us</a></li>
                        <li><a href="http://www.mobicarz.com/Finance.aspx">Finance</a></li>
                        <li><a href="http://www.mobicarz.com/HowItWorks.aspx">How It Works</a></li>
                        <li><a href="http://www.mobicarz.com/Testimonials.aspx">Testimonials</a></li>
                        <li><a href="http://www.mobicarz.com/TermsandConditions.aspx">T&C</a></li>
                        <li><a href="http://www.mobicarz.com/ReturnPolicy.aspx">Return Policy</a></li>
                        <li><a href="http://www.mobicarz.com/MONEY BACK FORM.pdf" target="_blank">Money
                            Back Form</a></li>
                    </ul>
                </td>
                <td>
                    <h3>
                        Keep In <b>Touch</b></h3>
                    <a href="#" class="tw"></a><a href="#" class="fb"></a>
                    <br />
                    <div class="clear">
                    </div>
                    <div style="display: none;">
                        <h3>
                            Join Our <b>Mailing List</b></h3>
                        <div class="join-block">
                            <input type="text" />
                            <input type="button" value="" />
                        </div>
                    </div>
                </td>
            </tr>
        </table>
        <div class="clear">
            &nbsp;</div>
    </div>
    <div class="copy-block">
        <div class="copy" style="text-align: right">
            <p style="padding: 0; font-size: 11px">
                MobiCarz &copy; 2013 <a href="http://www.mobicarz.com/PrivacyPolicy.aspx">
                    Privacy Policy</a>
                <table style="width: auto; margin: 0 auto; display: none">
                    <tr>
                        <td>
                            MobiCarz &copy; 2012 <a href="http://www.mobicarz.com/PrivacyPolicy.aspx">
                                Privacy Policy</a>
                        </td>
                        <td style="width: 60px;">
                        </td>
                        <td style="width: 170px;">
                            <asp:TextBox ID="txtSub" runat="server" ToolTip="Subscribe now to recieve weekly email alerts as per your car choice"
                                Text="Subscribe for weekly email alerts" class="default-value subScr" />
                        </td>
                        <td style="width: 110px">
                            <input type="button" id="imgBtnSubscribe" value="Subscribe Now" class="button1 smallF" />
                        </td>
                        <td style="width: 25px;">
                            &nbsp;
                        </td>
                        <td style="width: 170px;">
                            <asp:TextBox Text="Refer friend" ID="txtReferfrn" runat="server" class="default-value subScr1" />
                        </td>
                        <td>
                            <input type="button" id="Refer" value="Refer" class="button1 smallF" />
                        </td>
                    </tr>
                </table>
            </p>
        </div>
    </div>
</div>

-->
<!-- Old End  -->
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
            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                <div class="title">
                    <h3>
                        Car Info</h3>
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
                                <asp:DropDownList ID="ddlmodelsp" class="form-control" runat="server" AutoPostBack="true">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="form-group ">
                        <label>
                            Year <span class="star">*</span></label>
                        <asp:DropDownList ID="ddlyearp" class="form-control" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                <div class="title">
                    <h3>
                        Personal Info</h3>
                </div>
                <div class="form-section">
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
                        <asp:TextBox ID="txtemail" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div style="text-align: right; margin: 10px 0;">
            <input type="button" value="Submit" class="btn btn-primary2 " />
            &nbsp; &nbsp;
            <input type="button" value="Cancel" class="btn btn-default " />
        </div>
    </div>
</div>


<!--Subscribe Us Popup start-->
<cc1:ModalPopupExtender ID="mpealert" runat="server" PopupControlID="alertholder"
    TargetControlID="hdnfldalert" BackgroundCssClass="ModalPopupBG" CancelControlID="btnOk1"
    OkControlID="lbntClose">
</cc1:ModalPopupExtender>
<asp:HiddenField ID="hdnfldalert" runat="server" />
<div id="alertholder" runat="server" style="display: none">
    <div id="ZipVal" class="loginForm1">
        <h1 class="title">
            alert
            <asp:LinkButton ID="lbntClose" runat="server" class="cls">X</asp:LinkButton>
        </h1>
        <table style="width: 98%; margin: 0 auto">
            <tr>
                <td style="width: 95px;" colspan="2">
                    <asp:UpdatePanel ID="updpanel" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblAlertMsg" runat="server"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px;" colspan="2">
                    <div style="width: 34px; margin: 30px auto 0 auto">
                        <asp:Button ID="btnOk1" runat="server" class="button1" Text="Ok" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
</div>
<!---alert popup---->
<!-- Processiong Popup Start -->
<div id="spinner" style="display: none;">
    <h4>
    </h4>
</div>
<!-- Processiong Popup End -->

<script type="text/javascript">


    function togglePrompt() {
        if ($('.subScr').val() == defaultValue) {
            $('.subScr').val('');
        } else if ($('.subScr').val() == '') {
            $('.subScr').val(defaultValue);
        }
    }

    function togglePrompt2() {
        if ($('.subScr1').val() == defaultValue1) {
            $('.subScr1').val('');
        } else if ($('.subScr1').val() == '') {
            $('.subScr1').val(defaultValue1);
        }
    }

    /*
    window.onload = function() {
        
    }
    */
</script>

<script>
    (function(i, s, o, g, r, a, m) {
        i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function() {
            (i[r].q = i[r].q || []).push(arguments)
        }, i[r].l = 1 * new Date(); a = s.createElement(o),
  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
    })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');
    ga('create', 'UA-49890261-1', 'mobicarz.com');
    ga('send', 'pageview');
</script>

<script type="text/javascript">
    var makePrf = [];
    var modelPrf = [];
    var rowCounter = 0;
    var defaultValue = 'Subscribe for weekly email alerts';
    var defaultValue = 'Refer friend';

    // Bind Range


    $(function() {



        var mm = '';
        mm += "<option selected='selected' value='0'>Best offer</option>";
        mm += "<option value='1'>1-5000</option>";
        mm += "<option value='2'>5001-10000</option>";
        mm += "<option value='3'>10001-25000</option>";
        mm += "<option value='4'>25001-50000</option>";
        mm += "<option value='5'>50001-75000</option>";
        mm += "<option value='6'>75001-100000</option>";
        mm += "<option value='7'>100000+ </option>";


        $('.makeModelSel #row0 select:eq(2)').empty().append(mm);
        $('.makeModelSel #row1 select:eq(2)').empty().append(mm);
        $('.makeModelSel #row2 select:eq(2)').empty().append(mm);
        $('.makeModelSel #row3 select:eq(2)').empty().append(mm);
        $('.makeModelSel #row4 select:eq(2)').empty().append(mm);
    })

    // Make Dropdown
    //BindMakesPrf(result);
    //ModelsBindingPrf(result);
    function BindMakesPrf(result) {

        makePrf = result;

        if (makePrf.length > 0) {
            for (k = 0; k < 5; k++) {
                var mm = '';
                mm += "<option value='0' selected='selected' >Select</option>";
                for (i = 0; i < makePrf.length; i++) {
                    mm += "<option value=" + makePrf[i]["MakeID"] + ">" + makePrf[i]["Make"] + "</option>"
                }
                $('.makeModelSel #row' + k + ' select:eq(0)').empty().append(mm);
                ////console.log($('.makeModelSel #row' + k + ' select:eq(0)').html());
            }

        } else {
            $('.makeModelSel #row' + k + ' select:eq(0)').empty()
        }
    }


    // Models Dropdown
    function ModelsBindingPrf(result) {

        modelPrf = result;

        //alert(models.length);
        var mm = "<option value='0' selected='selected'>Select</option>";
        $('.makeModelSel #row0 select:eq(1)').empty().append(mm);
        $('.makeModelSel #row1 select:eq(1)').empty().append(mm);
        $('.makeModelSel #row2 select:eq(1)').empty().append(mm);
        $('.makeModelSel #row3 select:eq(1)').empty().append(mm);
        $('.makeModelSel #row4 select:eq(1)').empty().append(mm);


        $('.makeModelSel tr').each(function(index) {
            $('.makeModelSel tr:eq(' + index + ') select:eq(0)').bind('change keypress', function() {
                if (modelPrf.length > 0) {
                    //var index = $(this).parent().parent().index();
                    $('.makeModelSel #row' + index + ' select:eq(1)').removeAttr('disabled');
                    var id = $(this).val();
                    ////console.log(index, id);
                    var mm = '';
                    var count = 0;
                    mm += "<option value='0' selected='selected'>Select</option>";
                    for (i = 0; i < modelPrf.length; i++) {
                        if (id == modelPrf[i]["MakeID"]['#text']) {
                            mm += "<option value=" + modelPrf[i]["MakeModelID"]['#text'] + ">" + modelPrf[i]["Model"]['#text'] + "</option>";
                            count++;
                        }
                    }
                    $('.makeModelSel #row' + index + ' select:eq(1)').empty();
                    if (count > 0) {
                        $('.makeModelSel #row' + index + ' select:eq(1)').append(mm); $('.makeModelSel #row4 select:eq(1)').append(mm);
                    } else {
                        var mm = '';
                        mm += "<option value='0'>Select</option>";
                        $('.makeModelSel #row' + index + ' select:eq(1)').empty().append(mm).attr('disabled', true);


                    }
                }

            });
        })



    }






    //subScribeNew User
    function subScribeNew() {
        debugger
        var email = $('#Footer1_txtSub').val();
        $('#Footer1_txtEmailAlert').val(email);
        $find('Footer1_mpesubscribe').show();
        $('#Footer1_txtSub').val('');
    }




    $(window).load(function() {




        $(function() {
            $('.sample4').numeric();



            $('#Footer1_btnsubScribUs').click(function() { $find('Footer1_mpesubscribe').hide(); SubScribeNoShow() })
            $(' #Footer1_btnSubscribeCancel').click(function() { $find('Footer1_mpesubscribe').hide(); SubScribeNoShow() })

            // Reffer Friend
            $('#Refer').click(function() {
                StopTimer();
                var valid = true;
                var emailID = $('#Footer1_txtReferfrn').val()
                if ($('#Footer1_txtReferfrn').val().length < 1) {
                    alert("Enter email address");
                    $('#Footer1_txtReferfrn').focus();
                    valid = false;
                    return valid;
                }
                else if (($('#Footer1_txtReferfrn').val() == null) || ($('#Footer1_txtReferfrn').val() == "Refer friend")) {
                    alert("Please enter valid email address");
                    $('#Footer1_txtReferfrn').focus();
                    valid = false;
                    return valid;
                }
                else if (echeck($('#Footer1_txtReferfrn').val()) == false) {
                    $('#Footer1_txtReferfrn').val('');
                    $('#Footer1_txtReferfrn').focus();
                    valid = false;
                    return valid;
                } else {
                    showSpinner();
                    var email = $('#Footer1_txtReferfrn').val();
                    ReferFriend(email);

                    $('#Footer1_txtReferfrn').val('Refer friend');
                }
            });

            // Email Subsc
            $('#imgBtnSubscribe').click(function() {
                StopTimer();
                var valid = true;
                if ($('#Footer1_txtSub').val().trim() == 'Subscribe for weekly email alerts') {
                    alert("Please enter your email address to signup");
                    $('#Footer1_txtSub').focus();
                    valid = false;
                    return valid;
                }
                else if (($('#Footer1_txtSub').val().trim().length > 0) && (echeck($('#Footer1_txtSub').val().trim()) == false)) {
                    alert("Please enter valid email address to signup");
                    $('#Footer1_txtSub').val('');
                    $('#Footer1_txtSub').focus();

                    valid = false;
                    return valid;
                } else {
                    CheckAlreadySubscribeEmail($('#Footer1_txtSub').val())
                }

            });


            // GetMakes2();

            // GetModelsInfo2();

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


        //defaultValue = $('.subScr').val();
        //$('.subScr').live('focus blur', togglePrompt());
        //('.subScr').blur(function() { togglePrompt(); });

        //defaultValue1 = $('.subScr1').val();
        //$('.subScr1').live('focus blur', togglePrompt2());


        $('.makeModelSel #row5 a').click(function() {

            if (rowCounter < 4) {
                var selCount = 0;
                $('.makeModelSel #row' + rowCounter + ' select').each(function(index) {
                    var ind = index;
                    ////console.log($(this).val())
                    if (($(this).val() == 0) && (ind == 0 || ind == 1)) {
                        selCount++;
                    }
                })
                ////console.log('selCount '+selCount);
                if (selCount == 0) {
                    rowCounter++;
                    //$('.makeModelSel #row' + (rowCounter - 1) + ' select').attr('disabled', true);
                    $('.makeModelSel #row' + (rowCounter - 1) + ' a.rem').hide();
                    $('.makeModelSel #row' + rowCounter).show();
                    if (rowCounter == 4) {
                        $('.makeModelSel #row5').hide();
                    }
                } else {
                    alert('Select Make and Model')
                }
            }

        });




        $('.makeModelSel .rem').click(function() {
            var id = $(this).parent().parent().attr('id')
            if (rowCounter > 0) {
                rowCounter--;
                $('.makeModelSel #' + id).hide()
                $('.makeModelSel #' + id + ' select').removeAttr('disabled');
                var rem = id.substring(0, 3) + rowCounter;
                ////console.log(rem);
                $('.makeModelSel #' + rem + ' a.rem').show();
                $('.makeModelSel #' + id + ' select').each(function() {
                    $(this).removeAttr('selected').find('option:first').attr('selected', 'selected');

                    var ddModel = 'ddlModel' + parseInt(id.charAt(3));
                    if ($(this).attr('id') == ddModel) {
                        ////console.log($(this).attr('id'))
                        $(this).empty().append('<option selected="selected" value="0">Select</option>');
                    }
                });

                $('.makeModelSel #row5').show();
                if (rowCounter == 0) {
                    $('.makeModelSel #row0 select').removeAttr('disabled');
                }

            }
        });

    });
</script>

