/*!
* Auther      : Jyothirmayudu.CH
* Mail        : ch.jmayudu@gmail.com
* Created on  : 14 Jan 2012
* Discription : JS for for Search Results Generation
*/
// Banner Slider Start
/*
function CarBannerAdsDisplay(CarBannerAds) {
//console.log('CarBannerAds',CarBannerAds)
if (CarBannerAds.length > 0) {
var img = '';
var withinZIp1 = 0;
var zip1 = 0;


for (i = 0; i < CarBannerAds.length; i++) {
var resPath = '"' + CarBannerAds[i]['Carid']['#text'] + '","' + CarBannerAds[i]['Make']['#text'] + '","' + CarBannerAds[i]['Model']['#text'] + '","' + zip1 + '","' + withinZIp1 + '"';
var thumb1 = '';
path = CarBannerAds[i]['PICLOC1']['#text'] + "/" + CarBannerAds[i]['PIC1']['#text'];
for (k = 0; k < 8; k++) {
path = path.replace("\\", "/");
}
path = path.replace("//", "/");
thumb1 = "<img src='" + path + "' onclick='#'  width='630' height='389' />";
img += "<div>" + thumb1 + "<p> <b style='font-size:14px;'><a href='#'>" + CarBannerAds[i]['YearOfMake']['#text'] + " " + CarBannerAds[i]['Make']['#text'] + " " + CarBannerAds[i]['Model']['#text'] + "</a></b><br> <b ><span class='price10' style='color:#fff'>" + CarBannerAds[i]['Price']['#text'] + "</span></b> </big> </p> </div>";
}
$('#loopedSlider .container .slides').empty();
$('#loopedSlider .container .slides').append(img);
$('.price10').formatCurrency();
// Option set as a global variable
$.fn.loopedSlider.defaults.addPagination = true;
$('#loopedSlider').loopedSlider({
autoStart: 5000
});
} else {
var slider01 = [['images/slides/image-01.jpg', 'BMW X6 M', 2011, 'Hatchback', '250,000', '6.4 Diesel'],
['images/slides/image-02.jpg', 'Mercedes Benz S65 AMG', 2009, 'Sedan', '450,000', '3.4 Diesel'],
['images/slides/image-03.jpg', 'Audi Q7 3.0 TDI', 2010, 'SUV', '123,000', '3.4 Diesel'],
['images/slides/image-04.jpg', 'MERCEDES-BENZ GLK350 4MATIC', 2007, 'SUV', '657,000', '4.2 Diesel'],
['images/slides/image-05.jpg', 'Lexus GS 350', 2010, 'Sedan', '321,000', '6.2 Diesel']];

// Main Slider images
if (slider01.length > 0) {
var img = '';
for (i = 0; i < slider01.length; i++) {
img += "<div> <img src=" + slider01[i][0] + " width='630' height='389'/><p> <big> <strong><a href='#'>" + slider01[i][1] + "</a></strong> <b>" + slider01[i][2] + "</b> </big> <small> <em><img src='images/icon-1.gif' />" + slider01[i][3] + "</em> <i><img src='images/icon-2.gif' />" + slider01[i][4] + "$</i> <span><img src='images/icon-3.gif' /><a href='#'>" + slider01[i][5] + "</a></span> </small> </p> </div>";
}
$('#loopedSlider .container .slides').empty();
$('#loopedSlider .container .slides').append(img);

// Option set as a global variable
$.fn.loopedSlider.defaults.addPagination = true;
$('#loopedSlider').loopedSlider({
autoStart: 5000
});

};

}


}
// Banner Slider End
*/
// Ads Display  Start  
function CarsAdDisplay(CarsAdDetails) {
    var path = '';
    //console.log(CarsAdDetails);
    // Horizantal Car Ads
    if (CarsAdDetails.length > 0) {
        var img = '';
        var withinZIp1 = 0;
        var zip1 = '0'
        var imgWidth = ''
        var liStyle = ''
        var style1 = '';
        var style2 = ''
        $('.UTEads .main').empty()

        for (i = 0; i < 4; i++) {
            img = '';
            liStyle = "<div class='UTEadThumbHolder'>";
            liStyle += "<div class='ad'>";
            var resPath = '"' + CarsAdDetails[i]['Carid']['#text'] + '","' + CarsAdDetails[i]['Make']['#text'] + '","' + CarsAdDetails[i]['Model']['#text'] + '","' + zip1 + '","' + withinZIp1 + '","' + CarsAdDetails[i]['TypeName']['#text'] + '"';
            var thumb1 = '';
            if (CarsAdDetails[i]['PIC0']['#text'] != 'Emp') {
                path = CarsAdDetails[i]['PICLOC0']['#text'] + "/" + CarsAdDetails[i]['PIC0']['#text'];
                for (k = 0; k < 5; k++) {
                    path = path.replace("\\", "/");
                }
                path = path.replace("//", "/");

                if (CarsAdDetails[i]['PIC1']['#text'] != 'Emp') {
                    hoverPath = CarsAdDetails[i]['PICLOC1']['#text'] + "/" + CarsAdDetails[i]['PIC1']['#text'];
                    for (k = 0; k < 5; k++) {
                        hoverPath = hoverPath.replace("\\", "/");
                    }
                    hoverPath = hoverPath.replace("//", "/");
                } else {
                    hoverPath = CarsAdDetails[i]['PICLOC0']['#text'] + "/" + CarsAdDetails[i]['PIC0']['#text'];
                    for (k = 0; k < 5; k++) {
                        hoverPath = hoverPath.replace("\\", "/");
                    }
                    hoverPath = hoverPath.replace("//", "/");
                }

                thumb1 = "<img src='http://www.unitedtruckexchange.com/" + path + "' class='Hthumb' desc='http://www.UnitedTruckExchange.com/" + hoverPath + "' onclick='javascript:EncryptedCarID(" + resPath + ");' " + imgWidth + " />";
            } else {
                var carMake = CarsAdDetails[i]['TypeName']['#text'];
                var carModel = CarsAdDetails[i]['Make']['#text'];
                carMake = carMake.replace(' ', '-');
                carModel = carModel.replace(' ', '-');
                if (carModel.indexOf('/') > 0) {
                    carModel = 'Other';
                }
                var MakeModel = carMake + "_" + carModel;
                MakeModel = MakeModel.replace(' ', '-');
                path = "http://www.unitedtruckexchange.com/images/MakeModelThumbs/" + MakeModel + ".jpg";

                thumb1 = "<img src='" + path + "'  class='Hthumb' desc='" + path + "' onclick='javascript:EncryptedCarID(" + resPath + ");' " + imgWidth + " /><div class='stockPhoto3' >Stock Photo</div>";




            }
            var price1 = CarsAdDetails[i]['Price']['#text'];
            if (price1 != 'Emp' && price1 != '0' && price1 != 0 && price1 != null) {
                img += "" + liStyle + thumb1 + "<a href='javascript:EncryptedCarID(" + resPath + ");' class='text' >";
                var text = CarsAdDetails[i]['YearOfMake']['#text'] + " " + CarsAdDetails[i]['TypeName']['#text'] + ", " + CarsAdDetails[i]['Category']['#text'] + ", " + CarsAdDetails[i]['Make']['#text'] + ", " + CarsAdDetails[i]['Model']['#text'];
                if (text.length > 28) {
                    text = text.substring(0, 27);
                    text += ".."
                }
                img += text + "</a><span class='price price11'>" + CarsAdDetails[i]['Price']['#text'] + "</span> </div></div>"
            } else {
                img += "" + liStyle + thumb1 + "<a href='javascript:EncryptedCarID(" + resPath + ");' class='text' >"
                var text = CarsAdDetails[i]['YearOfMake']['#text'] + " " + CarsAdDetails[i]['TypeName']['#text'] + ", " + CarsAdDetails[i]['Category']['#text'] + ", " + CarsAdDetails[i]['Make']['#text'] + ", " + CarsAdDetails[i]['Model']['#text'];
                if (text.length > 28) {
                    text = text.substring(0, 27);
                    text += ".."
                }



                img += text + "</a><span class='price '>Call for Price</span></div></div>"
            }
            $('.UTEads .main').append(img);
        }


        //$('img.thumbH').ibox();
    };

    $('.price11').formatCurrency();

}
// Ads Display End



// latestPostedCars Ticker Start
function latestPostedCars(latestPosts) {
    //console.log(latestPosts);

    if (latestPosts != null && latestPosts != undefined && latestPosts.length > 0) {
        var vTic = '';
        var withinZIp1 = 0;
        var zip1 = '0'

        for (i = 0; i < latestPosts.length; i++) {
            var resPath = '"' + latestPosts[i]['Carid']['#text'] + '","' + latestPosts[i]['Make']['#text'] + '","' + latestPosts[i]['Model']['#text'] + '","' + zip1 + '","' + withinZIp1 + '","' + latestPosts[i]['TypeName']['#text'] + '"';
            vTic += "<li style='vertical-align:top;'><div><h4><a href='javascript:EncryptedCarID(" + resPath + ");'>" + latestPosts[i]['YearOfMake']['#text'] + " " + latestPosts[i]['TypeName']['#text'].toLowerCase() + "  " + latestPosts[i]['Make']['#text'].toLowerCase() + "</a></h4>";
            var cc = 0;
            if (latestPosts[i]['Price']['#text'] != 'Emp' && latestPosts[i]['Price']['#text'] != '0' && latestPosts[i]['Price']['#text'] != 0 && latestPosts[i]['Price']['#text'] != undefined && latestPosts[i]['Price']['#text'] != null) {
                vTic += "<b><span class='price13'>" + latestPosts[i]['Price']['#text'] + "</span></b>";
                cc = 0;
            } else {
                cc = 1;
            }

            if (latestPosts[i]['Mileage']['#text'] != 'Emp' && latestPosts[i]['Mileage']['#text'] != undefined && latestPosts[i]['Mileage']['#text'] != 'Unspecified' && latestPosts[i]['Mileage']['#text'] != null && latestPosts[i]['Mileage']['#text'] != 'null' && cc != 1 && latestPosts[i]['Mileage']['#text'] != '0' || latestPosts[i]['Mileage']['#text'] != 0) {
                vTic += ", <span class='mileage10'>" + latestPosts[i]['Mileage']['#text'] + "</span> mi";
            } else if (latestPosts[i]['Mileage']['#text'] != 'Emp' && latestPosts[i]['Mileage']['#text'] != undefined && latestPosts[i]['Mileage']['#text'] != 'Unspecified' && latestPosts[i]['Mileage']['#text'] != null && latestPosts[i]['Mileage']['#text'] != 'null' && cc == 1 && latestPosts[i]['Mileage']['#text'] != '0' || latestPosts[i]['Mileage']['#text'] != 0) {
                vTic += "<span class='mileage10'>" + latestPosts[i]['Mileage']['#text'] + "</span> mi";
            }
            /* else if(latestPosts[i]['Mileage']['#text'] == '0' || latestPosts[i]['Mileage']['#text'] == 0 && cc ==1){
            vTic +="<span class='mileage10'>"+latestPosts[i]['Mileage']['#text']+"</span> miles";
            }else if(latestPosts[i]['Mileage']['#text'] == '0' || latestPosts[i]['Mileage']['#text'] == 0 && cc !=1){
            vTic +=", <span class='mileage10'>"+latestPosts[i]['Mileage']['#text']+"</span> miles";
            }
            */

            if (latestPosts[i]['City']['#text'] != 'Emp' && latestPosts[i]['City']['#text'] != undefined && latestPosts[i]['City']['#text'] != 'Unspecified') {
                vTic += " in " + latestPosts[i]['City']['#text'] + " </div></li>"
            } else {
                vTic += "</div></li>"
            }
        }
        debugger       
        
        $('.ticker1 ul').empty();
        $('.ticker1 ul').append(vTic);
        $('.price13').formatCurrency();
        $('.mileage10').formatCurrency({
            symbol: ' '
        });

        $('.ticker1').vTicker({
            speed: 500,
            pause: 3000,
            animation: 'fade',
            mousePause: true,
            showItems: 5
        });
    }
}

