<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Footer.ascx.cs" Inherits="UserControl_Footer" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



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

<table style="width: 100%; font-size: 11.5px;">
    <tr>
        <td>
            <a href="http://UnitedCarExchange.com/Default.aspx">Home</a> | <a href="http://UnitedCarExchange.com/UsedCars.aspx">
                Used Cars</a> | <a href="http://UnitedCarExchange.com/NewCars.aspx">New Cars</a>
            | <a href="http://UnitedCarExchange.com/Packages.aspx">Sell A Car</a> | <a href="http://UnitedCarExchange.com/Dealer.aspx">
                Car Dealers</a> | <a href="http://UnitedCarExchange.com/ContactUs.aspx">Contact Us</a>
            | <a href="http://UnitedCarExchange.com/Finance.aspx">Finance</a> | <a href="http://UnitedCarExchange.com/HowItWorks.aspx">
                How It Works</a> | <a href="http://UnitedCarExchange.com/Testimonials.aspx">Testimonials</a>
            | <a href="http://UnitedCarExchange.com/TermsandConditions.aspx">T&C</a> | <a href="http://UnitedCarExchange.com/ReturnPolicy.aspx">
                Return Policy</a> | <a href="http://UnitedCarExchange.com/MONEY BACK FORM.pdf" target="_blank">
                    Money Back Form</a>
        </td>
    </tr>
</table>
<div class="clear">
    &nbsp;</div>
<p style="padding-top: 10px; font-size: 11px">
    United Car Exchange &copy; 2012 <a href="http://UnitedCarExchange.com/PrivacyPolicy.aspx">
        Privacy Policy</a>
    <table style="width: auto; margin: 0 auto;display:none">
        <tr>
            <td>
                United Car Exchange &copy; 2012 <a href="http://UnitedCarExchange.com/PrivacyPolicy.aspx">
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
<cc1:ModalPopupExtender ID="mpesubscribe" runat="server" PopupControlID="subScribUs1"
    BackgroundCssClass="ModalPopupBG" TargetControlID="hdnSubscribe" OkControlID="btnsubScribUs">