// latestPostedCars Ticker Start 



// START function updateCharCount 
function updateCharCount(textArea, displayField, displaySentence) {
    // Only proceed if the parameters are valid
    if (null != textArea && null != displayField && null != displaySentence) {
        // Determine the count
        var count = 1000; // Max length
        count -= textArea.value.length; // Text length
        // Update the count
        document.getElementById(displayField).innerHTML = count; // Update the number
        // Update sentence color
        if (count > 20) {
            document.getElementById(displaySentence).style.color = "#808080";
            document.getElementById(displaySentence).style.fontWeight = "normal";
        } else if (count > 5) {
            document.getElementById(displaySentence).style.color = "#C24747";
            document.getElementById(displaySentence).style.fontWeight = "normal";
        } else if (count > 0) {
            document.getElementById(displaySentence).style.color = "#FF0000";
            document.getElementById(displaySentence).style.fontWeight = "normal";
        } else {
            document.getElementById(displaySentence).style.color = "#FF0000";
            document.getElementById(displaySentence).style.fontWeight = "bold";
            textArea.value = textArea.value.substr(0, 999);
        } // END if/else
    } // END if
    return false;
} // END function updateCharCount
$(function() {
    ///$('#vehicleType, #categoty, #make').attr('disabled', true);

    $('#yourZip, #form-1-submit, #within').attr('disabled', true);

    $('input[type=text], textarea').bind("cut copy paste", function(e) {
        e.preventDefault();
    });

    $('#resultsPerPage').change(function() {
        page = 1;
        $('.leftArrow div').removeClass('leftAct');
        $('.leftArrow div').addClass('leftDis');
        filterChecked();
    });

    $('.leftArrow div').removeClass('leftAct');
    $('.leftArrow div').addClass('leftDis');
    $('.rightArrow div').removeClass('rightAct');
    $('.rightArrow div').addClass('rightDis');

    /*
    page = 1;
    PageResultsCount = 25;
    hideSpinner();
    startNum = 1;
    endNum = 25;
    
    */

    $('.rightArrow').click(function() {

        if (maxPages == 1) {
            $('.leftArrow div').removeClass('leftAct');
            $('.leftArrow div').addClass('leftDis');
            $('.rightArrow div').removeClass('rightAct');
            $('.rightArrow div').addClass('rightDis');
        } else if (page < maxPages) {
            page++;
            $('.leftArrow div').removeClass('leftDis');
            $('.leftArrow div').addClass('leftAct');
            if (page >= maxPages) {
                $('.rightArrow div').removeClass('rightAct');
                $('.rightArrow div').addClass('rightDis');

            }
            showSpinner();
            PageResultsCount = parseInt($('#resultsPerPage option:selected').val());
            sFilterType = parseInt($('#filterSortBy option:selected').val());

            GetPageData(PageResultsCount, page);


            //            if(sFilterType != 0 && sFilterType != '0'){
            //                SortData(sFilterType, PageResultsCount);
            //            }
        } else if (maxPages == 0) {
            $('.leftArrow div').removeClass('leftAct');
            $('.leftArrow div').addClass('leftDis');

            $('.rightArrow div').removeClass('rightAct');
            $('.rightArrow div').addClass('rightDis');

        } else {
            $('.rightArrow div').removeClass('rightAct');
            $('.rightArrow div').addClass('rightDis');

            $('.leftArrow div').removeClass('leftDis');
            $('.leftArrow div').addClass('leftAct');

            PageResultsCount = parseInt($('#resultsPerPage option:selected').val());
            //startNum += resultsLength; 
            //endNum += resultsLength; 

        }
    });

    $('.leftArrow').click(function() {

        if (maxPages == 1) {
            $('.leftArrow div').removeClass('leftAct');
            $('.leftArrow div').addClass('leftDis');
            $('.rightArrow div').removeClass('rightAct');
            $('.rightArrow div').addClass('rightDis');
        } else if (page > 1) {
            page--;
            $('.rightArrow div').removeClass('rightDis');
            $('.rightArrow div').addClass('rightAct');
            if (page == 1) {
                $('.leftArrow div').removeClass('leftAct');
                $('.leftArrow div').addClass('leftDis');
            }
            showSpinner();
            PageResultsCount = parseInt($('#resultsPerPage option:selected').val());
            sFilterType = parseInt($('#filterSortBy option:selected').val());
            GetPageDecrement(PageResultsCount, page);

        } else if (maxPages <= 0) {
            $('.leftArrow div').removeClass('leftAct');
            $('.leftArrow div').addClass('leftDis');

            $('.rightArrow div').removeClass('rightAct');
            $('.rightArrow div').addClass('rightDis');

        } else {
            $('.leftArrow div').removeClass('leftAct');
            $('.leftArrow div').addClass('leftDis');

            $('.rightArrow div').removeClass('rightDis');
            $('.rightArrow div').addClass('rightAct');

        }
    });




});


function NoOfResultsandPagecount(result) {
    //alert(result)
    maxPages = result[0];
    totalTesults = result[1];
    PageResultsCount = parseInt($('#resultsPerPage option:selected').val());
    // 1-25 of 116
    var m = '';
    if (maxPages > 1) {
        m += '<strong>' + startNum + '</strong>-<strong>' + endNum + '</strong> of <strong>' + totalTesults + '</strong>';
    } else if (maxPages == 1) {
        m += '<strong>' + totalTesults + '</strong>-<strong>' + totalTesults + '</strong> of <strong>' + totalTesults + '</strong>';
    } else if (maxPages == 0 && page == 1) {
        m += '<strong>0</strong>';
    }
    $('#totalResultsFound').empty();
    $('#totalResultsFound').append(m);

    arrowsAct();
}

function showSpinner() {
    $('#spinner').show();
}

function hideSpinner() {
    $('#spinner').hide();
}


function BindVehicleType(result) {

    VehicleType = result;
    // console.log(VehicleType)
    if (VehicleType.length > 0) {
        var mm = '';
        mm += "<option value='0'>Any Type</option>";
        for (i = 0; i < VehicleType.length; i++) {
            mm += "<option value=" + VehicleType[i]["TypeID"]['#text'] + ">" + VehicleType[i]["TypeName"]['#text'] + "</option>"
        }
        $('#vehicleType').empty();
        $('#vehicleType').append(mm);
    } else {
        $('#vehicleType').empty();
    }
    $('#vehicleType').removeAttr('disabled');
    //$('#vehicleType, #categoty, #make').attr('disabled', true);
    
    GetCategory();

}

// Vehicle Category Binding
function BindCategory(result) {
    //console.log(result);
    //alert(result)
    //WithinZipBinding();
    //debugger 
    category = result;
    //$('#vehicleType').removeAttr('disabled');

    //console.log(LoadingPage)    
    var mm = '';
    mm += "<option value='0'>Any Category</option>";
    /*  ------------------------------------*/
    var dump = [];
    for (i = 0; i < category.length; i++) {
        var valid = true;
        for (k = 0; k < dump.length; k++) {
            if (dump[k] == category[i]["Category_Name"]) {
                valid = false;
            }
        }
        if (valid == true) {
            dump.push(category[i]["Category_Name"]);
            mm += "<option value=" + category[i]["Category_id"] + ">" + category[i]["Category_Name"] + "</option>";
        }
    }
    /* ---------------   */
    $('#categoty').empty().append(mm);
    $('#categoty').removeAttr('disabled');

    GetMakes();
}



// Make Dropdown


function BindMakes(result) {
    //debugger
    //alert(result)
    //console.log(result)


    make = result;

    // $('#vehicleType').removeAttr('disabled');
    var mm = '';
    mm += "<option value='0'>Any Make</option>";
    $('#make').empty().append(mm);



    /*  -------------*/
    var dump = [];
    for (i = 0; i < make.length; i++) {
        var valid = true;
        for (k = 0; k < dump.length; k++) {
            if (dump[k] == make[i]["Make"]['#text']) {
                valid = false;
            }
        }   
        if (valid == true) {
            dump.push(make[i]["Make"]['#text']);
            mm = "<option value=" + make[i]["MakeID"]['#text'] + ">" + make[i]["Make"]['#text'] + "</option>";
            $('#make').append(mm);
        }
    }

    /*  -------------*/
    //$('#make').append(mm);
    $('#make').removeAttr('disabled');
    //onchangeEvents();
    //WithinZipBinding();
    GetModelsInfo();
}

/* Binding Models */
function ModelsBinding(result) {

    mm += "<option value='0'>Any Model</option>";
    $('#model').empty().append(mm);
    
    models = result;

    onchangeEvents();
    WithinZipBinding();
    
    
}



// Within Dropdow1n 
function WithinZipBinding() { // function WithinZipBinding(withinZip){         
    //alert(within);
    if (within.length > 0) {
        var mm = '';
        //mm += "<option value='Select distance'>Select distance</option>";
        for (i = 0; i < within.length; i++) {
            if (i < within.length - 1) {
                mm += "<option value=" + (i + 1) + ">" + within[i] + " miles</option>";
            } else {
                mm += "<option value=" + (i + 1) + ">" + within[i] + "</option>";
            }
        }
        $('#within').empty();
        $('#within').append(mm);
    }
    $('#within option').each(function() {
        $(this).removeAttr('selected');
    });
    if (LoadingPage == 1) {
        $('#within option[value=' + 1 + ']').attr('selected', 'selected');
    }

    if (LoadingPage != 1) {
        searchCri();
    } else {
        //$('#vehicleType, #categoty, #make, #within, #yourZip, #form-1-submit').removeAttr('disabled');
    $('#within, #yourZip, #form-1-submit').removeAttr('disabled');
    }
    
    
}

$('#within').bind('change keypress', function() {
    var id = $('#within option:selected').val();
    $('#within option').each(function() {
        $(this).removeAttr('selected');
    });
    $('#within option[value=' + id + ']').attr('selected', 'selected');
});





// Onchange Select Boxes Events Start ---------------------------->

function onchangeEvents() {
    //$('#categoty, #make').attr('disabled', true);

    $('#vehicleType').bind('change keypress', function() {
        if (category.length > 0) {
            //$('#categoty').removeAttr('disabled');
            //$('#make').attr('disabled', 'disabled');
            var id = $('#vehicleType option:selected').val();
            //alert(id);
            var mm = '';
            var count = 0;
            if (id != '0' && id != 0) {
                mm += "<option value='0'>Any Category</option>";
                for (i = 0; i < category.length; i++) {
                    if (id == category[i]["VehicleTypeID"]) {
                        mm += "<option value=" + category[i]["Category_id"] + ">" + category[i]["Category_Name"] + "</option>";
                        count++;
                    }
                }
                $('#categoty').empty();
                $('#categoty').append(mm);
            } else {
                mm += "<option value='0'>Any Category</option>";
                var dump = [];
                for (i = 0; i < category.length; i++) {
                    var valid = true;
                    for (k = 0; k < dump.length; k++) {
                        if (dump[k] == category[i]["Category_Name"]) {
                            valid = false;
                        }
                    }
                    if (valid == true) {
                        dump.push(category[i]["Category_Name"]);
                        mm += "<option value=" + category[i]["Category_id"] + ">" + category[i]["Category_Name"] + "</option>";
                        count++;
                    }
                }
                $('#categoty').empty().append(mm);
            }




            //alert(count)
            if (count > 1) {
                $('#categoty').removeAttr('disabled');
                //$('#make').attr('disabled', true);
            } else {
                //$('#category').attr('disabled', 'disabled');
                //$('#categoty, #make').attr('disabled', true);
            }



            /*
            var mm2 = "<option value='0'>Any Make</option>";
            $('#make').empty();
            $('#make').append(mm2);
            //$('#make').attr('disabled', true);
            */



            $('#make').attr('disabled', true);
            if (make.length > 0) {
                //$('#make').removeAttr('disabled');
                //var id = $('#vehicleType option:selected').val();
                //alert(id);
                if (id != 0 && id != '0') {
                    var mm = '';
                    var count = 0;
                    mm += "<option value='0'>Any Make</option>";
                    for (i = 4; i < make.length; i++) {
                        if (id == make[i]["VehicleType"]['#text']) {
                            mm += "<option value=" + make[i]["MakeID"]['#text'] + ">" + make[i]["Make"]['#text'] + "</option>";
                            count++;
                        }
                    }
                    $('#make').empty();
                    if (count > 0) {
                        $('#make').append(mm);
                        $(' #make').removeAttr('disabled');
                    } else {
                        var mm = '';
                        mm += "<option value='0'>Any Make</option>";
                        $('#make').empty();
                        $('#make').append(mm);
                        $(' #make').removeAttr('disabled');
                        //$('#make').attr('disabled', true);

                    }
                    //console.log($('#make'))
                } else {
                    var mm = '';
                    mm += "<option value='0'>Any Make</option>";
                    $('#make').empty().append(mm);



                    /*  -------------*/
                    var dump = [];
                    for (i = 0; i < make.length; i++) {
                        var valid = true;
                        for (k = 0; k < dump.length; k++) {
                            if (dump[k] == make[i]["Make"]['#text']) {
                                valid = false;
                            }
                        }
                        if (valid == true) {
                            dump.push(make[i]["Make"]['#text']);
                            mm = "<option value=" + make[i]["MakeID"]['#text'] + ">" + make[i]["Make"]['#text'] + "</option>";
                            $('#make').append(mm);
                        }
                    }

                    /*  -------------*/
                    //$('#make').append(mm);
                    $('#make').removeAttr('disabled');
                    $('#model').attr('disabled', true);

                }
            }
            // Make Binding End


           


        }
    });


   /*

    $('#categoty').bind('change keypress', function() {
    //alert('Make calling...')
        $('#make').attr('disabled', true);
        if (make.length > 0) {
            //$('#make').removeAttr('disabled');
            var id = $('#vehicleType option:selected').val();
            //alert(id);
            var mm = '';
            var count = 0;
            mm += "<option value='0'>Any Make</option>";
            for (i = 4; i < make.length; i++) {
                if (id == make[i]["VehicleType"]['#text']) {
                    mm += "<option value=" + make[i]["MakeID"]['#text'] + ">" + make[i]["Make"]['#text'] + "</option>";
                    count++;
                }
            }
            $('#make').empty();
            if (count > 0) {
                $('#make').append(mm);
                $('#make').removeAttr('disabled');
            } else {
                var mm = '';
                mm += "<option value='0'>Any Make</option>";
                $('#make').empty();
                $('#make').append(mm);
                $('#make').removeAttr('disabled');
                //$('#make').attr('disabled', true);
            }
            //console.log($('#make')) 
        }
    });
    */


    // Model Binding Start
    $('#make').bind('change keypress', function() {
    var id = $('#make option:selected').val();
    //console.log(id);
        var mm = '';
        mm += "<option value='0'>Any Model</option>";
        $('#model').empty().append(mm);
        //console.log(models)
        for (i = 0; i < models.length; i++) {
            if (id == models[i]["MakeID"]['#text']) {                
                mm = "<option value=" + models[i]["MakeModelID"]['#text'] + ">" + models[i]["Model"]['#text'] + "</option>";
                $('#model').append(mm);
            }
        }
        $('#model').removeAttr('disabled');
    });

    // Model Binding End
    
    
    
}


// Onchange Select Boxes Events End ---------------------------->










// Search Button Submit
function search() {
    //alert('Click');
    var SelectedType = $('#vehicleType option:selected').val();
    var SelectedCategoty = $('#categoty option:selected').val();
    var SelectedMake = $('#make option:selected').val();
    var SelectedModel = $('#model option:selected').val();
    //var SelectedModel = $('#model').val();
    var SelectedDistance = $('#within option:selected').val();
    //console.log('SelectedDistance: ', SelectedDistance)
    var EnteredZip = $('#yourZip').val();
    //console.log('SelectedType: ',SelectedType)
    if (EnteredZip == '' || EnteredZip == null) {
        alert('Enter your ZIP');
    } else if (EnteredZip.length < 5) {
        alert('Enter valid ZIP');
    } else {
        //CarsSearch(carMakeid, CarModalId, ZipCode, WithinZip)
        showSpinner();
        ChekZip(EnteredZip);
        //alert('Make: '+SelectedMake+',  Model:'+SelectedModel+',  Within:'+SelectedDistance+',  ZIP:'+EnteredZip);
    }


};

// Search Button Submit
function search2() {
    //alert('Click');
    var SelectedType = $('#vehicleType option:selected').val();
    var SelectedMake = $('#make option:selected').val();
    var SelectedModel = $('#model').val();
    var SelectedDistance = $('#within option:selected').val();
    var EnteredZip = $('#yourZip').val();

    if (EnteredZip == '' || EnteredZip == null) {
        alert('Enter your ZIP');
    } else if (EnteredZip.length < 5) {
        alert('Enter valid ZIP');
    } else {

        //CarsSearch(carMakeid, CarModalId, ZipCode, WithinZip)
        showSpinner();
        ChekZip2(EnteredZip);



        //alert('Make: '+SelectedMake+',  Model:'+SelectedModel+',  Within:'+SelectedDistance+',  ZIP:'+EnteredZip);
    }
};