</cc1:ModalPopupExtender>
<asp:HiddenField ID="hdnSubscribe" runat="server" />
<div id="subScribUs1" runat="server" style="display: none; height: auto; padding-bottom: 15px;
    width: 600px;">
    <div id="divsubScribUs" class="loginForm1" style="height: auto; padding-bottom: 15px;
        width: 600px;">
        <h1 class="title">
            Sign up to receive email alerts.
            <asp:LinkButton ID="btnsubScribUs" runat="server" class="cls" Text="X" OnClick="btnsubScribUs_Click"></asp:LinkButton>
        </h1>
        <div>
            <fieldset class="field1" style="text-align: left">
                <legend>My preferences</legend>
                <table style="width: 98%; margin: 0 auto" class="makeModelSel">
                    <tr id="row0">
                        <td style="width: 170px;">
                            <h4>
                                Make</h4>
                            <asp:DropDownList ID="ddlMake1" Style="width: 162px;" TabIndex="1" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <h4>
                                Model</h4>
                            <asp:DropDownList ID="ddlModel1" Style="width: 99%;" TabIndex="2" runat="server"
                                AppendDataBoundItems="true">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 120px;">
                            <h4>
                                Price Range $</h4>
                            <asp:DropDownList ID="ddlRange1" Style="width: 100%;" TabIndex="3" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 50px;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr id="row1">
                        <td style="width: 170px;">
                            <asp:DropDownList ID="ddlMake2" Style="width: 162px;" TabIndex="4" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlModel2" Style="width: 99%;" TabIndex="5" runat="server"
                                AppendDataBoundItems="true">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 120px;">
                            <asp:DropDownList ID="ddlRange2" Style="width: 100%;" TabIndex="6" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 50px;">
                            <a href="javascript:void(0);" class="rem">Remove</a>
                        </td>
                    </tr>
                    <tr id="row2">
                        <td style="width: 170px;">
                            <asp:DropDownList ID="ddlMake3" Style="width: 162px;" TabIndex="7" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlModel3" Style="width: 99%;" TabIndex="8" runat="server"
                                AppendDataBoundItems="true">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 120px;">
                            <asp:DropDownList ID="ddlRange3" Style="width: 100%;" TabIndex="9" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 50px;">
                            <a href="javascript:void(0);" class="rem">Remove</a>
                        </td>
                    </tr>
                    <tr id="row3">
                        <td style="width: 170px;">
                            <asp:DropDownList ID="ddlMake4" Style="width: 162px;" TabIndex="10" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlModel4" Style="width: 99%;" TabIndex="11" runat="server"
                                AppendDataBoundItems="true">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 120px;">
                            <asp:DropDownList ID="ddlRange4" Style="width: 100%;" TabIndex="12" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 50px;">
                            <a href="javascript:void(0);" class="rem">Remove</a>
                        </td>
                    </tr>
                    <tr id="row4">
                        <td style="width: 170px;">
                            <asp:DropDownList ID="ddlMake5" Style="width: 162px;" TabIndex="13" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlModel5" Style="width: 99%;" TabIndex="14" runat="server"
                                AppendDataBoundItems="true">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 120px;">
                            <asp:DropDownList ID="ddlRange5" Style="width: 100%;" TabIndex="15" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 50px;">
                            <a href="javascript:void(0);" class="rem">Remove</a>
                        </td>
                    </tr>
                    <tr id="row5">
                        <td colspan="3">
                        </td>
                        <td>
                            <a href="javascript:void(0);"><b>+ Add</b></a>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <table style="width: 98%; margin: 0 auto 10px auto; text-align: left">
                <tr>
                    <td colspan="2" style="padding-bottom: 10px;">
                        <h4>
                            Name<span class="star">*</span></h4>
                        <asp:TextBox ID="txtName" Style="width: 99%;" TabIndex="16" runat="server" Text="Your Name"
                            MaxLength="60" class="default-value">
                        </asp:TextBox>
                        <div class="clear">
                            &nbsp;</div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 58%;">
                        <h4>
                            Email<span class="star">*</span></h4>
                        <asp:TextBox ID="txtEmailAlert" Text="Your Email" Style="width: 93%;" class="default-value"
                            MaxLength="60" TabIndex="17" runat="server">
                        </asp:TextBox>
                    </td>
                    <td>
                        <h4>
                            Phone</h4>
                        <asp:TextBox ID="txtPhoneNo" Text="" Style="width: 97%;" class="default-value sample4"
                            MaxLength="10" TabIndex="18" runat="server">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; padding-top: 5px;">
                        <h4>
                            Zip</h4>
                        <asp:TextBox ID="txtZip" Style="width: 86%;" TabIndex="19" runat="server" Text=""
                            MaxLength="5" class="default-value sample4">
                        </asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
            &nbsp;</div>
        <br />
        <table style="width: 98%; margin: 0 auto;">
            <tr>
                <td style="width: 50%; text-align: right; padding-right: 4px;">
                    <asp:UpdatePanel ID="updpnlsubscribe" runat="server">
                        <ContentTemplate>
                            <asp:Button runat="server" ID="btnSubscribe" class="floatL button1" Text="Sign Up"
                                OnClientClick="javascript:return validateSubScribe();" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    
                </td>
                <td style="text-align: left; padding-left: 4px;">
                    <input type="button" value="No,thanks" class="floatL button1" id="Footer1_btnSubscribeCancel"  />
                </td>
            </tr>
        </table>
        <div class="clear">
            &nbsp;</div>
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

<script type="text/javascript">
    var makePrf = [];
    var modelPrf = [];
    var rowCounter = 0;
    var defaultValue = 'Subscribe for weekly email alerts';
    var defaultValue = 'Refer friend';

    // Bind Range
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


            GetMakes2();

            GetModelsInfo2();
            
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