// Search Results Display  
function SearchResultsDisplay() {

    try {
    debugger 
        // console.log('SearchResults: '+SearchResults);
        if (SearchResults != undefined) {
        
            resultsLength = SearchResults.length;
            //alert(resultsLength);
            dummyArraySet = SearchResults;
            //$('#totalResultsFound').text(SearchResults.length);
            $('.searchResultsHolder').empty();


            if (SearchResults.length > 0) {
                var res = '';
                //withinZipRange = $('#within  option:selected').text();
                //console.log(SearchResults);

                $('.searchResultsHolder').empty();
                for (i = 0; i < SearchResults.length; i++) {
                    var m = '';
                    var path = ''
                    var withinZIp1 = $('#within option:selected').val();
                    var zip1 = $('#yourZip').val();
                    var resPath = '"' + SearchResults[i]['Carid']['#text'] + '","' + SearchResults[i]['Make']['#text'] + '","' + SearchResults[i]['Model']['#text'] + '","' + zip1 + '","' + withinZIp1 + '","' + SearchResults[i]['TypeName']['#text'] + '"';
                    var thumb1 = '';
                    if (SearchResults[i]['PIC0']['#text'] != 'Emp') {
                        path = SearchResults[i]['PICLOC0']['#text'] + "/" + SearchResults[i]['PIC0']['#text'];
                        for (k = 0; k < 3; k++) {
                            path = path.replace("\\", "/");
                        }
                        path = path.replace("//", "/");
                        path = "http://www.unitedtruckexchange.com/" + path;
                        thumb1 = "<img src='" + path + "' class='thumb' onclick='javascript:EncryptedCarID(" + resPath + ");' width='80' height='50' />";
                    } else {
                        //path = "images/stockMakes/"+SearchResults[i]['Make']['#text']+".jpg";
                        var carMake = SearchResults[i]['TypeName']['#text'];
                        var carModel = SearchResults[i]['Make']['#text'];
                        carMake = carMake.replace(' ', '-');
                        carModel = carModel.replace(' ', '-');
                        if (carModel.indexOf('/') > 0) {
                            carModel = 'Other';
                        }
                        var MakeModel = carMake + "_" + carModel;
                        MakeModel = MakeModel.replace(' ', '-');
                        path = "images/MakeModelThumbs/" + MakeModel + ".jpg";
                        path = "http://www.unitedtruckexchange.com/" + path;

                        thumb1 = "<img src='" + path + "' class='thumb' onclick='javascript:EncryptedCarID(" + resPath + ");' width='80' height='50' /><br><div class='stockPhoto1' >Stock Photo</div>";


                    }





                    m += "<div class='searchResultsBox' ><table style='width:100%'><tr><td style='width:90px; vertical-align:top' class='searchCarThumbHolder'>" + thumb1 + "</td>";
                    m += "<td class='searchcarDetails' style='vertical-align:top'><h4><a href='javascript:EncryptedCarID(" + resPath + ");' class='carName'>" + SearchResults[i]['YearOfMake']['#text'] + " " + SearchResults[i]['TypeName']['#text'] + " " + SearchResults[i]['Make']['#text'] + " " + SearchResults[i]['Model']['#text'] + "</a></h4>";

                    m += "<p><strong>Description: </strong>";

                    var p = SearchResults[i]['ExteriorColor']['#text'];
                    if (p != 'Emp' && p != 'Unspecified') {
                        m += SearchResults[i]['ExteriorColor']['#text'];
                        m += ", ";
                    }
                    var p = SearchResults[i]['NumberOfDoors']['#text'];
                    if (p != 'Emp' && p != 'Unspecified') {
                        m += SearchResults[i]['NumberOfDoors']['#text'];
                        m += ", ";
                    }
                    var p = SearchResults[i]['NumberOfSeats']['#text'];
                    if (p != 'Emp' && p != 'Unspecified') {
                        m += SearchResults[i]['NumberOfSeats']['#text'];
                        m += ", ";
                    }
                    var p = SearchResults[i]['NumberOfCylinder']['#text'];
                    if (p != 'Emp' && p != 'Unspecified') {
                        m += SearchResults[i]['NumberOfCylinder']['#text'];
                        m += ", ";
                    }
                    var p = SearchResults[i]['Transmission']['#text'];
                    if (p != 'Emp' && p != 'Unspecified') {
                        m += SearchResults[i]['Transmission']['#text'];
                    }

                    m += "</p><a href='javascript:void(0);' class='viewA'>View seller details</a><p id='" + SearchResults[i]['Carid']['#text'] + "a' class='details'> <strong>" + SearchResults[i]['SellerType']['#text'] + ": </strong>"
                    if (SearchResults[i]['SellerName']['#text'] != 'Emp' && SearchResults[i]['SellerName']['#text'] != 'Unspecified' && SearchResults[i]['SellerName']['#text'] != 'Other') {
                        m += SearchResults[i]['SellerName']['#text'] + " <span class='det1'>(" + SearchResults[i]['City']['#text'] + ", " + SearchResults[i]['State']['#text'];
                    } else {
                        m += "   <span class='det1'>(";
                    }

                    if (SearchResults[i]['City']['#text'] != 'Emp') {
                        var city = SearchResults[i]['City']['#text'];
                        city = $.trim(city);
                        m += city + ", ";
                    }

                    if (SearchResults[i]['State']['#text'] != 'Emp') {
                        m += SearchResults[i]['State']['#text']
                    }

debugger

                    // Phone Formate  Start
if (SearchResultsArray[i]['Phone']['#text'].length == 10 && SearchResultsArray[i]['Phone']['#text'] != 'undefined' && SearchResultsArray[i]['Phone']['#text'] != undefined && SearchResultsArray[i]['Phone']['#text'] != null) {
                    debugger 
                        var custPhone = SearchResultsArray[i]['Phone']['#text'];
                        var finalPhone = '';
                        for (ph = 0; ph < 10; ph++) {
                            if (ph == 3) {
                                finalPhone += "-";
                            }
                            if (ph == 6) {
                                finalPhone += "-";
                            }
                            finalPhone += custPhone.charAt(ph);
                        }
                    } else {
                    finalPhone = '';
                    }
                    // Phone Formate Ebnd



                    m += "</span> )</span><br /><span class='userNumber'><strong>Phone: </strong><label class='custphone'>" + finalPhone + "</label></span>";


                    if (SearchResults[i]['Email']['#text'] != 'Emp' && SearchResults[i]['Email']['#text'] != 'Unspecified') {
                        m += ", <strong>Email: </strong><a href='mailto:" + SearchResults[i]['Email']['#text'] + "'>" + SearchResults[i]['Email']['#text'] + "</a>";
                    }
                    m += "</p></td>";

                    m += "<td class='searchResultsBox3' style='vertical-align:top; width:185px;' ><table style='width:100%' class='subInfo searchCarCheckBox' cellspacing='0' cellpadding='0' ><tr class='subInfoHed'><td style='width:85px;'><strong>Mileage</strong></td><td><strong>Price</strong></td></tr><tr><td >";

                    if (SearchResults[i]['Mileage']['#text'] != 'Emp' && SearchResults[i]['Mileage']['#text'] != '0' && SearchResults[i]['Mileage']['#text'] != 'Unspecified') {
                        m += "<label class='mileage'>" + parseInt(SearchResults[i]['Mileage']['#text']) + "</label> mi</td>"
                    } else {
                        m += "</td>"
                    }

                    if (SearchResults[i]['Price']['#text'] != 'Emp' && SearchResults[i]['Price']['#text'] != '0' && SearchResults[i]['Price']['#text'] != 'Unspecified') {
                        m += "<td class='price'>" + parseInt(SearchResults[i]['Price']['#text']) + "</td></tr>"
                    } else {
                        m += "<td><span class='price2b'>Call for Price</span></td></tr>"
                    }

                    if (SearchResults[i]['Price']['#text'] != 'Emp' && SearchResults[i]['Price']['#text'] != '0' && SearchResults[i]['Price']['#text'] != 'Unspecified') {
                        m += "<td class='price'>" + parseInt(SearchResults[i]['Price']['#text']) + "</td></tr>"
                    } else {
                    m += "<td><span class='price2b'>Call for Price</span></td></tr>"
                    }

                    m += "<tr class='subInfoHed'><td><strong>Length</strong></td><td><strong>Fuel</strong></td><td></td></tr><tr class='last'><td><label>"

                    if (SearchResults[i]['Length']['#text'] != 'Emp' && SearchResults[i]['Length']['#text'] != '0' && SearchResults[i]['Length']['#text'] != 'Unspecified') {
                        m += SearchResults[i]['Length']['#text'] + " ft</label></td>"
                    } else {
                        m += "</label></td>"
                    }

                    if (SearchResults[i]['Fueltype']['#text'] != 'Emp' && SearchResults[i]['Fueltype']['#text'] != '0' && SearchResults[i]['Fueltype']['#text'] != 'Unspecified') {
                        m += "<td>" + SearchResults[i]['Fueltype']['#text'] + "</td><td align='center'></td></tr></table></td></tr></table></div>";
                    } else {
                        m += "<td></td><td align='center'></td></tr></table></td></tr></table></div>";
                    }

                    $('.searchResultsHolder').append(m);
                }
                //$('.custphone').usphone();
                //$(".custphone").mask("999-999-9999");
                $('.price').formatCurrency();
                $('.mileage').formatCurrency({
                    symbol: ' '
                });




                $('a.viewA').click(function() {
                    //alert($(this).next("span").attr('id'))
                    $(this).hide();
                    $(this).next("p").show();

                });
            }

            //showSpinner();
            hideSpinner();

        } else {
            $('#totalResultsFound').text('0');
            $('#PaginationBlock').hide();
            $('.searchResultsHolder').empty();
            $('.searchResultsHolder').append("<h2 style='color:#71ac37; text-align:center; line-height:200px;'>No records found..!</h2>");
            hideSpinner();
        }

        //arrowsAct();
    } catch (ex) { }

}

function searchCri() {
    //alert(SessionArray[0]+', '+SessionArray[1]+', '+SessionArray[3]+', '+SessionArray[2])

    // make1, Modal1, ZipCode1, WithinZipNew; 
    //console.log('ok');

    //WithinZipNew=WithinZipNew.split("#").join("");;

    //withinZipRange = SessionArray[3];
    $('#within option').each(function() {
        $(this).removeAttr('selected');
    });


    //$('#make option[text='+make1+']').attr('selected', 'selected'); 
    $('#vehicleType option').each(function() {
        $(this).removeAttr('selected');
    });


    $('#vehicleType option').each(function() {
        if ($(this).text() == VehicleType1) {
            $(this).attr('selected', 'selected');
        }
    });



    var id = $('#vehicleType option:selected').val();
    var mm = '';
    if (id != '0') {
        mm += "<option value='0'>Any Category</option>";
        for (i = 0; i < category.length; i++) {
            if (id == category[i]["VehicleTypeID"]) {
                mm += "<option value=" + category[i]["Category_id"] + ">" + category[i]["Category_Name"] + "</option>";
            }
        }
        //console.log(category)
        //console.log(id)
        $('#categoty').empty().append(mm);
    } else {
        mm += "<option value='0'>Any Category</option>";
        var dump = [];
        for (i = 0; i < category.length; i++) {
            var valid = true;
            for (k = 0; k < dump.length; k++) {
                if (dump[k] == category[i]["Category_Name"]) {
                    valid = false;
                }
            }
            if (valid == true) {
                dump.push(category[i]["Category_Name"]);
                mm += "<option value=" + category[i]["Category_id"] + ">" + category[i]["Category_Name"] + "</option>";
            }
        }

        $('#categoty').empty().append(mm);
    }


    $('#categoty option').each(function() {
        $(this).removeAttr('selected');
    });
    $('#categoty option').each(function() {
        if ($(this).text() == category1) {
            $(this).attr('selected', 'selected');
        }
    });

    // $('#categoty option[value='+id+']').attr('selected', 'selected'); 
    $('#categoty').removeAttr('disabled');



    if (LoadingPage == 1) {
        //$('#make').removeAttr('disabled');
        var id = $('#vehicleType option:selected').val();
        var mm = '';
        var count = 0;
        mm += "<option value='0'>All makes</option>";
        for (i = 0; i < make.length; i++) {
            if (id == make[i]["RvtypeID"]) {
                mm += "<option value=" + make[i]["MakeID"] + ">" + make[i]["Make"] + "</option>";
                count++;
            }
        }
        $('#make').empty();
        if (count > 0) {
            $('#make').append(mm);
        } else {
            var mm = '';
            mm += "<option value='0'>All makes</option>";
            $('#make').empty();
            $('#make').append(mm);
            //$('#make').attr('disabled', true);

        }
        $('#make option').each(function() {
            $(this).removeAttr('selected');
        });

        $('#make option').each(function() {
            if ($(this).text() == make1) {
                $(this).attr('selected', 'selected');
            }
        });
    }

    $('#within option').each(function() {
        $(this).removeAttr('selected');
    });
    $('#within option[value=' + WithinZipNew + ']').attr('selected', 'selected');

    //$('.mileage2').empty();
    //var str = $('#within option[text=' + WithinZipNew + ']').text()
    //var newStr = str.substring(0, str.length - 6);
    // alert(newStr)
    //$('.mileage2').text(newStr);

    if (ZipCode1.length >= 4 && ZipCode1 !== '' && ZipCode1 != null && ZipCode1 != undefined && LoadingPage != 3) {
        $('#yourZip').val(ZipCode1);
    } else if (LoadingPage != 3) {
        $('#yourZip').val('');
    }

    //$('#vehicleType, #categoty, #within, #yourZip, #form-1-submit').removeAttr('disabled');


}

// Search Results Display with FILTER  
function SearchResultsDisplayFilter(SearchResultsArray) {

    ///console.log(SearchResultsArray[i]['PIC0']['#text']);    

    withinZipRange = $('#within option:selected').text();
    //alert(withinZipRange);
    hideSpinner();
    if ((SearchResultsArray != undefined && SearchResultsArray != null) || (SearchResultsArray['Make'] != null && SearchResultsArray['Make'] != '')) {
        resultsLength = SearchResultsArray.length;
        //alert(resultsLength);
        //if(SearchResultsArray.length > 0 && SearchResultsArray[0] != null && SearchResultsArray[0] != '' && SearchResultsArray[0] != [] ){
        // $('#totalResultsFound').text(SearchResultsArray.length);
        //}
        $('.searchResultsHolder').empty();



        if (SearchResultsArray != null && SearchResultsArray != '' && SearchResultsArray.length > 0) {

            $('#PaginationBlock').show();
            var res = '';
            $('.searchResultsHolder').empty();
            //console.log(SearchResultsArray);
            for (i = 0; i < SearchResultsArray.length; i++) {



                //$('.searchResultsHolder').append("<div class='searchResultsBox' ><table style='width:100%'><tr><td style='width:90px;' class='searchCarThumbHolder'><img src='images/SearchResultsCarsThumbs/thumb1.png' class='thumb' onclick='javascript:FindCarID("+SearchResultsArray[i]['Carid']['#text']+");' /><br /></td><td class='searchcarDetails'><h4><a href='javascript:FindCarID("+SearchResultsArray[i]['Carid']['#text']+");' class='carName'>"+SearchResultsArray[i]['YearOfMake']['#text']+" "+SearchResultsArray[i]['Make']['#text']+" "+SearchResultsArray[i]['Model']['#text']+"</a></h4><p><strong>Description: </strong>"+SearchResultsArray[i]['ExteriorColor']['#text']+", "+SearchResultsArray[i]['NumberOfDoors']['#text']+" with "+SearchResultsArray[i]['NumberOfSeats']['#text']+", "+SearchResultsArray[i]['NumberOfCylinder']['#text']+", "+SearchResultsArray[i]['Transmission']['#text']+"</p><a href='javascript:void(0);' class='viewA'>View seller details</a><p id='"+SearchResultsArray[i]['Carid']['#text']+"a' class='details'> <strong>"+SearchResultsArray[i]['SellerType']['#text']+": </strong>"+SearchResultsArray[i]['SellerName']['#text']+" <span class='det1'>("+SearchResultsArray[i]['City']['#text']+", "+SearchResultsArray[i]['State']['#text']+" - Within <span class='mileage'>"+withinZipRange+"</span> mi)</span><br /><span class='userNumber'><strong>Phone: </strong>"+SearchResultsArray[i]['Phone']['#text']+"</span>, <strong>Email: </strong><a href='mailto:"+SearchResultsArray[i]['Email']['#text']+"'>"+SearchResultsArray[i]['Email']['#text']+"</a> </p></td><td class='searchResultsBox3' ><table class='subInfo searchCarCheckBox' cellspacing='0' cellpadding='0' ><tr class='subInfoHed'><td><strong>Mileage</strong></td><td><strong>Price</strong></td></tr><tr><td><label class='mileage'>"+parseInt(SearchResultsArray[i]['Mileage']['#text'])+"</label> mi</td><td class='price'>"+ parseInt(SearchResultsArray[i]['Price']['#text'])+"</td></tr><tr class='subInfoHed'><td><strong>Body</strong></td><td><strong>Fuel</strong></td><td></td></tr><tr class='last'><td><label>"+SearchResultsArray[i]['Bodytype']['#text']+"</label></td><td>"+SearchResultsArray[i]['Fueltype']['#text']+"</td><td align='center'></td></tr></table></td></tr></table></div>");
                var m = '';
                var path = ''
                var withinZIp1 = '3';
                var zip1 = $('#yourZip').val();

                //console.log(zip1);
                var resPath = '"' + SearchResultsArray[i]['Carid']['#text'] + '","' + SearchResultsArray[i]['Make']['#text'] + '","' + SearchResultsArray[i]['Model']['#text'] + '","' + zip1 + '","' + withinZIp1 + '","' + SearchResultsArray[i]['TypeName']['#text'] + '","' + SearchResultsArray[i]['Category']['#text'] + '"';
                //console.log(resPath)
                var thumb1 = '';


                if (SearchResultsArray[i]['PIC0']['#text'] != 'Emp') {
                    path = SearchResultsArray[i]['PICLOC0']['#text'] + "/" + SearchResultsArray[i]['PIC0']['#text'];
                    for (k = 0; k < 3; k++) {
                        path = path.replace("\\", "/");
                    }
                    path = path.replace("//", "/");
                    path = "http://www.unitedtruckexchange.com/" + path;
                    thumb1 = "<img src='" + path + "' class='thumb' onclick='javascript:EncryptedCarID(" + resPath + ");' width='200' height='150' />";
                } else {
                    //path = "images/stockMakes/"+SearchResultsArray[i]['Make']['#text']+".jpg";
                    var carMake = SearchResultsArray[i]['TypeName']['#text'];
                    var carModel = SearchResultsArray[i]['Make']['#text'];
                    carMake = carMake.replace(' ', '-');
                    carModel = carModel.replace(' ', '-');
                    if (carModel.indexOf('/') > 0) {
                        carModel = 'Other';
                    }
                    var MakeModel = carMake + "_" + carModel;
                    MakeModel = MakeModel.replace(' ', '-');
                    path = "images/MakeModelThumbs/" + MakeModel + ".jpg";
                    path = "http://www.unitedtruckexchange.com/" + path;
                    thumb1 = "<img src='" + path + "' class='thumb' onclick='javascript:EncryptedCarID(" + resPath + ");' width='200' height='150' /><br><div class='stockPhoto1' >Stock Photo</div>";


                }






                m += "<div class='searchResultsBox' ><table style='width:100%'><tr><td colspan='2'><h4><a href='javascript:EncryptedCarID(" + resPath + ");' class='carName'>" + SearchResultsArray[i]['YearOfMake']['#text'] + " " + SearchResultsArray[i]['TypeName']['#text'] + " " + SearchResultsArray[i]['Category']['#text'] + " " + SearchResultsArray[i]['Make']['#text'] + " " + SearchResultsArray[i]['Model']['#text'] + "</a>";
                
                m += "<div style='width:200px; float:right; padding:inherit; text-align:right'>";
                
                if (SearchResultsArray[i]['Price']['#text'] != 'Emp' && SearchResultsArray[i]['Price']['#text'] != '0' && SearchResultsArray[i]['Price']['#text'] != 'Unspecified') {
                    m += "<label class='price'>" + SearchResultsArray[i]['Price']['#text'] + "</label>";
                } else {
                    m += "<label class='price2b'>Call for Price</label>";
                }                
                m += "</div></h4></td></tr>"
               
                
                m += "<tr><td style='width:210px; vertical-align:top' class='searchCarThumbHolder'>" + thumb1;
                // m += "<div class='stockPhoto1'><a href='#'>View photos</a></div></td>"
               // m += "<div class='stockPhoto1'><a href='javascript:GetCarPictures(" + SearchResultsArray[i]['Carid']['#text'] + ");'>View photos</a></div></td>"


                m += "<td class='searchcarDetails' style='vertical-align:top'><p>"

                var p = SearchResultsArray[i]['Description']['#text'];


                if (p != null && p != undefined && p != 'Emp' && p != 'Unspecified' && p != 'Other') {

                    if (SearchResultsArray[i]['Description']['#text'].length > 250) {
                        m += SearchResultsArray[i]['Description']['#text'].substring(0, 250);
                        m += "..."
                    } else {
                        m += SearchResultsArray[i]['Description']['#text'];
                    }


                }

                m += "</p>";
                m += "<p><strong>";
                if (SearchResultsArray[i]['City']['#text'] != 'Emp') {
                    var city = SearchResultsArray[i]['City']['#text'];
                    city = $.trim(city);
                    m += city + ", ";
                }



                if (SearchResultsArray[i]['State']['#text'] != 'Emp' && SearchResultsArray[i]['State']['#text'] != 'UN') {
                    m += SearchResultsArray[i]['State']['#text'];
                }

                m += "</strong>";

                if (SearchResultsArray[i]['Mileage']['#text'] != 'Emp' && SearchResultsArray[i]['Mileage']['#text'] != '0') {
                    m += "<i>(~" + SearchResultsArray[i]['Mileage']['#text'] + "miles traveled)</i><br />";
                } else {
                    m += "<br />";
                }

                if (SearchResultsArray[i]['Address1']['#text'] != 'Emp' && SearchResultsArray[i]['Address1']['#text'] != '0') {
                    m += SearchResultsArray[i]['Address1']['#text'] + "<br />";
                }

                if (SearchResultsArray[i]['Phone']['#text'] != 'Emp' && SearchResultsArray[i]['Phone']['#text'] != '0' && SearchResultsArray[i]['Phone']['#text'] != 'undefined' && SearchResultsArray[i]['Phone']['#text'] != undefined) {

                    var phone = SearchResultsArray[i]['Phone']['#text'];
                    
                    
                        //console.log(phone + ' , ');
                        var finalPhone = '';
                        for (ph = 0; ph < 10; ph++) {
                            
                            if (ph == 3) {
                                finalPhone += "-";
                            }
                            if (ph == 6) {
                                finalPhone += "-";
                            }
                            finalPhone += phone.charAt(ph);
                        }
                       // console.log(finalPhone);




                        m += "<label class='custphone'>" + finalPhone + "</label><br /></p>";
                } else {
                    m += "</p>";
                }
                var postDate = SearchResultsArray[i]['DateOfPosting']['#text'];
                postDate = postDate.replace('T', '  Time:');
                //console.log(postDate);
                m += "<div class='lastUpdatedtext'>Added: " + postDate + "</div>";
                    
                m += "</td></tr></tbody></table></div>"

                $('.searchResultsHolder').append(m)

            } // For loop close


            // $('.custphone').usphone();
            $('.price').formatCurrency();
            $('.mileage').formatCurrency({
                symbol: ' '
            });
            $('#Filter').find('input[type=checkbox]').each(function() {
                $(this).removeAttr('disabled');
            });
        } else if (SearchResultsArray['Make'] != null && SearchResultsArray['Make'] != '') {
            resultsLength = 1;
            oneReord(SearchResultsArray);
        } else {
            $('#totalResultsFound').text('0');
            $('#PaginationBlock').hide();
            $('.searchResultsHolder').empty();
            $('.searchResultsHolder').append("<h2 style='color:#71ac37; text-align:center; line-height:200px;'>No records found..!</h2>");
            //alert('No records found..!');	
            $('#Filter').find('input[type=checkbox]').each(function() {
                $(this).attr('disabled', 'disabled')
            });
        }
    } else {
        $('#totalResultsFound').text('0');
        $('#PaginationBlock').hide();
        $('.searchResultsHolder').empty();
        $('.searchResultsHolder').append("<h2 style='color:#71ac37; text-align:center; line-height:200px;'>No records found..!</h2>");
        //alert('No records found..!');	
        $('#Filter').find('input[type=checkbox]').each(function() {
            $(this).attr('disabled', 'disabled')
        });
    }
    hideSpinner();





    /* $('#botAd iframe, #botAd table, #botAd img, #botAd td').width('642')
    $('#botAd iframe, #botAd table, #botAd img').width('642'); 
    $('#botAd td').width('209');  
    $('#botAd img').height('90');
    */
}

function oneReord(SearchResultsArray) {
    var m = '';
    var path = ''
    var withinZIp1 = $('#within option:selected').val();
    var zip1 = $('#yourZip').val();
    var resPath = '"' + SearchResultsArray['Carid']['#text'] + '","' + SearchResultsArray['Make']['#text'] + '","' + SearchResultsArray['Model']['#text'] + '","' + zip1 + '","' + withinZIp1 + '","' + SearchResultsArray['TypeName']['#text'] + '"';
    var thumb1 = '';
    if (SearchResultsArray['PIC0']['#text'] != 'Emp') {
        path = SearchResultsArray['PICLOC0']['#text'] + "/" + SearchResultsArray['PIC0']['#text'];
        for (k = 0; k < 3; k++) {
            path = path.replace("\\", "/");
        }
        path = path.replace("//", "/");
        thumb1 = "<img src='" + path + "' class='thumb' onclick='javascript:EncryptedCarID(" + resPath + ");' width='80' height='50' />";
    } else {
        //path = "images/stockMakes/"+SearchResultsArray['Make']['#text']+".jpg";
        var carMake = SearchResultsArray['TypeName']['#text'];
        var carModel = SearchResultsArray['Make']['#text'];
        carMake = carMake.replace(' ', '-');
        carModel = carModel.replace(' ', '-');
        if (carModel.indexOf('/') > 0) {
            carModel = 'Other';
        }
        var MakeModel = carMake + "_" + carModel;
        MakeModel = MakeModel.replace(' ', '-');
        path = "images/MakeModelThumbs/" + MakeModel + ".jpg";
        thumb1 = "<img src='" + path + "' class='thumb' onclick='javascript:EncryptedCarID(" + resPath + ");' width='80' height='50' /><br><div class='stockPhoto1' >Stock Photo</div>";
    }

    m += "<div class='searchResultsBox' ><table style='width:100%'><tr><td style='width:90px; vertical-align:top' class='searchCarThumbHolder'>" + thumb1 + "</td>";
    m += "<td class='searchcarDetails' style='vertical-align:top'><h4><a href='javascript:EncryptedCarID(" + resPath + ");' class='carName'>" + SearchResultsArray['YearOfMake']['#text'] + " " + SearchResultsArray['TypeName']['#text'] + " " + SearchResultsArray['Make']['#text'] + " " + SearchResultsArray['Model']['#text'] + "</a></h4>";
    m += "<p><strong>Description: </strong>";

    var p = SearchResultsArray['ExteriorColor']['#text'];
    if (p != 'Emp' && p != 'Unspecified' && p != 'Other') {
        m += SearchResultsArray['ExteriorColor']['#text'];
        m += ", ";
    }
    var p = SearchResultsArray['NumberOfDoors']['#text'];
    if (p != 'Emp' && p != 'Unspecified' && p != 'Other') {
        m += SearchResultsArray['NumberOfDoors']['#text'];
        m += ", ";
    }
    var p = SearchResultsArray['NumberOfSeats']['#text'];
    if (p != 'Emp' && p != 'Unspecified' && p != 'Other') {
        m += SearchResultsArray['NumberOfSeats']['#text'];
        m += ", ";
    }
    var p = SearchResultsArray['NumberOfCylinder']['#text'];
    if (p != 'Emp' && p != 'Unspecified' && p != 'Other') {
        m += SearchResultsArray['NumberOfCylinder']['#text'];
        m += ", ";
    }
    var p = SearchResultsArray['Transmission']['#text'];
    if (p != 'Emp' && p != 'Unspecified' && p != 'Other') {
        m += SearchResultsArray['Transmission']['#text'];
    }

    m += "</p><a href='javascript:void(0);' class='viewA'>View seller details</a><p id='" + SearchResultsArray['Carid']['#text'] + "a' class='details'><strong>Seller Type: </strong> " + SearchResultsArray['SellerType']['#text'] + "<br><strong>Seller Details: </strong>"
    if (SearchResultsArray['SellerName']['#text'] != 'Emp' && SearchResultsArray['SellerName']['#text'] != 'Unspecified' && SearchResultsArray['SellerName']['#text'] != 'Other') {
        m += SearchResultsArray['SellerName']['#text'] + " <span class='det1'>(" + SearchResultsArray['City']['#text'] + ", " + SearchResultsArray['State']['#text'];
    } else {
        m += "   <span class='det1'>    ";
    }

    if (SearchResultsArray['City']['#text'] != 'Emp') {
        var city = SearchResultsArray['City']['#text'];
        city = $.trim(city);
        m += city + ", ";
    }

    if (SearchResultsArray['State']['#text'] != 'Emp' && SearchResultsArray['State']['#text'] != 'UN') {
        m += SearchResultsArray['State']['#text']
    }


    m += "</span></span><br /><span class='userNumber'><strong>Phone: </strong>";
    
    // Phone Formate  Start
    if (SearchResultsArray['Phone']['#text'].length == 10 && SearchResultsArray['Phone']['#text'] != 'undefined' && SearchResultsArray['Phone']['#text'] != null) {
        var custPhone = parseInt(SearchResultsArray['Phone']['#text']);
        var finalPhone = '';
        for (ph = 0; ph < 10; ph++) {
            if (ph == 3) {
                finalPhone += "-";
            }
            if (ph == 6) {
                finalPhone += "-";
            }
            finalPhone += custPhone.charAt(ph);
        }
    } else {
        finalPhone = '';
    }
    // Phone Formate  End

    m += finalPhone + "</span>";

    if (SearchResultsArray['Email']['#text'] != 'Emp' && SearchResultsArray['Email']['#text'] != 'Unspecified') {
        m += ", <strong>Email: </strong><a href='mailto:" + SearchResultsArray['Email']['#text'] + "'>" + SearchResultsArray['Email']['#text'] + "</a>";
    }
    m += "</p></td>";

    m += "<td class='SearchResultsArrayBox3' style='vertical-align:top; width:185px;' ><table style='width:100%' class='subInfo searchCarCheckBox' cellspacing='0' cellpadding='0' ><tr class='subInfoHed'><td style='width:85px;'><strong>Mileage</strong></td><td><strong>Price</strong></td></tr><tr><td>";

    if (SearchResultsArray['Mileage']['#text'] != 'Emp' && SearchResultsArray['Mileage']['#text'] != '0' && SearchResultsArray['Mileage']['#text'] != 'Unspecified') {
        m += "<label class='mileage'>" + parseInt(SearchResultsArray['Mileage']['#text']) + "</label> mi</td>"
    } else {
        m += "</td>"
    }

    if (SearchResultsArray['Price']['#text'] != 'Emp' && SearchResultsArray['Price']['#text'] != '0' && SearchResultsArray['Price']['#text'] != 'Unspecified') {
        m += "<td class='price'>" + parseInt(SearchResultsArray['Price']['#text']) + "</td></tr>"
    } else {
        m += "<td></td></tr>"
    }


    m += "<tr class='subInfoHed'><td><strong>Length</strong></td><td><strong>Fuel</strong></td><td></td></tr><tr class='last'><td><label>"

    if (SearchResultsArray['Length']['#text'] != 'Emp' && SearchResultsArray['Length']['#text'] != '0' && SearchResultsArray['Length']['#text'] != 'Unspecified') {
        m += SearchResultsArray['Length']['#text'] + " ft</label></td>"
    } else {
        m += "</label></td>"
    }

    if (SearchResultsArray['Fueltype']['#text'] != 'Emp' && SearchResultsArray['Fueltype']['#text'] != '0' && SearchResultsArray['Fueltype']['#text'] != 'Unspecified') {
        m += "<td>" + SearchResultsArray['Fueltype']['#text'] + "</td><td align='center'></td></tr></table></td></tr></table></div>";
    } else {
        m += "<td></td><td align='center'></td></tr></table></td></tr></table></div>";
    }

    $('.searchResultsHolder').append(m);





    // View seller details Click Event start
    $('a.viewA').click(function() {
        //alert($(this).next("span").attr('id'))
        $(this).hide();
        $(this).next("p").show();
    }); // View seller details Click Event Close
    $('.price').formatCurrency();
    $('.mileage').formatCurrency({
        symbol: ' '
    });
}


function newSearch() {
    var id0 = $('#model option:selected').text();
    var id1 = $('#modelA option:selected').text();
    var id2 = $('#modelB option:selected').text();
    var SelectedType = $('#vehicleType option:selected').text();
    var SelectedMake = $('#make option:selected').text();
    var SelectedModel = $('#model').val();
    var SelectedDistance = $('#within option:selected').val();
    var EnteredZip = $('#yourZip').val();
    $('.leftArrow div').removeClass('leftAct');
    $('.leftArrow div').addClass('leftDis');
    page = 1;
    PAGEFIRST = 1;

    if (EnteredZip == '' || EnteredZip == null) {
        alert('Enter your ZIP');
    } else if (EnteredZip.length < 5) {
        alert('Enter valid ZIP');
    } else {
        if ($('.make1:visible').length > 0 && $('.make2:visible').length > 0) {
            if (id1 != 'Select model' && id1 != '' && id1 != null && id2 != 'Select model' && id2 != '' && id2 != null) {
                // if(id0 != id1 != id2){
                //GetCarsMultiSearch(array); makeA
                var searchArray1 = [];
                var make1 = $('#makeA option:selected').text();
                var make2 = $('#makeB option:selected').text();
                showSpinner();
                searchArray1.push(SelectedMake + ',' + SelectedModel + ',' + EnteredZip + ',' + SelectedDistance + ',' + '1' + ',' + '25' + ',' + 'price');
                searchArray1.push(make1 + ',' + id1 + ',' + EnteredZip + ',' + SelectedDistance + ',' + '1' + ',' + '25' + ',' + 'price');
                searchArray1.push(make2 + ',' + id2 + ',' + EnteredZip + ',' + SelectedDistance + ',' + '1' + ',' + '25' + ',' + 'price');
                GetCarsMultiSearch(searchArray1);

                //}else{
                //    alert('Duplicate search criteria...')
                // }
            } else {
                alert('Select Make & Model');
            }
        } else if ($('.make1:visible').length <= 0 && $('.make2:visible').length > 0) {
            if (id2 != 'Select model' && id2 != '' && id2 != null) {
                // if(id0 != id2){
                var searchArray1 = [];
                var make2 = $('#makeB option:selected').text();
                showSpinner();
                searchArray1.push(SelectedMake + ',' + SelectedModel + ',' + EnteredZip + ',' + SelectedDistance + ',' + '1' + ',' + '25' + ',' + 'price');
                searchArray1.push(make2 + ',' + id2 + ',' + EnteredZip + ',' + SelectedDistance + ',' + '1' + ',' + '25' + ',' + 'price');
                GetCarsMultiSearch(searchArray1);

                // }else{
                //    alert('Duplicate search criteria...')
                // }
            } else {
                alert('Select Make & Model');
            }
        } else if ($('.make1:visible').length > 0 && $('.make2:visible').length <= 0) {
            if (id1 != 'Select model' && id1 != '' && id1 != null) {
                //if(id0 != id1){
                var searchArray1 = [];
                var make1 = $('#makeA option:selected').text();
                showSpinner();
                searchArray1.push(SelectedMake + ',' + SelectedModel + ',' + EnteredZip + ',' + SelectedDistance + ',' + '1' + ',' + '25' + ',' + 'price', SelectedType);
                searchArray1.push(make1 + ',' + id1 + ',' + EnteredZip + ',' + SelectedDistance + ',' + '1' + ',' + '25' + ',' + 'price', SelectedType);
                GetCarsMultiSearch(searchArray1);

                // }else{
                //     alert('Duplicate search criteria...')
                // }
            } else {
                alert('Select Make & Model');
            }
        } else if ($('.make1:visible').length <= 0 && $('.make2:visible').length <= 0) {
            if (id0 != 'Select model' && id0 != '' && id0 != null) {
                showSpinner();
                CarsSearch(SelectedMake, SelectedModel, EnteredZip, SelectedDistance, '1', '25', 'price', SelectedType);

            } else {

            }
        } else {
            if (id0 != 'Select model' && id0 != '' && id0 != null) {
                showSpinner();
                CarsSearch(SelectedMake, SelectedModel, EnteredZip, SelectedDistance, '1', '25', 'price', SelectedType);

            } else {

            }
        }
    }

    //filterChecked();
}

/*  carDetails Array
function carDetails(id){
//alert(id);
FindCarID(id);
}
*/

function carDetailsDisplay() {

    if (carDetails != undefined) {

        //console.log(carDetails);
        //clentZip = carDetails['ZipCode']['#text'];
        
        
        //2011 Mercedes-Benz SLS AMG - <span>$229,900</span><a href="#" class="galClose">&nbsp;</a>
        var title = '';
        title += carDetails['YearOfMake']['#text'] + " " + carDetails['TypeName']['#text'] + " " + carDetails['Category']['#text'] + "" + carDetails['Make']['#text'] + "  " + carDetails['Model']['#text'] + " - <span>$" + carDetails['Price']['#text'] + "</span><a href='#' class='galClose'>&nbsp;</a>";
        //console.log(title)
        $('.galleryHolder .gallery1 h2').append(title);

        var img1 = '';
        var imgGallery = ''
        var imgCount = 0;
        var path = "" + carDetails['PICLOC0']['#text'] + "/" + carDetails['PIC0']['#text'] + "";

        for (k = 0; k < 5; k++) {
            path = path.replace("\\", "/");
        }
        path = path.replace("//", "/");
        path = "http://www.unitedtruckexchange.com/" + path;
        $('.slide1a').attr('src', path);
        //console.log(path)
        for (i = 1; i < 10; i++) {
            if (carDetails['PIC' + i]['#text'] != 'Emp' && carDetails['PICLOC' + i]['#text'] != 'Emp') {
                var path = "" + carDetails['PICLOC' + i]['#text'] + "/" + carDetails['PIC' + i]['#text'] + "";
                for (k = 0; k < 5; k++) {
                    path = path.replace("\\", "/");
                }
                path = path.replace("//", "/");
                path = "http://www.unitedtruckexchange.com/" + path;
                img1 += "<li><a href='#'><img class='galThumbs' src='" + path + "'  /></a></li>";
                imgGallery += "<img src='" + path + "' data-description='" + carDetails['Description']['#text'] + "'>";

                //alert(path);
            } else {
                imgCount++;
            }
        }

        if (imgCount > 9) {
            var path2 = "'http://www.unitedtruckexchange.com/images/stockMakes/" + carDetails['Make']['#text'] + ".jpg'";
            var carMake = carDetails['Make']['#text'];
            var carModel = carDetails['Model']['#text'];

            carMake = carMake.replace(' ', '-');
            carModel = carModel.replace(' ', '-');

            if (carModel.indexOf('/') > 0) {
                carModel = 'Other';
            }
            var MakeModel = carMake + "_" + carModel;
            //alert(MakeModel);
            MakeModel = MakeModel.replace(' ', '-');
            path2 = "http://www.unitedtruckexchange.com/images/MakeModelThumbs/" + MakeModel + ".jpg";
            $('.slide1a').attr('src', path2)

            var path1 = "'http://www.unitedtruckexchange.com/images/no-image.jpg'";
            //alert(path2);
            img1 += "<li><a href='#'><img class='galThumbs' src=" + path2 + "  /></a><div class='stock2'>Stock Photo</div></li>";
            imgGallery += "<img src='" + path2 + "' data-description='" + carDetails['Description']['#text'] + "'>";
            $('.sliderHolder ul').empty();
            $('.sliderHolder ul').append(img1);

            $('.galleryHolder .gallery1 #galleria').empty().append(imgGallery);


        } else {
            $('.sliderHolder ul').empty().append(img1);
            $('.galleryHolder .gallery1 #galleria').empty().append(imgGallery);

        }

        var year = '';
        if (carDetails['YearOfMake']['#text'] && carDetails['YearOfMake']['#text'] != undefined && carDetails['YearOfMake']['#text'] != null && carDetails['YearOfMake']['#text'] != 'Emp') {
            year = carDetails['YearOfMake']['#text']
        }

        var type = '';
        if (carDetails['TypeName']['#text'] && carDetails['TypeName']['#text'] != undefined && carDetails['TypeName']['#text'] != null && carDetails['TypeName']['#text'] != 'Emp') {
            type = carDetails['TypeName']['#text']
        }
        var category = '';
        if (carDetails['Category']['#text'] && carDetails['Category']['#text'] != undefined && carDetails['Category']['#text'] != null && carDetails['Category']['#text'] != 'Emp') {
            category = carDetails['Category']['#text']
        }
        var make = '';
        if (carDetails['Make']['#text'] && carDetails['Make']['#text'] != undefined && carDetails['Make']['#text'] != null && carDetails['Make']['#text'] != 'Emp') {
            make = carDetails['Make']['#text']
        }
        var model = '';
        if (carDetails['Model']['#text'] && carDetails['Model']['#text'] != undefined && carDetails['Model']['#text'] != null && carDetails['Model']['#text'] != 'Emp') {
            model = carDetails['Model']['#text']
        }
        var location = '';
        if (carDetails['Address1']['#text'] && carDetails['Address1']['#text'] != undefined && carDetails['Address1']['#text'] != null && carDetails['Address1']['#text'] != 'Emp') {
            location = carDetails['Address1']['#text']
        }
        var condition = '';
        if (carDetails['ConditionDescription']['#text'] && carDetails['ConditionDescription']['#text'] != undefined && carDetails['ConditionDescription']['#text'] != null && carDetails['ConditionDescription']['#text'] != 'Emp') {
            condition = carDetails['ConditionDescription']['#text']
        }



        $('.year').empty().append(year);
        $('.type').empty().append(type);
        $('.category').empty().append(category);
        $('.make').empty().append(make);
        $('.model').empty().append(model);
        $('.location').empty().append(location);
        $('.condition').empty().append(condition);



        $('a').each(function() {
            if ($(this).attr('href') == '#') {
                $(this).attr('href', 'javascript:void(0)')
            }
        });














        // Gallery Calling Start --------------------------------------------------->

        $('.sliderHolder ul li a').click(function() {
            currentImg = $(this).parent().index();
            $('.galleryHolder').fadeIn('fast', function() {
                // Load the classic theme
                Galleria.loadTheme('themes/classic/galleria.classic.min.js');
                // Initialize Galleria
                Galleria.configure({
                    width: ($('.gallery1').width()) - 320,
                    height: ($('.gallery1').height()) - 40,
                    transition: "pulse",
                    thumbCrop: true,
                    imageCrop: true,
                    carousel: true,
                    imagePan: true,
                    clicknext: true
                });

                $('.galleryHolder a.galClose').click(function() {
                    $('.galleryHolder').fadeOut('slow');
                });
                //var gal = $("#gallery1").galleria();
                Galleria.run('#galleria', {
                    showInfo: false,
                    extend: function(options) {
                        this.bind('image', function(e) {
                            $('.imgDisc').hide().html(e.galleriaData.description).fadeIn();
                        });
                    }
                });


            });
        });
        // Gallery Calling End -------------------------------------------------------------------->




    }

    if (carDetails['IsActive']['#text'] == 'false') {
        $('.sellerInfo1, .sellerInfo2').hide();
        $('.soldCar').show();
    } else {
        $('.sellerInfo1, .sellerInfo2').show();
        $('.soldCar').hide();
    }    



}




function carFretures(result) {
    /*
    $('.Comfort').empty();
    var p = ''
    var Comfort = [];
    var Seats = [];
    var Safety = [];
    var Sound = [];
    var Windows = [];
    var Other = [];
    for(i=0; i< result.length;i++){
    var str = result[i];
    if(str.substring(0,7)=='Comfort'){
    Comfort.push(str);
    }else if(str.substring(0,5)=='Seats'){
    Seats.push(str);
    }else if(str.substring(0,6)=='Safety'){
    Safety.push(str);
    }else if(str.substring(0,5)=='Sound'){
    Sound.push(str);
    }else if(str.substring(0,7)=='Windows'){
    Windows.push(str);
    }else if(str.substring(0,5)=='Other'){
    Other.push(str);
    }           
    }
        
    p += "<h2 style='padding:0; margin:0 0 4px 0; font-size:18px; line-height:22px'>Car Specifications</h2>"
        
    p += '<strong>Comfort: </strong>';
    for(i=0; i<Comfort.length; i++){
    p += Comfort[i].substring(8);
    if(i!=Comfort.length-1){
    p += ', ';
    }
    }
        
    p += '<br><strong>Seats: </strong>';
    for(i=0; i<Seats.length; i++){
    p += Seats[i].substring(6)
    if(i!=Seats.length-1){
    p += ', ';
    }
    }
        
    p += '<br><strong>Safety: </strong>';
    for(i=0; i<Safety.length; i++){
    p += Safety[i].substring(7)
    if(i!=Safety.length-1){
    p += ', ';
    }
    }
        
    p += '<br><strong>Sound: </strong>';
    for(i=0; i<Sound.length; i++){
    p += Sound[i].substring(6)
    if(i!=Sound.length-1){
    p += ', ';
    }
    }
        
    p += '<br><strong>Windows: </strong>';
    for(i=0; i<Windows.length; i++){
    p += Windows[i].substring(8)
    if(i!=Other.length-1){
    p += ', ';
    }
    }
        
    p += '<br><strong>Other: </strong>';
    for(i=0; i<Other.length; i++){
    p += Other[i].substring(6)
    if(i!=Other.length-1){
    p += ', ';
    }
    }
        
    p+= '<br>';
        
    p+= '<br><strong>Surrounding towns:</strong>';
        
    p+= '<br><strong>Near by zip codes:</strong>'
        
    p+= '<br><strong>States:</strong>'
        
    p+= '<br><strong>Similar to the class of cars such as:</strong>'
        
       
        
        
    $('.Comfort').append(p);
    */



}



//  Get Vehicle Images along with Information GetCarPictures(carID)

function vehiclePicData(result) {
    //2011 Mercedes-Benz SLS AMG - <span>$229,900</span><a href="#" class="galClose">&nbsp;</a>
    var galdata;
    var carPicDetails = result;
    //console.log(carPicDetails)
    var title = '';
    var pr = '';
    data = [];
    if (carPicDetails['Price']['#text'] && carPicDetails['Price']['#text'] != undefined && carPicDetails['Price']['#text'] != null && carPicDetails['Price']['#text'] != 'Emp') {
        pr = " - $ " + carDetails['Price']['#text']
    }
    title += carPicDetails['YearOfMake']['#text'] + " " + carPicDetails['TypeName']['#text'] + " " + carPicDetails['Category_Name']['#text'] + " " + carPicDetails['Make']['#text'] + "  " + carPicDetails['Model']['#text'] + " <span>" + pr + "</span><a href='#' class='galClose'>&nbsp;</a>";

    $('.galleryHolder .gallery1 h2').empty().append(title);
    //console.log($('.galleryHolder .gallery1 h2').text())     
    var imgGallery = ''
    var imgCount = 0;

    //$('.slide1a').attr('src', path);
    //console.log(path)
    for (i = 1; i < 10; i++) {
        if (carPicDetails['PIC' + i]['#text'] != 'Emp' && carPicDetails['PICLOC' + i]['#text'] != 'Emp') {
            var path = "" + carPicDetails['PICLOC' + i]['#text'] + "/" + carPicDetails['PIC' + i]['#text'] + "";
            for (k = 0; k < 5; k++) {
                path = path.replace("\\", "/");
            }
            path = path.replace("//", "/");
            path = "http://www.unitedtruckexchange.com/" + path;

            var desc = '';
            if (carPicDetails['PICDesc' + i]['#text'] && carPicDetails['PICDesc' + i]['#text'] != undefined && carPicDetails['PICDesc' + i]['#text'] != null && carPicDetails['PICDesc' + i]['#text'] != 'Emp') {
                desc = carPicDetails['PICDesc' + i]['#text']
            }

            imgGallery += "<img src='" + path + "' data-description='" + desc + "'>";

            data.push({ 'image': path, 'data-description': desc });
            //alert(path);
        } else {
            imgCount++;
        }
    }

    if (imgCount > 9) {
        var path2 = "'http://www.unitedtruckexchange.com/images/stockMakes/" + carPicDetails['Make']['#text'] + ".jpg'";
        var carMake = carPicDetails['Make']['#text'];
        var carModel = carPicDetails['Model']['#text'];

        carMake = carMake.replace(' ', '-');
        carModel = carModel.replace(' ', '-');
        if (carModel.indexOf('/') > 0) {
            carModel = 'Other';
        }
        var MakeModel = carMake + "_" + carModel;
        //alert(MakeModel);
        MakeModel = MakeModel.replace(' ', '-');
        path2 = "http://www.unitedtruckexchange.com/images/MakeModelThumbs/" + MakeModel + ".jpg";
        var path1 = "'http://www.unitedtruckexchange.com/images/no-image.jpg'";
        var desc = '';
        if (carPicDetails['PICDesc0']['#text'] && carPicDetails['PICDesc0']['#text'] != undefined && carPicDetails['PICDesc0']['#text'] != null && carPicDetails['PICDesc0']['#text'] != 'Emp') {
            desc = carPicDetails['PICDesc0']['#text']
        }

        imgGallery += "<img src='" + path2 + "' data-description='" + desc + "'>";
        data.push({ 'image': path2, 'data-description': desc });
        //$('.galleryHolder .gallery1 #images').empty().append(imgGallery);
    } else {
        //$('.galleryHolder .gallery1 #images').empty().append(imgGallery);
    }

    var year = '';
    if (carPicDetails['YearOfMake']['#text'] && carPicDetails['YearOfMake']['#text'] != undefined && carPicDetails['YearOfMake']['#text'] != null && carPicDetails['YearOfMake']['#text'] != 'Emp') {
        year = carPicDetails['YearOfMake']['#text']
    }

    var type = '';
    if (carPicDetails['TypeName']['#text'] && carPicDetails['TypeName']['#text'] != undefined && carPicDetails['TypeName']['#text'] != null && carPicDetails['TypeName']['#text'] != 'Emp') {
        type = carPicDetails['TypeName']['#text']
    }

    var category = '';
    if (carPicDetails['Category_Name']['#text'] && carPicDetails['Category_Name']['#text'] != undefined && carPicDetails['Category_Name']['#text'] != null && carPicDetails['Category_Name']['#text'] != 'Emp') {
        category = carPicDetails['Category_Name']['#text']
    }

    var make = '';
    if (carPicDetails['Make']['#text'] && carPicDetails['Make']['#text'] != undefined && carPicDetails['Make']['#text'] != null && carPicDetails['Make']['#text'] != 'Emp') {
        make = carPicDetails['Make']['#text']
    }

    var model = '';
    if (carPicDetails['Model']['#text'] && carPicDetails['Model']['#text'] != undefined && carPicDetails['Model']['#text'] != null && carPicDetails['Model']['#text'] != 'Emp') {
        model = carPicDetails['Model']['#text']
    }

    var location = '';
    if (carPicDetails['Address1']['#text'] && carPicDetails['Address1']['#text'] != undefined && carPicDetails['Address1']['#text'] != null && carPicDetails['Address1']['#text'] != 'Emp') {
        location = carPicDetails['Address1']['#text']
    }

    var condition = '';
    /*
    if (carPicDetails['ConditionDescription']['#text'] && carPicDetails['ConditionDescription']['#text'] != undefined && carPicDetails['ConditionDescription']['#text'] != null && carPicDetails['ConditionDescription']['#text'] != 'Emp') {
    condition = carPicDetails['ConditionDescription']['#text']
    }
    */


    $('.year').empty().append(year);
    $('.type').empty().append(type);
    $('.category').empty().append(category);
    $('.make').empty().append(make);
    $('.model').empty().append(model);
    $('.location').empty().append(location);
    $('.condition').empty().append(condition);



    $('a').each(function() {
        if ($(this).attr('href') == '#') {
            $(this).attr('href', 'javascript:void(0)')
        }
    });


    // Gallery Calling Start --------------------------------------------------->



    $('.galleryHolder').fadeIn('fast', function() {
        // Load the classic theme
        Galleria.loadTheme('themes/classic/galleria.classic.min.js', {});
        // Initialize Galleria
        Galleria.configure({
            width: ($('.gallery1').width()) - 320,
            height: ($('.gallery1').height()) - 40,
            transition: "pulse",
            thumbCrop: true,
            imageCrop: true,
            carousel: true,
            imagePan: false,
            clicknext: true
        });


        $('.galleryHolder a.galClose').click(function() {
            $('.galleryHolder').fadeOut('slow');
        });

        Galleria.ready(function() {
            if (data.length >= 1) {
                this.load(data);
            }
        });


        if (galShow == 0) {
            galShow = 0;
            Galleria.run('#MyGalleria', {
                showInfo: false,
                keepSource: false,
                dataSource: data,
                debug: false,
                extend: function(options) {
                    this.bind('image', function(e) {
                        $('.imgDisc').html(e.galleriaData.description);
                    });
                }
            });
        }

    });


    // Gallery Calling End -------------------------------------------------------------------->




}