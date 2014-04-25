/*!
* Auther      : Jyothirmayudu.CH
* Mail        : ch.jmayudu@gmail.com
* Created on  : Feb 18 2014
* Discription : JS for for Search Results Generation
*/


var AddName = true;


// Banner Slider Start
function CarBannerAdsDisplay(CarBannerAds) {

    //console.log(CarBannerAds.length);

    if (CarBannerAds.length > 0) {
        var img = '';
        var withinZIp1 = 5;
        var zip1 = 0;

        var imgBanner = '';
        var slideData = '';



        for (i = 0; i < CarBannerAds.length; i++) {

          

            //var resPath = "'" + CarBannerAds[i]['YearOfMake']['#text'] + "','" + CarBannerAds[i]['CarUniqueID']['#text'] + "','" + CarBannerAds[i]['Make']['#text'] + "','" + CarBannerAds[i]['Model']['#text'] + "','" + zip1 + "','" + withinZIp1 + "','" + AddName + "'";

            var resPath2 = 'usedcars/' + $.trim(CarBannerAds[i]['YearOfMake']['#text']) + '-' + $.trim(CarBannerAds[i]['Make']['#text']) + '-' + $.trim(CarBannerAds[i]['Model']['#text']) + '-' + $.trim(CarBannerAds[i]['City']['#text']) + '-' + $.trim(CarBannerAds[i]['State']['#text']) + '-' + $.trim(CarBannerAds[i]['CarUniqueID']['#text']);

            

            var path = slidesArray2[i].img;

           




            imgBanner += '<div class="slide"><a href="detail.html">' +
                '<img src="' + path + '" alt="#" style=" width:652px;; height:409px; " ></a>' +
                '<div class="color-overlay"></div></div>';

            slideData += '<div class="overview">' +
                    '<div class="overview-table">' +
                    '<div class="item title">' +
                        '<a href="'+resPath2+'"><h3>' + CarBannerAds[i]['Make']['#text'] + '</h3></a>' +
                        '<div class="subtitle">' + CarBannerAds[i]['Model']['#text'] + '</div></div>' +

                    '<div class="item line">' +
                        '<span class="property">Year</span> <span class="value">' + CarBannerAds[i]['YearOfMake']['#text'] + '</span></div>' +

                    '<div class="item line">' +
                    '<span class="property">Price</span> <span class="value price10" >' + CarBannerAds[i]['Price']['#text'] + '</span></div>' +

                    '<div class="item line">' +
                        '<span class="property">Condition</span> <span class="value">' + CarBannerAds[i]['ConditionDescription']['#text'] + '</span></div>' +

                    '<div class="item line">' +
                        '<span class="property">Miles</span> <span class="value mileBan">' + CarBannerAds[i]['Mileage']['#text'] + '</span></div>' +

                    '<div class="item line">' +
                        '<span class="property">Fuel Type</span> <span class="value">' + CarBannerAds[i]['Fueltype']['#text'] + '</span></div>' +

                    '<div class="item line">' +
                        '<span class="property">DriveTrain</span> <span class="value">' + CarBannerAds[i]['DriveTrain']['#text'] + '</span></div>' +

                    '<div class="item line">' +
                        '<span class="property">Transmission</span> <span class="value">' + CarBannerAds[i]['Transmission']['#text'] + '</span></div>' +

                   '<div class="item line" style=" border:none; background:none; " >' +
                      '<span class="property"></span> <span class="value" style=" padding-top:10px; " ><a href="' + resPath2 + '" style="background:#F95446; padding:8px 12px;  color:#fff; text-decoration:none; " >View Details</a></span></div>' +

                '</div></div>';


        }
        //$('#loopedSlider .container .slides').empty();
        //$('#loopedSlider .container .slides').append(img);



        $('.slidesData').append(slideData);
        $('.slidesData .overview:eq(0)').addClass('active');

        var arrows = '<div id="slider-navigation"><div class="prev"></div><div class="next"></div></div>';
        $('.slidesData').append(arrows);

        $('.slidesImg').append(imgBanner);
        $('.slidesImg .slide:eq(0)').addClass('active');

        $('.price10').formatCurrency();
        $('.mileBan').formatCurrency({ symbol: ' ' });

        $('.mileBan').each(function() {
            $(this).append(' mi');
        })




        _initSlider('#slider');


        //console.log(slideData)



    } else {
        DummyBanner();
    }


}
// Banner Slider End


// Ads Display  Start  
function CarsAdDisplay(CarsAdDetails) {
    var path;


    //console.log(CarsAdDetails);

    // Vertical Car Ads
    if (CarsAdDetails.length > 0 && LoadingPage != 2) {
        var img = '';
        var withinZIp1 = 5;
        var zip1 = 0;
        //console.log(CarsAdDetails);
        $('#grid-carousel').empty();


        for (i = 5; i < CarsAdDetails.length; i++) {
            img = '';
            //var resPath = "'" + CarsAdDetails[i]['YearOfMake']['#text'] + "','" + CarsAdDetails[i]['CarUniqueID']['#text'] + "','" + CarsAdDetails[i]['Make']['#text'] + "','" + CarsAdDetails[i]['Model']['#text'] + "','" + zip1 + "','" + withinZIp1 + "','" + AddName + "'";

            //console.log(CarsAdDetails[i]);
            // usedcars / 2012 - Chevrolet - Impala - Seymour - IN - 190073968138

            var resPath2 = 'usedcars/' + $.trim(CarsAdDetails[i]['YearOfMake']['#text']) + '-' + $.trim(CarsAdDetails[i]['Make']['#text']) + '-' + $.trim(CarsAdDetails[i]['Model']['#text']) + '-' + $.trim(CarsAdDetails[i]['City']['#text']) + '-' + $.trim(CarsAdDetails[i]['State']['#text']) + '-' + $.trim(CarsAdDetails[i]['CarUniqueID']['#text']);
           
            var thumb1 = '';
            if (CarsAdDetails[i]['PIC1']['#text'] != 'Emp') {
                path = CarsAdDetails[i]['PICLOC1']['#text'] + "/" + CarsAdDetails[i]['PIC1']['#text'];
                for (k = 0; k < 5; k++) {
                    path = path.replace("\\", "/");
                }
                path = path.replace("//", "/");
                thumb1 = "<img src='http://unitedcarexchange.com/" + path + "' class='thumbV' onclick='javascript:EncryptedCarID(" + resPath + ");' style='width:100%; height:auto' />";
            } else {
                var carMake = CarsAdDetails[i]['Make']['#text'];
                var carModel = CarsAdDetails[i]['Model']['#text'];
                carMake = carMake.replace(' ', '-');
                carModel = carModel.replace(' ', '-');
                carModel = carModel.replace('/', '@');
                /*
                if(carModel.indexOf('/')>0){
                carModel='Other';			            
                }
                */
                var MakeModel = carMake + "_" + carModel;
                MakeModel = MakeModel.replace(' ', '-');
                MakeModel = MakeModel.replace('/', '@');
                path = "http://unitedcarexchange.com/images/MakeModelThumbs/" + MakeModel + ".jpg";


      // --------          thumb1 = "<img src='" + path + "' class='thumbV' onclick='javascript:EncryptedCarID(" + resPath + ");' style='width:100%; height:auto' /><div class='stockPhoto2' >Stock Photo</div>";
                thumb1 = "<img src='" + path + "' class='thumbV' style='width:100%; height:auto' /><div class='stockPhoto2' >Stock Photo</div>";

            }
            //img +=  "<li> "+thumb1+"<strong><a href='javascript:EncryptedCarID("+resPath+");'>"+CarsAdDetails[i]['YearOfMake']['#text']+" "+CarsAdDetails[i]['Make']['#text']+" "+CarsAdDetails[i]['Model']['#text']+"</a></strong> <b class='price11'>"+CarsAdDetails[i]['Price']['#text']+"</b> </li>";
            var price1 = CarsAdDetails[i]['Price']['#text'];
            if (price1 != 'Emp' && price1 != '0' && price1 != 0 && price1 != null) {
                // img +=  thumb1 + "<strong><a href='javascript:EncryptedCarID(" + resPath + ");' >" + CarsAdDetails[i]['YearOfMake']['#text'] + " " + CarsAdDetails[i]['Make']['#text'] + " " + CarsAdDetails[i]['Model']['#text'] + "</a></strong> <b class='price11'>" + CarsAdDetails[i]['Price']['#text'] + "</b> </li>"
            } else {
                // img +=  thumb1 + "<strong><a href='javascript:EncryptedCarID(" + resPath + ");' >" + CarsAdDetails[i]['YearOfMake']['#text'] + " " + CarsAdDetails[i]['Make']['#text'] + " " + CarsAdDetails[i]['Model']['#text'] + "</a></strong></li>"
            }


            //-------------------------


            img += '<div class="inner">';
            img += '<div class="grid-item">';
            img += '<div class="inner">';
            img += '<div class="picture">';
            img += '<div class="image-slider">';
            img += '<a href="' + resPath2 + '" class="slide">' + thumb1 + '</a></div></div>';

            img += '<div class="like">';
            img += '<a href="' + resPath2 + '"><i class="icon icon-outline-thumb-up"></i></a>';
            img += '</div>';

            img += '<h3><a href="' + resPath2 + '">' + CarsAdDetails[i]["Make"]["#text"] + '  ' + CarsAdDetails[i]["Model"]["#text"] + '</a></h3>';
            img += '<div class="subtitle">' + CarsAdDetails[i]["YearOfMake"]["#text"] + '</div>';




            var price1 = CarsAdDetails[i]['Price']['#text'];
            if (price1 != 'Emp' && price1 != '0' && price1 != 0 && price1 != null && price1 != 'unspecified') {
                img += '<div class="price price11">' + price1 + '</div>';
            } else {
            img += '<div><a href="' + resPath2 + '">Contact Seller</a></div>';
            }

         
            img += '</div></div></div>';

            //-------------------------

            $('#grid-carousel').append(img);
        }

       


        _initGridCarousel('.grid-carousel');





    };

    // Horizantal Car Ads
    if (CarsAdDetails.length > 0) {
        var img = '';
        var img2 = '';
        var withinZIp1 = 5;
        var zip1 = '0'
        var imgWidth = ''
        var liStyle = ''
        var style1 = '';
        var style2 = ''
        if (LoadingPage == 1) {
            imgWidth = "width='141'"
            liStyle = "<li>";
            text = '';
            text2 = ''
        } else {
            imgWidth = "width='140' height='85'";
            liStyle = "<li style='font-size: 12px;'>";
            style1 = "style='padding-top: 0px; padding-right: 5px; padding-bottom:4px; padding-left: 5px; font-size: 12px;'";
            style2 = "style='padding-top: 0px; padding-right: 5px; padding-bottom:0px; padding-left: 5px; font-size: 12px;'"
        }
        for (i = 0; i < CarsAdDetails.length - 8; i++) {
            //var resPath = '"' + CarsAdDetails[i]['Carid']['#text'] + '","' + CarsAdDetails[i]['Make']['#text'] + '","' + CarsAdDetails[i]['Model']['#text'] + '","' + zip1 + '","' + withinZIp1 + '"';
            var resPath = "'" + CarsAdDetails[i]['YearOfMake']['#text'] + "','" + CarsAdDetails[i]['CarUniqueID']['#text'] + "','" + CarsAdDetails[i]['Make']['#text'] + "','" + CarsAdDetails[i]['Model']['#text'] + "','" + zip1 + "','" + withinZIp1 + "','" + AddName + "'";

            var resPath2 = 'usedcars/' + $.trim(CarsAdDetails[i]['YearOfMake']['#text']) + '-' + $.trim(CarsAdDetails[i]['Make']['#text']) + '-' + $.trim(CarsAdDetails[i]['Model']['#text']) + '-' + $.trim(CarsAdDetails[i]['City']['#text']) + '-' + $.trim(CarsAdDetails[i]['State']['#text']) + '-' + $.trim(CarsAdDetails[i]['CarUniqueID']['#text']);

           // console.log(resPath2)
            
            var thumb1 = '';
            if (CarsAdDetails[i]['PIC1']['#text'] != 'Emp') {
                path = CarsAdDetails[i]['PICLOC1']['#text'] + "/" + CarsAdDetails[i]['PIC1']['#text'];
                for (k = 0; k < 5; k++) {
                    path = path.replace("\\", "/");
                }
                path = path.replace("//", "/");
                thumb1 = "<img src='http://unitedcarexchange.com/" + path + "' class='thumbH'  style=' width:100%; height:auto;'  />";
            } else {
                var carMake = CarsAdDetails[i]['Make']['#text'];
                var carModel = CarsAdDetails[i]['Model']['#text'];
                carMake = carMake.replace(' ', '-');
                carModel = carModel.replace(' ', '-');
                carModel = carModel.replace('/', '@');
                /*
                if(carModel.indexOf('/')>0){
                carModel='Other';
                }
                */
                var MakeModel = carMake + "_" + carModel;
                MakeModel = MakeModel.replace(' ', '-');
                MakeModel = MakeModel.replace('/', '@');
                path = "http://unitedcarexchange.com/images/MakeModelThumbs/" + MakeModel + ".jpg";

                thumb1 = "<img src='" + path + "'  class='thumbH'  style=' width:100%; height:auto;' /><div class='stockPhoto3' >Stock Photo</div>";

            }
            var price1 = CarsAdDetails[i]['Price']['#text'];

            //-----------------------------------------------

            img2 += '<div class="row-item"><div class="inner"><div class="row"><div class="col-lg-4 col-md-5 col-sm-5">';
            img2 += '<div class="picture"><div class="image-slider">'

            img2 += '<a href="' + resPath2 + '" class="slide" >' + thumb1 + '</a>';
            img2 += '</div></div></div>';

            img2 += '<div class="col-lg-8 col-md-7 col-sm-7"><div class="content-inner">'
            img2 += '<h3><a href="' + resPath2 + '">' + CarsAdDetails[i]["YearOfMake"]["#text"] + '  ' + CarsAdDetails[i]["Make"]["#text"] + '  ' + CarsAdDetails[i]["Model"]["#text"] + '</a></h3>';






            var price1 = CarsAdDetails[i]['Price']['#text'];
            if (price1 != 'Emp' && price1 != '0' && price1 != 0 && price1 != null && price1 != 'unspecified') {
                img2 += '<div class="price price11">' + price1 + '</div>';
            } else {
                img2 += '<div><a href="' + resPath2 + '">Contact Seller</a></div>';

            }




            img2 += '<div class="description"><p>' + CarsAdDetails[i]["Description"]["#text"] + '</p></div>';

            img2 += '<div class="meta">';
            img2 += '<ul class="clearfix ">';


            if (CarsAdDetails[i]["Mileage"]["#text"] != '0' && CarsAdDetails[i]["Mileage"]["#text"] != 'Emp' && CarsAdDetails[i]["Mileage"]["#text"] != 'Unspecified') {
                img2 += '<li><i class="icon icon-normal-dashboard "></i><span class="mileageHome">' + parseInt(CarsAdDetails[i]["Mileage"]["#text"]) + '</span> mi </li>';
            }

            if (CarsAdDetails[i]["NumberOfDoors"]["#text"] != '0' && CarsAdDetails[i]["NumberOfDoors"]["#text"] != 'Emp' && CarsAdDetails[i]["NumberOfDoors"]["#text"] != 'Unspecified') {
                img2 += '<li><i class="icon icon-normal-car-door"></i>' + CarsAdDetails[i]["NumberOfDoors"]["#text"] + ' </li>';
            }
            if (CarsAdDetails[i]["DriveTrain"]["#text"] != '0' && CarsAdDetails[i]["DriveTrain"]["#text"] != 'Emp' && CarsAdDetails[i]["DriveTrain"]["#text"] != 'Unspecified') {
                img2 += '<li><i class="icon icon-normal-cog-wheel"></i>' + CarsAdDetails[i]["DriveTrain"]["#text"] + ' </li>';
            }

            img2 += '</ul></div>';

            img2 += '</div></div></div></div></div>';


            //-----------------------------------------------

        }

        $('.popular').empty();
        $('.popular').append(img2);
    };

    $('.price11, .price12').formatCurrency();
    $('.mileageHome').formatCurrency({ symbol: ' ' });
}
// Ads Display End



// latestPostedCars Ticker Start
function latestPostedCars(latestPosts) {

    try {

        //console.log(latestPosts);        

        if (latestPosts != null && latestPosts != undefined && latestPosts.length > 0) {
            var vTic = '';
            var withinZIp1 = 5;
            var zip1 = '0'
            for (i = 0; i < latestPosts.length; i++) {
                //var resPath = "'" + latestPosts[i]['YearOfMake']['#text'] + "','" + latestPosts[i]['CarUniqueID']['#text'] + "','" + latestPosts[i]['Make']['#text'] + "','" + latestPosts[i]['Model']['#text'] + "','" + zip1 + "','" + withinZIp1 + "','" + true + "'";


                var resPath2 = 'usedcars/' + $.trim(latestPosts[i]['YearOfMake']['#text']) + '-' + $.trim(latestPosts[i]['Make']['#text']) + '-' + $.trim(latestPosts[i]['Model']['#text']) + '-' + $.trim(latestPosts[i]['City']['#text']) + '-' + $.trim(latestPosts[i]['State']['#text']) + '-' + $.trim(latestPosts[i]['CarUniqueID']['#text']);
                
                var thumb1 = '';
                if (latestPosts[i]['PIC0']['#text'] != 'Emp' && latestPosts[i]['PICLOC0']['#text'] != 'Emp') {
                    path = latestPosts[i]['PICLOC0']['#text'] + "/" + latestPosts[i]['PIC0']['#text'];
                    for (k = 0; k < 5; k++) {
                        path = path.replace("\\", "/");
                    }
                    path = path.replace("//", "/");
                    thumb1 = "<img src='http://unitedcarexchange.com/" + path + "' class='thumbH'  style='width:100%; height:auto'  />";
                } else {
                    var carMake = latestPosts[i]['Make']['#text'];
                    var carModel = latestPosts[i]['Model']['#text'];
                    carMake = carMake.replace(' ', '-');
                    carModel = carModel.replace(' ', '-');
                    carModel = carModel.replace('/', '@');
                    /*
                    if(carModel.indexOf('/')>0){
                    carModel='Other';
                    }
                    */
                    var MakeModel = carMake + "_" + carModel;
                    MakeModel = MakeModel.replace(' ', '-');
                    MakeModel = MakeModel.replace('/', '@');
                    path = "http://unitedcarexchange.com/images/MakeModelThumbs/" + MakeModel + ".jpg";

                    thumb1 = "<img src='" + path + "'  class='thumbH'  style='width:100%; height:auto' /><div class='stockPhoto3' >Stock Photo</div>";

                }







                //------------------------
                //console.log(resPath);
                vTic += '<li class="teaser-item-wrapper col-lg-12 col-md-12 col-sm-4">';
                vTic += '<div class="teaser-item">';



                vTic += '<div class="row"><div class="col-sm-4 col-md-4 picture-wrapper"><div class="picture">';
                vTic += '<a href="' + resPath2 + '">';
                vTic += '</i></span></span>'

                vTic += thumb1 + '</a></div></div>'

                vTic += '<div class="col-sm-8 col-md-8 content-wrapper ">'

                vTic += '<div class="title">';
                vTic += '<a href="' + resPath2 + '">' + latestPosts[i]['Make']['#text'] + ' ' + latestPosts[i]['Model']['#text'] + '</a>';
                vTic += '<div class="subtitle">' + latestPosts[i]['YearOfMake']['#text'] + '</div>';
                vTic += '</div>'








                var price1 = latestPosts[i]['Price']['#text'];
                if (price1 != 'Emp' && price1 != '0' && price1 != 0 && price1 != null && price1 != 'unspecified') {
                    vTic += '<div class="price price13">' + latestPosts[i]['Price']['#text'] + '</div></div>';
                } else {
                vTic += '<div><a href="' + resPath2 + '">Contact Seller</a></div></div>';
                }



                vTic += '</div></div> </li>'

                //---------------------------





            }
            /*
            $('.ticker1 ul').empty();
            $('.ticker1 ul').append(vTic);
            */

            $('.ticker1 ul').css('width', '100%').empty().append(vTic);
            $('.price13').formatCurrency();


            $('.ticker1').vTicker({
                speed: 500,
                pause: 3000,
                animation: 'fade',
                mousePause: true,
                showItems: 6
            });


        }
    }
    catch (ex) {
        //alert(ex);

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


    /*
    $('img').each(function() {
    var src = $(this).attr('src');
    $(this).live('load', function() {
    $(this).css('background', 'url(images/loading.gif) center cemter no-repeat');
    })
    })
    
    */





    // Images Preload
    //$(".image-loading ").preloader({ imagedelay:300 });


    $('#yourZip, #form-1-submit, #within').attr('disabled', true);
    /*
    $('input[type=text], textarea').bind("cut copy paste", function(e) {
    e.preventDefault();
    });
    */

    $('#resultsPerPage').change(function() {
        page = 1;
        $('.leftArrow div').removeClass('leftAct');
        $('.leftArrow div').addClass('leftDis');
        filterChecked();
    });





    //--------------Starts 25-07-2013--------------------//




    // Show Load More Results Button








    if (LoadingPage == 2) {

        $('.moreResults').live('click', function() {
            $(this).hide();
            $('.resultsLoading, #disableFilter').show();
            showMoreResults();
            //GetPageDataSpeed(PageResultsCount, page);
        })

        /*
        $(window).scroll(function () {
        if(endNum < totalTesults){
        if ($(window).scrollTop() == $(document).height() - $(window).height()) {
                
                 
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
        //showSpinner();
        $('.resultsLoading').fadeIn('fast');
        PageResultsCount = parseInt($('#resultsPerPage option:selected').val());
        sFilterType = parseInt($('#filterSortBy option:selected').val());
        //GetPageData(PageResultsCount, page);
        GetPageDataSpeed(PageResultsCount, page);


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
        }
        }
        }); 
        
        */
    }

    //------------------End -------------------------------//








});



function showMoreResults() {

    if (endNum < totalTesults) {
        if (maxPages == 1) {
            $('.resultsLoading, #disableFilter, .moreResults').hide();
        } else if (page < maxPages) {
            //console.log('maxPages:' + maxPages + ' endNum:' + endNum + ' totalTesults:' + totalTesults + ' page:' + page)
            page++;
            PageResultsCount = parseInt($('#resultsPerPage option:selected').val());
            sFilterType = parseInt($('#filterSortBy option:selected').val());
            //console.log(PageResultsCount, page);
            GetPageDataSpeed(PageResultsCount, page);
        } else if (maxPages == 0) {
            $('.resultsLoading, #disableFilter, .moreResults').hide();
        } else {
            PageResultsCount = parseInt($('#resultsPerPage option:selected').val());

        }
    }
}



function NoOfResultsandPagecount(result) {
    maxPages = result[0];
    totalTesults = result[1];
    PageResultsCount = parseInt($('#resultsPerPage option:selected').val());
    // 1-25 of 116

    //console.log('maxPages:' + maxPages + ' endNum:' + endNum + ' totalTesults:' + totalTesults + ' page:'+page)

    var m = '';
    if (maxPages > 1) {
        //m += '<strong>' + startNum + '</strong>-<strong>' + endNum + '</strong> of <strong>' + totalTesults + '</strong>';
        m += '<strong>' + 1 + '</strong>-<strong>' + endNum + '</strong> of <strong class="format" >' + totalTesults + '</strong>';
        // m += '<strong>' + endNum + '</strong>';
    } else if (maxPages == 1) {
        //m += '<strong>' + totalTesults + '</strong>-<strong>' + totalTesults + '</strong> of <strong>' + totalTesults + '</strong>';
        m += '<strong>' + 1 + '</strong>-<strong>' + totalTesults + '</strong> of <strong class="format">' + totalTesults + '</strong>';
        $('.resultsLoading, #disableFilter, .moreResults').hide();
        //m += '<strong>' + totalTesults + '</strong>';
    } else if (maxPages == 0 && page == 1) {
        m += '<strong>0</strong>';
        $('.resultsLoading, #disableFilter, .moreResults').hide();
    }
    $('#totalResultsFound').empty();
    $('#totalResultsFound').append(m);

    if (endNum == totalTesults) {
        $('.moreResults').hide();
    }
    

    $('.format').formatCurrency({ symbol: ' ' });

        


    //arrowsAct();
}

function showSpinner() {
    $('#spinner').show();
}
function hideSpinner() {
    $('#spinner').hide();
}


// Make Dropdown
function BindMakes(result) {
    WithinZipBinding();
    make = result;
    if (make.length > 0) {
        var mm = '';
        mm += "<option value='0'>All makes</option>";
        for (i = 0; i < make.length; i++) {
            mm += "<option value=" + make[i]["MakeID"] + ">" + make[i]["Make"] + "</option>"
        }
        $('#make').empty();
        $('#make').append(mm);
    } else {
        $('#make').empty();
    }

    if (LoadingPage == 1) {
        var carBrands1 = [['1a'], ['1b'], ['1c'], ['1d'], ['1e'], ['1f'], ['1g'], ['1h'], ['1i'], ['1j'], ['1k'], ['1l'], ['1m'],
		            ['1n'], ['1o'], ['1p'], ['1q'], ['1r'], ['1s'], ['1t'], ['1u'], ['1v'], ['1w'], ['1x'], ['1y'], ['1z']
		            ];
        var alphabets = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'];
        for (b = 0; b < make.length; b++) {
            for (c = 0; c < alphabets.length; c++) {
                var al = make[b]["Make"].charAt(0);
                if (al == alphabets[c]) {
                    var mk = make[b]["MakeID"] + "_" + make[b]["Make"];
                    carBrands1[c].push(mk);
                }
            }
        }

        // Car Brands  Tabs A-to-Z Screen Binding  Start		
        if (carBrands1.length > 0) {

            var cBrands = '';
            for (i = 0; i < carBrands1.length; i++) {
                if (carBrands1[i].length > 1) {
                    cBrands = "<div id=" + carBrands1[i][0] + "><div class='carsList'><ul class='cars'></ul></div></div>";
                    var dumLi = '';
                    for (j = 1; j < carBrands1[i].length; j++) {
                        var split1 = carBrands1[i][j].split('_')
                        var p = '"' + split1[0] + '"';
                        var brand = split1[1];
                        var brand2 = '"' + split1[1] + '"';
                        dumLi += "<li><a href='javascript:modelSearch(" + p + "," + brand2 + ");'>" + brand + "</a></li>";
                    }
                    $("#carBrands").append(cBrands);
                    $("#carBrands #" + carBrands1[i][0] + " ul").append(dumLi);

                } else {
                    cBrands = "<div id=" + carBrands1[i][0] + "><div class='carsList'><ul class='cars'><li style='color:#FF6600;'>No Make Available</li></ul></div></div>";
                    $("#carBrands").append(cBrands);

                }

            }



            // Tabs Enabling
            var settings = { start: 1, change: false };
            $("#adv1 ul").idTabs(settings, true);

        }
        // Car Brands  Tabs A-to-Z  Screen Binding End 

    }


}

// Models Dropdown 
function ModelsBinding(result) {

    models = result;
    $('#make').removeAttr('disabled');
    //alert(models.length);
    var mm = "<option value='0'>All models</option>";
    $('#model').empty();
    $('#model').append(mm);

    $('#make').bind('change keypress', function() {
        if (models.length > 0) {
            $('#model').removeAttr('disabled');
            var id = $('#make option:selected').val();
            //alert(id);
            var mm = '';
            var count = 0;
            mm += "<option value='0'>All models</option>";
            for (i = 0; i < models.length; i++) {
                if (id == models[i]["MakeID"]['#text']) {
                    mm += "<option value=" + models[i]["MakeModelID"]['#text'] + ">" + models[i]["Model"]['#text'] + "</option>";
                    count++;
                }
            }
            $('#model').empty();
            if (count > 0) {
                $('#model').append(mm);
            } else {
                var mm = '';
                mm += "<option value='0'>All models</option>";
                $('#model').empty();
                $('#model').append(mm);
                $('#model').attr('disabled', true);

            }
        }
    });





    //GetSearchCriteria(); 

    if (LoadingPage != 3) {
        searchCri();
    } else {
        selSearchCri($('#Hmake').val(), $('#Hmodel').val());
    }


    /*
    $($('#Hzip')).change(function(){
    //selSearchCri($('#Hmake').val(), $('#Hmodel').val());
    alert($(this).val())
    })
    */


    $('#yourZip').removeAttr('disabled');
    $('#yourZip, #form-1-submit, #within').removeAttr('disabled');

    if (LoadingPage == 2) {
        var dummyPrice = Price2
        if (!dummyPrice) {
            dummyPrice = 10000;
        }

        if (matchedCarsDummy == 0) {
            CarsMatchedData($('#make option:selected').val(), $('#model option:selected').val(), WithinZipNew, dummyPrice);
            matchedCarsDummy = 1;
        }

    }





}



// Within Dropdow1n 
function WithinZipBinding() {   // function WithinZipBinding(withinZip){         
    // alert('withinZip');
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
        $('#within option[value=' + 5 + ']').attr('selected', 'selected');
    }

    // $('#lblMake');
    //  $('#lblModel');

    if (LoadingPage == 3) {
        $('#within option[text=' + 5 + ']').attr('selected', 'selected');

        make1 = $('#Hmake').val();
        // Hmake
        //Hmodel

    }
}

$('#within').bind('change keypress', function() {
    var id = $('#within option:selected').val();
    $('#within option').each(function() {
        $(this).removeAttr('selected');
    });
    $('#within option[value=' + id + ']').attr('selected', 'selected');
});


function minMx2() {
    var pp = $.trim($('#priceRange').val()).split(';');
    var mm = $.trim($('#mileRange').val()).split(';');

    minMx(pp[0], pp[1], mm[0], mm[1]);
}

// Search Button Submit
function search() {
    var SelectedMake = $('#make option:selected').val();
    var SelectedModel = $('#model option:selected').val();
    var SelectedDistance = '5'; //$('#within option:selected').val();
    var EnteredZip = $('#yourZip').val();


    var pp = $.trim($('#priceRange').val()).split(';');
    var mm = $.trim($('#mileRange').val()).split(';');


    $('#hdnPriceMIN').val(pp[0]);
    $('#hdnPriceMAX').val(pp[1]);
    $('#hdnMileageMIN').val(mm[0]);
    $('#hdnMileageMAX').val(mm[1]);






    if (SelectedMake == 'Select make') {
        alert('Select a make');
        $('#make').focus();
    } else if (SelectedModel == 'null') {
        alert('Select a model');
        $('#model').focus();
    } else if (EnteredZip == '' || EnteredZip == null) {
        alert('Enter your ZIP');
        $('#yourZip').focus();
    } else if (EnteredZip.length < 5 || (EnteredZip.length > 5 && EnteredZip.length < 10) || (EnteredZip.length > 5 && EnteredZip.length == 10 && EnteredZip.charAt(5) != '-')) {
        alert('Enter valid ZIP');
        $('#yourZip').focus();
    } else {

        //CarsSearch(carMakeid, CarModalId, ZipCode, WithinZip);

        showSpinner();
        ChekZip(EnteredZip);

        //alert('Make: '+SelectedMake+',  Model:'+SelectedModel+',  Within:'+SelectedDistance+',  ZIP:'+EnteredZip);
    }
};

// Search Button Submit
function search2() {
    //alert('Click');

    var SelectedMake = $('#make option:selected').val();
    var SelectedModel = $('#model option:selected').val();
    var SelectedDistance = $('#within option:selected').val();
    var EnteredZip = $('#yourZip').val();

    if (SelectedMake == 'Select make') {
        alert('Select a make');
    } else if (SelectedModel == 'null') {
        alert('Select a model');
    } else if (SelectedDistance == 'Select distance') {
        alert('Select distance');
    } else if (EnteredZip == '' || EnteredZip == null) {
        alert('Enter your ZIP');
    } else if (EnteredZip.length < 5 || (EnteredZip.length > 5 && EnteredZip.length < 10) || (EnteredZip.length > 5 && EnteredZip.length == 10 && EnteredZip.charAt(5) != '-')) {
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

        if (SearchResults != undefined) {
            resultsLength = SearchResults.length;
            //alert(resultsLength);
            dummyArraySet = SearchResults;
            //$('#totalResultsFound').text(SearchResults.length);
            //$('.searchResultsHolder').empty();


            ////console.log($('title'));

            if (SearchResults.length > 0) {
                var res = '';
                //withinZipRange = $('#within  option:selected').text();



                //$('.searchResultsHolder').empty();
                for (i = 0; i < SearchResults.length; i++) {
                    var m = '';
                    var path = ''
                    var withinZIp1 = $('#within option:selected').val();
                    var zip1 = $('#yourZip').val();
                    var resPath = "'" + SearchResults[i]['YearOfMake']['#text'] + '","' + SearchResults[i]['CarUniqueID']['#text'] + '","' + SearchResults[i]['Make']['#text'] + '","' + SearchResults[i]['Model']['#text'] + '","' + zip1 + '","' + withinZIp1 + '"';
                    var thumb1 = '';
                    //console.log(SearchResults[i]['PIC0']['#text']);
                    if (SearchResults[i]['PIC0']['#text'] != 'Emp') {
                        path = SearchResults[i]['PICLOC0']['#text'] + "/" + SearchResults[i]['PIC0']['#text'];
                        for (k = 0; k < 3; k++) {
                            path = path.replace("\\", "/");
                        }
                        path = path.replace("//", "/");
                        thumb1 = "<img src='" + path + "' class='thumb' onclick='javascript:EncryptedCarID(" + resPath + ");' width='80' height='50' />";
                    } else {
                        //path = "images/stockMakes/"+SearchResults[i]['Make']['#text']+".jpg";

                        var carMake = SearchResults[i]['Make']['#text'];
                        var carModel = SearchResults[i]['Model']['#text'];
                        carMake = carMake.replace(' ', '-');
                        carModel = carModel.replace(' ', '-');
                        carModel = carModel.replace('/', '@');
                        /*
                        if(carModel.indexOf('/')>0){
                        carModel='Other';
                        }
                        */
                        var MakeModel = carMake + "_" + carModel;
                        MakeModel = MakeModel.replace(' ', '-');
                        MakeModel = MakeModel.replace('/', '@');
                        path = "imagesOld/MakeModelThumbs/" + MakeModel + ".jpg";
                        //console.log(path);
                        thumb1 = "<img src='" + path + "' class='thumb' onclick='javascript:EncryptedCarID(" + resPath + ");' width='80' height='50' /><div class='stockPhoto1' >Stock Photo</div>";
                    }





                    m += "<div class='searchResultsBox' ><table style='width:100%'><tr><td style='width:90px; vertical-align:top' class='searchCarThumbHolder'>" + thumb1 + "</td>";
                    m += "<td class='searchcarDetails' style='vertical-align:top'><h4><a href='javascript:EncryptedCarID(" + resPath + ");' class='carName'>" + SearchResults[i]['YearOfMake']['#text'] + " " + SearchResults[i]['Make']['#text'] + " " + SearchResults[i]['Model']['#text'] + "</a></h4>";

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

                    m += "</p><a href='javascript:void(0);' class='viewA'>View seller details</a><p id='" + SearchResults[i]['CarUniqueID']['#text'] + "a' class='details'> <strong>" + SearchResults[i]['SellerType']['#text'] + ": </strong>"
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


                    m += "</span> )</span><br /><span class='userNumber'><strong>Phone: </strong>" + SearchResults[i]['Phone']['#text'] + "</span>";



                    //                   if (SearchResults[i]['Email']['#text'] != 'Emp' && SearchResults[i]['Email']['#text'] != 'Unspecified') {
                    //m += ", <strong>Email: </strong><a href='mailto:" + SearchResults[i]['Email']['#text'] + "'>" + SearchResults[i]['Email']['#text'] + //"</a>";
                    //                   }

                    m += "</p></td>";

                    m += "<td class='searchResultsBox3' style='vertical-align:top; width:185px;' ><table style='width:100%' class='subInfo searchCarCheckBox' cellspacing='0' cellpadding='0' ><tr class='subInfoHed'><td style='width:85px;'><strong>Mileage</strong></td><td><strong>Price</strong></td></tr><tr><td >";

                    if (SearchResults[i]['Mileage']['#text'] != 'Emp' && SearchResults[i]['Mileage']['#text'] != '0' && SearchResults[i]['Mileage']['#text'] != 'Unspecified') {
                        m += "<label class='mileage'>" + parseInt(SearchResults[i]['Mileage']['#text']) + "</label> mi</td>"
                    } else {
                        m += "<label >Unspecified</label> </td>"
                    }

                    if (SearchResults[i]['Price']['#text'] != 'Emp' && SearchResults[i]['Price']['#text'] != '0' && SearchResults[i]['Price']['#text'] != 'Unspecified') {
                        m += "<td class='price'>" + parseInt(SearchResults[i]['Price']['#text']) + "</td></tr>"
                    } else {
                        m += "<td> <label >Unspecified</label> </td></tr>"
                    }

                    if (SearchResults[i]['Price']['#text'] != 'Emp' && SearchResults[i]['Price']['#text'] != '0' && SearchResults[i]['Price']['#text'] != 'Unspecified') {
                        m += "<td class='price'>" + parseInt(SearchResults[i]['Price']['#text']) + "</td></tr>"
                    } else {
                        m += "<td> <label >Unspecified</label> </td></tr>"
                    }

                    m += "<tr class='subInfoHed'><td><strong>Body</strong></td><td><strong>Fuel</strong></td><td></td></tr><tr class='last'><td><label>"

                    if (SearchResults[i]['Bodytype']['#text'] != 'Emp' && SearchResults[i]['Bodytype']['#text'] != '0' && SearchResults[i]['Bodytype']['#text'] != 'Unspecified') {
                        m += SearchResults[i]['Bodytype']['#text'] + "</label></td>"
                    } else {
                        m += "Unspecified</label></td>"
                    }

                    if (SearchResults[i]['Fueltype']['#text'] != 'Emp' && SearchResults[i]['Fueltype']['#text'] != '0' && SearchResults[i]['Fueltype']['#text'] != 'Unspecified') {
                        m += "<td>" + SearchResults[i]['Fueltype']['#text'] + "</td><td align='center'></td></tr></table></td></tr></table></div>";
                    } else {
                        m += "<td>Unspecified</td><td align='center'></td></tr></table></td></tr></table></div>";
                    }

                    $('.searchResultsHolder').append(m);
                }

                $('.price').formatCurrency();
                $('.mileage').formatCurrency({ symbol: ' ' });




                $('a.viewA').click(function() {
                    //alert($(this).next("span").attr('id'))
                    $(this).hide();
                    $(this).next("p").show();

                });
            }

            //showSpinner();
            hideSpinner();

            //$(',loadMore').show();
            $('.resultsLoading, #disableFilter').hide();
            $('.moreResults').show();




            // alert('Ok')

        }
        else {
            $('#totalResultsFound').text('0');
            $('#PaginationBlock').hide();
            //$('.searchResultsHolder').empty();
            $('.searchResultsHolder').append("<h2 style='color:#FF9900; text-align:center; line-height:200px; padding-bottom:800px'>No records found..!</h2>");
            hideSpinner();
            $('.moreResults').hide();


        }

        //arrowsAct();
        $('.resultsLoading, #disableFilter').hide();
        //showMoreResults();
    }
    catch (ex)
        { }

}


//selSearchCri
function selSearchCri(make5, model5) {
    //console.log(make5, model5);
    //$('#make option[text='+make1+']').attr('selected', 'selected'); 
    /*
    $('#make option').each(function() {        
    if($(this).val() == make5){
    $(this).attr('selected', 'selected');
    //$('#make').val(make5);
    }else{
    $(this).removeAttr('selected');
    } 
    });  
    */
    $('#make option[value=' + make5 + ']').attr('selected', 'selected');


    $('#model').removeAttr('disabled');
    var id = $('#make option:selected').val();
    //console.log(models);
    var mm = '';
    var count = 0;
    mm += "<option value='0'>All models</option>";
    for (i = 0; i < models.length; i++) {
        if (make5 == models[i]["MakeID"]['#text']) {
            mm += "<option value=" + models[i]["MakeModelID"]['#text'] + ">" + models[i]["Model"]['#text'] + "</option>";
            count++;
        }
    }
    $('#model').empty();
    if (count > 0) {
        $('#model').append(mm);
    } else {
        var mm = '';
        mm += "<option value='0'>All models</option>";
        $('#model').empty();
        $('#model').append(mm);
        $('#model').attr('disabled', true);

    }
    $('#model option').each(function() {
        $(this).removeAttr('selected');
    });

    $('#model option').each(function() {
        if ($(this).val() == model5) {
            $(this).attr('selected', 'selected');
        }
    });


    $('#within option').each(function() {
        $(this).removeAttr('selected');
    });
    $('#within option[value=' + WithinZipNew + ']').attr('selected', 'selected');

    // alert($('#Hzip').val());
    //$('#yourZip').removeAttr('disabled').val($('#Hzip').val())

}


function searchCri() {
    if (page != 3) {

        //withinZipRange = SessionArray[3];
        $('#within option').each(function() {
            $(this).removeAttr('selected');
        });

        //$('#make option[text='+make1+']').attr('selected', 'selected'); 
        $('#make option').each(function() {
            $(this).removeAttr('selected');
        })

        $('#make option').each(function() {
            if ($(this).text() == make1) {
                $(this).attr('selected', 'selected');
            }
        });

        $('#model').removeAttr('disabled');
        var id = $('#make option:selected').val();
        var mm = '';
        var count = 0;
        mm += "<option value='0'>All models</option>";
        for (i = 0; i < models.length; i++) {
            if (id == models[i]["MakeID"]['#text']) {
                mm += "<option value=" + models[i]["MakeModelID"]['#text'] + ">" + models[i]["Model"]['#text'] + "</option>";
                count++;
            }
        }
        $('#model').empty();
        if (count > 0) {
            $('#model').append(mm);
        } else {
            var mm = '';
            mm += "<option value='0'>All models</option>";
            $('#model').empty();
            $('#model').append(mm);
            $('#model').attr('disabled', true);

        }
        $('#model option').each(function() {
            $(this).removeAttr('selected');
        });

        $('#model option').each(function() {
            if ($(this).text() == Modal1) {
                $(this).attr('selected', 'selected');
            }
        });


        $('#within option').each(function() {
            $(this).removeAttr('selected');
        });
        $('#within option[value=' + WithinZipNew + ']').attr('selected', 'selected');

        $('.mileage2').empty();
        var str = $('#within option[text=' + WithinZipNew + ']').text()
        var newStr = str.substring(0, str.length - 6);
        // alert(newStr)
        $('.mileage2').text(newStr);

        if (ZipCode1.length >= 4 && ZipCode1 !== '' && ZipCode1 != null && ZipCode1 != undefined && LoadingPage != 3) {
            $('#yourZip').val(ZipCode1);
        } else if (LoadingPage != 3) {
            // $('#yourZip').val('');
        }

    }




}

var matchedCarsDummy = 0;

// Search Results Display with FILTER  
function SearchResultsDisplayFilter(SearchResultsArray) {
    // Results

    //console.log(SearchResultsArray);

    withinZipRange = $('#within option:selected').text();
    //alert(withinZipRange);
    $('.resultsLoading, #disableFilter').fadeOut();
    $('#Filter').fadeIn();

    if ((SearchResultsArray != undefined && SearchResultsArray != null) || (SearchResultsArray['Make'] != null && SearchResultsArray['Make'] != '')) {
        resultsLength = SearchResultsArray.length;


        if (SearchResultsArray != null && SearchResultsArray != '' && SearchResultsArray.length > 0) {

            $('#PaginationBlock').show();
            var res = '';

            for (i = 0; i < SearchResultsArray.length; i++) {

                //$('.searchResultsHolder').append("<div class='searchResultsBox' ><table style='width:100%'><tr><td style='width:90px;' class='searchCarThumbHolder'><img src='images/SearchResultsCarsThumbs/thumb1.png' class='thumb' onclick='javascript:FindCarID("+SearchResultsArray[i]['Carid']['#text']+");' /><br /></td><td class='searchcarDetails'><h4><a href='javascript:FindCarID("+SearchResultsArray[i]['Carid']['#text']+");' class='carName'>"+SearchResultsArray[i]['YearOfMake']['#text']+" "+SearchResultsArray[i]['Make']['#text']+" "+SearchResultsArray[i]['Model']['#text']+"</a></h4><p><strong>Description: </strong>"+SearchResultsArray[i]['ExteriorColor']['#text']+", "+SearchResultsArray[i]['NumberOfDoors']['#text']+" with "+SearchResultsArray[i]['NumberOfSeats']['#text']+", "+SearchResultsArray[i]['NumberOfCylinder']['#text']+", "+SearchResultsArray[i]['Transmission']['#text']+"</p><a href='javascript:void(0);' class='viewA'>View seller details</a><p id='"+SearchResultsArray[i]['Carid']['#text']+"a' class='details'> <strong>"+SearchResultsArray[i]['SellerType']['#text']+": </strong>"+SearchResultsArray[i]['SellerName']['#text']+" <span class='det1'>("+SearchResultsArray[i]['City']['#text']+", "+SearchResultsArray[i]['State']['#text']+" - Within <span class='mileage'>"+withinZipRange+"</span> mi)</span><br /><span class='userNumber'><strong>Phone: </strong>"+SearchResultsArray[i]['Phone']['#text']+"</span>, <strong>Email: </strong><a href='mailto:"+SearchResultsArray[i]['Email']['#text']+"'>"+SearchResultsArray[i]['Email']['#text']+"</a> </p></td><td class='searchResultsBox3' ><table class='subInfo searchCarCheckBox' cellspacing='0' cellpadding='0' ><tr class='subInfoHed'><td><strong>Mileage</strong></td><td><strong>Price</strong></td></tr><tr><td><label class='mileage'>"+parseInt(SearchResultsArray[i]['Mileage']['#text'])+"</label> mi</td><td class='price'>"+ parseInt(SearchResultsArray[i]['Price']['#text'])+"</td></tr><tr class='subInfoHed'><td><strong>Body</strong></td><td><strong>Fuel</strong></td><td></td></tr><tr class='last'><td><label>"+SearchResultsArray[i]['Bodytype']['#text']+"</label></td><td>"+SearchResultsArray[i]['Fueltype']['#text']+"</td><td align='center'></td></tr></table></td></tr></table></div>");
                var m = '';
                var path = ''
                var withinZIp1 = $('#within option:selected').val();
                var zip1 = $('#yourZip').val();

               // var resPath = "'" + SearchResultsArray[i]['YearOfMake']['#text'] + "','" + SearchResultsArray[i]['CarUniqueID']['#text'] + "','" + SearchResultsArray[i]['Make']['#text'] + "','" + SearchResultsArray[i]['Model']['#text'] + "','" + zip1 + "','" + withinZIp1 + "'";


                var resPath2 = 'usedcars/' + $.trim(SearchResultsArray[i]['YearOfMake']['#text']) + '-' + $.trim(SearchResultsArray[i]['Make']['#text']) + '-' + $.trim(SearchResultsArray[i]['Model']['#text']).replace("&", "-") + '-' + $.trim(SearchResultsArray[i]['City']['#text']) + '-' + $.trim(SearchResultsArray[i]['State']['#text']) + '-' + $.trim(SearchResultsArray[i]['CarUniqueID']['#text']);
                
                
                var thumb1 = '';
                //console.log(SearchResultsArray[i]['PICLOC0']['#text'] + ',  ' + SearchResultsArray[i]['PIC0']['#text'])
                if (SearchResultsArray[i]['PICLOC0']['#text'] != "Emp" && SearchResultsArray[i]['PIC0']['#text'] != 'Emp') {
                    path = SearchResultsArray[i]['PICLOC0']['#text'] + "/" + SearchResultsArray[i]['PIC0']['#text'];
                    for (k = 0; k < 3; k++) {
                        path = path.replace("\\", "/");
                    }
                    path = path.replace("//", "/");
                    thumb1 = "<img src='http://unitedcarexchange.com/" + path + "' class='thumb'  style=' width:100%; height:auto;'   />";
                } else {
                    //path = "images/stockMakes/"+SearchResultsArray[i]['Make']['#text']+".jpg";
                    var carMake = SearchResultsArray[i]['Make']['#text'];
                    var carModel = SearchResultsArray[i]['Model']['#text'];
                    carMake = carMake.replace(' ', '-');
                    carModel = carModel.replace(' ', '-');
                    carModel = carModel.replace('/', '@');
                    /*
                    if(carModel.indexOf('/')>0){
                    carModel='Other';
                    }
                    */
                    var MakeModel = carMake + "_" + carModel;
                    MakeModel = MakeModel.replace(' ', '-');
                    MakeModel = MakeModel.replace('/', '@');
                    path = "http://unitedcarexchange.com/images/MakeModelThumbs/" + MakeModel + ".jpg";
                    //console.log(path)
                    thumb1 = "<img src='" + path + "' class='thumb'  style='  width:100%; height:auto; ' /><div class='stockPhoto1' >Stock Photo</div>";


                }





                //-----------------------------------------------

                m += '<div class="row-item"><div class="inner"><div class="row"><div class="col-lg-4 col-md-5 col-sm-5">';
                m += '<div class="picture"><div class="image-slider">'

                m += '<a href="' + resPath2 + '" class="slide" >' + thumb1 + '</a>';
                m += '</div></div></div>';

                m += '<div class="col-lg-8 col-md-7 col-sm-7"><div class="content-inner">'
                m += '<h3><a href="' + resPath2 + '">';
                if (SearchResultsArray[i]['Title']['#text'] != 'Emp' && SearchResultsArray[i]['Title']['#text'] != '' && SearchResultsArray[i]['Title']['#text'] != ' ' && SearchResultsArray[i]['Title']['#text'] != 'undefined' && SearchResultsArray[i]['Title']['#text'] != 'unspecified') {

                    var title = '';
                    if (SearchResultsArray[i]['Title']['#text'].length > 51) {
                        title = SearchResultsArray[i]['Title']['#text'].substring(0, 46) + "..."
                    } else {
                        title = SearchResultsArray[i]['Title']['#text'];
                    }
                    m += title;
                } else {
                    m += SearchResultsArray[i]['YearOfMake']['#text'] + " " + SearchResultsArray[i]['Make']['#text'] + " " + SearchResultsArray[i]['Model']['#text']
                }

                m += '</a>';


                var price1 = SearchResultsArray[i]['Price']['#text'];
                if (price1 != 'Emp' && price1 != '0' && price1 != 0 && price1 != null && price1 != 'unspecified') {
                    m += '<div class="price ">' + SearchResultsArray[i]['Price']['#text'] + '</div>';
                } else {
                m += '<div><a href="' + resPath2 + '" class="contactSellerLink">Contact Seller</a></div>';
                }



                m += '</h3>';


                if (SearchResultsArray[i]['Description']['#text'] != 'Emp' && SearchResultsArray[i]['Description']['#text'] != '' && SearchResultsArray[i]['Description']['#text'] != ' ' && SearchResultsArray[i]['Description']['#text'] != 'undefined' && SearchResultsArray[i]['Description']['#text'] != 'unspecified') {

                    var Description = '';
                    if (SearchResultsArray[i]['Description']['#text'].length > 150) {
                        Description = SearchResultsArray[i]['Description']['#text'].substring(0, 150) + "..."
                    } else {
                        Description = SearchResultsArray[i]['Description']['#text'];
                    }

                    m += '<div class="description"><p>' + Description + '</p></div>';
                }




                m += '<div class="meta">';
                m += '<ul class="clearfix ">';




                if (SearchResultsArray[i]["Mileage"]["#text"] && SearchResultsArray[i]["Mileage"]["#text"] != 'Emp' && SearchResultsArray[i]["Mileage"]["#text"] != 'Unspecified') {
                    m += '<li><i class="icon icon-normal-dashboard "></i><span class="mileageHome">' + parseInt(SearchResultsArray[i]["Mileage"]["#text"]) + '</span> mi </li>';
                }

                if (SearchResultsArray[i]["NumberOfDoors"]["#text"] && SearchResultsArray[i]["NumberOfDoors"]["#text"] != 'Emp' && SearchResultsArray[i]["NumberOfDoors"]["#text"] != '0' && SearchResultsArray[i]["NumberOfDoors"]["#text"] != 'Unspecified') {
                    m += '<li><i class="icon icon-normal-car-door"></i>' + SearchResultsArray[i]["NumberOfDoors"]["#text"] + ' </li>';
                }

                if (SearchResultsArray[i]["Transmission"]["#text"] && SearchResultsArray[i]["Transmission"]["#text"] != '0' && SearchResultsArray[i]["Transmission"]["#text"] != 'Emp' && SearchResultsArray[i]["Transmission"]["#text"] != 'Unspecified') {
                    m += '<li><i class="icon icon-normal-cog-wheel"></i>' + SearchResultsArray[i]["Transmission"]["#text"] + ' </li>';
                }



                m += '</ul></div>';

                m += '</div></div></div></div></div>';


                //-----------------------------------------------


                // console.log(m);

                $('.searchResultsHolder').append(m);
                if (SearchResultsArray[i]['IsActive']['#text'] == 'false') {
                    var sorry = "Sorry..! this car has been sold.";
                    $("p." + SearchResultsArray[i]['CarUniqueID']['#text'] + "a").empty().append(sorry);
                }
            }  // For loop close		



            /*if(SearchResultsArray[i]['IsActive']['#text'] == false){
            alert('False')
            }
            */

            // View seller details Click Event start
            $('a.viewA').click(function() {
                //alert($(this).next("span").attr('id'))
                $(this).hide();
                $(this).next("p").show();
            }); // View seller details Click Event Close
            $('.price').formatCurrency();
            //$('.mileage').formatCurrency({ symbol: ' ' });

            $('.moreResults').show();

        } else if (SearchResultsArray['Make'] != null && SearchResultsArray['Make'] != '') {
            resultsLength = 1;
            oneReord(SearchResultsArray);
            $('.moreResults').hide();
        } else {
            $('.moreResults').show();
            $('#totalResultsFound').text('0');
            $('#PaginationBlock').hide();
            $('.moreResults').hide(); 
            //$('.searchResultsHolder').empty();
            $('.searchResultsHolder').append("<h2 style='color:#FF9900; text-align:center; line-height:200px; padding-bottom:800px'>No records found..!</h2>");

        }
    } else {
        $('#totalResultsFound').text('0');
        $('#PaginationBlock').hide();
        $('.moreResults').hide();
        //$('.searchResultsHolder').empty();
        $('.searchResultsHolder').append("<h2 style='color:#FF9900; text-align:center; line-height:200px; padding-bottom:800px'>No records found..!</h2>");

    }

    hideSpinner();
    $('.resultsLoading, #disableFilter').hide();
    //showMoreResults();

    $('#filterSortBy').removeAttr('disabled');


    $('.mileageHome').formatCurrency({ symbol: ' ' });



    /* $('#botAd iframe, #botAd table, #botAd img, #botAd td').width('642')
    $('#botAd iframe, #botAd table, #botAd img').width('642'); 
    $('#botAd td').width('209');  
    $('#botAd img').height('90');
    */
}

function oneReord(SearchResultsArray) {


    ////console.log($('title'));

    var m = '';
    var path = ''
    var withinZIp1 = $('#within option:selected').val();
    var zip1 = $('#yourZip').val();
    var resPath = '"' + SearchResultsArray[i]['YearOfMake']['#text'] + '","' + SearchResultsArray['CarUniqueID']['#text'] + '","' + SearchResultsArray['Make']['#text'] + '","' + SearchResultsArray['Model']['#text'] + '","' + zip1 + '","' + withinZIp1 + '"';
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
        var carMake = SearchResultsArray['Make']['#text'];
        var carModel = SearchResultsArray['Model']['#text'];
        carMake = carMake.replace(' ', '-');
        carModel = carModel.replace(' ', '-');
        carModel = carModel.replace('/', '@');
        /*
        if(carModel.indexOf('/')>0){
        carModel='Other';
        }
        */
        var MakeModel = carMake + "_" + carModel;
        MakeModel = MakeModel.replace(' ', '-');
        MakeModel = MakeModel.replace('/', '@');
        path = "imagesOld/MakeModelThumbs/" + MakeModel + ".jpg";
        thumb1 = "<img src='" + path + "' class='thumb' onclick='javascript:EncryptedCarID(" + resPath + ");' width='80' height='50' /><div class='stockPhoto1' >Stock Photo</div>";
    }

    m += "<div class='searchResultsBox' ><table style='width:100%'><tr><td style='width:90px; vertical-align:top' class='searchCarThumbHolder'>" + thumb1 + "</td>";
    m += "<td class='searchcarDetails' style='vertical-align:top'><h4><a href='javascript:EncryptedCarID(" + resPath + ");' class='carName'>" + SearchResultsArray['YearOfMake']['#text'] + " " + SearchResultsArray['Make']['#text'] + " " + SearchResultsArray['Model']['#text'] + "</a></h4>";
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

    m += "</p><a href='javascript:void(0);' class='viewA'>View seller details</a><p id='" + SearchResultsArray['CarUniqueID']['#text'] + "a' class='details'><strong>Seller Type: </strong> " + SearchResultsArray['SellerType']['#text'] + "<br><strong>Seller Details: </strong>"
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
    var dum = SearchResultsArray['Phone']['#text'];
    var phone1 = ''
    if (dum != null && dum != undefined && dum != '') {
        phone1 += dum[0] + '' + dum[1] + '' + dum[2] + '-' + dum[3] + '' + dum[4] + '' + dum[5] + '-' + dum[6] + '' + dum[7] + '' + dum[8] + '' + dum[9];
    } else {
        phone1 = '';
    }

    m += phone1 + "</span>";

    //    if (SearchResultsArray['Email']['#text'] != 'Emp' && SearchResultsArray['Email']['#text'] != 'Unspecified') {
    //        m += ", <strong>Email: </strong><a href='mailto:" + SearchResultsArray['Email']['#text'] + "'>" + SearchResultsArray['Email']['#text'] + "</a>";
    //    }
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


    m += "<tr class='subInfoHed'><td><strong>Body</strong></td><td><strong>Fuel</strong></td><td></td></tr><tr class='last'><td><label>"

    if (SearchResultsArray['Bodytype']['#text'] != 'Emp' && SearchResultsArray['Bodytype']['#text'] != '0' && SearchResultsArray['Bodytype']['#text'] != 'Unspecified') {
        m += SearchResultsArray['Bodytype']['#text'] + "</label></td>"
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
    $('.mileage').formatCurrency({ symbol: ' ' });
}


function newSearch() {
    var id0 = $('#model option:selected').text();
    var id1 = $('#modelA option:selected').text();
    var id2 = $('#modelB option:selected').text();
    var SelectedMake = $('#make option:selected').text();
    var SelectedModel = $('#model option:selected').text();
    var SelectedDistance = $('#within option:selected').val();
    var EnteredZip = $('#yourZip').val();
    $('.leftArrow div').removeClass('leftAct');
    $('.leftArrow div').addClass('leftDis');
    page = 1;
    PAGEFIRST = 1;

    if (SelectedMake == 'Select make') {
        alert('Select a make');
    } else if (SelectedModel == 'null') {
        alert('Select a model');
    } else if (SelectedDistance == 'Select distance') {
        alert('Select distance');
    } else if (EnteredZip == '' || EnteredZip == null) {
        alert('Enter your ZIP');
    } else if (EnteredZip.length < 5 || (EnteredZip.length > 5 && EnteredZip.length < 10) || (EnteredZip.length > 5 && EnteredZip.length == 10 && EnteredZip.charAt(5) != '-')) {
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
                searchArray1.push(SelectedMake + ',' + SelectedModel + ',' + EnteredZip + ',' + SelectedDistance + ',' + '1' + ',' + '25' + ',' + 'price');
                searchArray1.push(make1 + ',' + id1 + ',' + EnteredZip + ',' + SelectedDistance + ',' + '1' + ',' + '25' + ',' + 'price');
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
                CarsSearch(SelectedMake, SelectedModel, EnteredZip, SelectedDistance, '1', '25', 'price');

            } else {

            }
        } else {
            if (id0 != 'Select model' && id0 != '' && id0 != null) {
                showSpinner();
                CarsSearch(SelectedMake, SelectedModel, EnteredZip, SelectedDistance, '1', '25', 'price');

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
var selectedMake;
var selectedCarID;
var selectedCarDiscription;
function carDetailsDisplay() {

    try {
        if (carDetails != undefined) {
            var m = '';
            selectedCarID = carDetails['CarUniqueID']['#text'];
            selectedMake = carDetails['Make']['#text'];
            m += carDetails['YearOfMake']['#text'] + ' ' + carDetails['Make']['#text'] + ' ' + carDetails['Model']['#text'];
            var carMakeModel = carDetails['YearOfMake']['#text'] + ' ' + carDetails['Make']['#text'] + ' ' + carDetails['Model']['#text'];
            var documentTitle = carDetails['YearOfMake']['#text'] + ' ' + carDetails['Make']['#text'] + ' ' + carDetails['Model']['#text'];

            if (carDetails['Price']['#text'] != 'Emp' && carDetails['Price']['#text'] != '0' && carDetails['Price']['#text'] != null && carDetails['Price']['#text'] != 'Unspecified') {
                m += ' - <span class="detPrice">' + carDetails['Price']['#text'] + '</span>'
                var carPrice = "-" + carDetails['Price']['#text'];
            }

            if (carDetails['Title']['#text'] != 'Emp' && carDetails['Title']['#text'] != '' && carDetails['Title']['#text'] != ' ' && carDetails['Title']['#text'] != 'undefined' && carDetails['Title']['#text'] != "Unspecified") {
                $('#carDet').empty();
                var title = '';
                if (carDetails['Title']['#text'].length > 80) {
                    title = carDetails['Title']['#text'].substring(0, 76) + "..."
                } else {
                    title = carDetails['Title']['#text'];
                }
                $('#carDet').append(title);
            } else {
                $('#carDet').empty();
                $('#carDet').append(m);
            }





            $('#SellerType').text(carDetails['SellerType']['#text']);  //carDetails['SellerType']['#text']
            if (carDetails['SellerName']['#text'] != 'Emp') {
                $('#SellerName').text(carDetails['SellerName']['#text']);
            } else {
                $('#SellerName').text('');
            }


            var dum = carDetails['Phone']['#text'];
            var phone = '';
            if (dum != null && dum != undefined && dum != '') {
                phone += dum[0] + '' + dum[1] + '' + dum[2] + '-' + dum[3] + '' + dum[4] + '' + dum[5] + '-' + dum[6] + '' + dum[7] + '' + dum[8] + '' + dum[9];
            } else {
                phone = '';
            }
            $('#SellerNo').text(phone);

            if (carDetails['Email']['#text'] != '' && carDetails['Email']['#text'] != ' ' && carDetails['Email']['#text'] != '  ' && carDetails['Email']['#text'] != 'Emp' && carDetails['Email']['#text'] != null) {
                $('#SellerEmail').text(carDetails['Email']['#text']);
            } else {
                $('#SellerEmail').css('display', 'none');
                $('#SellerEmail').prev('strong').css('display', 'none');
                $('#SellerEmail').prev().prev().remove();


            }

            var dumArray = [];
            dumArray[0] = carDetails['Address1']['#text'];
            dumArray[1] = carDetails['City']['#text'];
            dumArray[2] = carDetails['State']['#text'];
            dumArray[3] = carDetails['Zip']['#text'];
            //SaveZip(carDetails['Zip']['#text']);
            var address = ''
            var city = ''
            var state = ''
            var zip = ''

            if (dumArray[0] != 'Emp' && dumArray[0] != '' && dumArray[0] != ' ' && dumArray[0] != 'Unspecified' && dumArray[0] != 'Not Available' && dumArray[0] != undefined) {
                address = dumArray[0];
            }
            if (dumArray[1] != 'Emp' && dumArray[1] != '' && dumArray[1] != ' ' && dumArray[1] != 'Unspecified' && dumArray[1] != 'Not Available' && dumArray[1] != undefined) {
                city = dumArray[1];
            }
            if (dumArray[2] != 'Emp' && dumArray[2] != '' && dumArray[2] != ' ' && dumArray[2] != 'Unspecified' && dumArray[2] != 'Not Available' && dumArray[2] != undefined && dumArray[2] != 'UN') {
                state = dumArray[2];
            }
            if (dumArray[3] != 'Emp' && dumArray[3] != '' && dumArray[3] != ' ' && dumArray[3] != 'Unspecified' && dumArray[3] != 'Not Available' && dumArray[3] != undefined) {
                zip = dumArray[3];
            }
            city = city.toLowerCase();
            city.charAt(0).toUpperCase();
            address = address.toLowerCase();
            address.charAt(0).toUpperCase();


            if (address != '' && address != ' ' && address != '  ' && (city != '' || state != '')) {
                address = $.trim(address);
                address += ' ';
            } else {
                address = '';
            }

            if (city != '' && state != '') {
                city = $.trim(city);
                city += ', '
            } else {
                city = '';
            }

            if (state != '' && state != 'UN') {
                state += ' ';
            }

            $('#SellerAddress').empty();
            $('#SellerAddress').append(city + '' + state + '' + zip);
            $('#SellerAddress2').append("<br>" + address);



            $('#SellerAddress, #SellerAddress2').css('text-transform', 'capitalize');
            $('#yourZip').val(carDetails['Zip']['#text']);

            var det = '';

            det += "<h3 class='h3a'>About This " + carDetails['Make']['#text'] + ' ' + carDetails['Model']['#text'] + "</h3><table style='width:99%; margin:0' id='carDet1' >  <tr>    <td style='width:50%;vertical-align:top'><strong>Make: </strong> " + carDetails['Make']['#text'] + "<br /><strong>Model: </strong> " + carDetails['Model']['#text'] + "<br /><strong>Year: </strong> " + carDetails['YearOfMake']['#text'] + "<br /><strong>Body Style: </strong> ";
            if (carDetails['Bodytype']['#text'] != 'Emp' && carDetails['Bodytype']['#text'] != 'Unspecified') {
                det += carDetails['Bodytype']['#text'];
            }
            det += "<br /><strong>Exterior Color: </strong>";
            if (carDetails['ExteriorColor']['#text'] != 'Emp' && carDetails['ExteriorColor']['#text'] != 'Unspecified') {
                det += carDetails['ExteriorColor']['#text'];
            }
            det += "<br /><strong>Interior Color: </strong>";
            if (carDetails['InteriorColor']['#text'] != 'Emp' && carDetails['InteriorColor']['#text'] != 'Unspecified') {
                det += carDetails['InteriorColor']['#text'];
            }

            // ConditionDescription, DriveTrain
            det += "<br /><strong>Doors: </strong>";
            if (carDetails['NumberOfDoors']['#text'] != 'Emp' && carDetails['NumberOfDoors']['#text'] != 'Unspecified') {
                det += carDetails['NumberOfDoors']['#text'];
            }
            det += "<br /><strong>Vehicle Condition: </strong>";
            if (carDetails['ConditionDescription']['#text'] != 'Emp' && carDetails['ConditionDescription']['#text'] != 'Unspecified') {
                det += carDetails['ConditionDescription']['#text'];
            }
            det += "<br /></td><td valign='top' ><strong>Price: </strong> <span class='detPrice2'>";
            if (carDetails['Price']['#text'] != 'Emp' && carDetails['Price']['#text'] != 'Unspecified' && carDetails['Price']['#text'] != '0' && carDetails['Price']['#text'] != null) {
                det += carDetails['Price']['#text'];
            }
            det += "</span><br /><strong>Mileage: </strong>"
            if (carDetails['Mileage']['#text'] != 'Emp' && carDetails['Mileage']['#text'] != 'Unspecified' && carDetails['Mileage']['#text'] != '0' && carDetails['Mileage']['#text'] != null) {
                det += "<span class='detMileage'>" + carDetails['Mileage']['#text'] + "</span> ml";
            }
            det += "<br /><strong>Fuel: </strong>"
            if (carDetails['Fueltype']['#text'] != 'Emp' && carDetails['Fueltype']['#text'] != 'Unspecified') {
                det += carDetails['Fueltype']['#text'];
            }
            det += "<br /><strong>Engine: </strong>"
            if (carDetails['NumberOfCylinder']['#text'] != 'Emp' && carDetails['NumberOfCylinder']['#text'] != 'Unspecified') {
                det += carDetails['NumberOfCylinder']['#text'];
            }
            det += "<br /><strong>Transmission: </strong>"
            if (carDetails['Transmission']['#text'] != 'Emp' && carDetails['Transmission']['#text'] != 'Unspecified') {
                det += carDetails['Transmission']['#text'];
            }
            det += "<br /><strong>DriveTrain: </strong>";
            if (carDetails['DriveTrain']['#text'] != 'Emp' && carDetails['DriveTrain']['#text'] != 'Unspecified') {
                det += carDetails['DriveTrain']['#text'];
            }
            det += "<br /><strong>VIN: </strong>"
            if (carDetails['VIN']['#text'] != 'Emp' && carDetails['VIN']['#text'] != 'Unspecified') {
                det += carDetails['VIN']['#text'];
            }
            det += "<br /></td></tr></table><div class='clear'></div>"



            $('.disc').empty();
            $('.disc').append(det);

            var m = '';
            var Email = carDetails['Email']['#text'];


            // m += "<br><p><strong>Description: </strong>"+carDetails['Description']['#text']+"</p><p><a href='javascript:sendMailtoSeller("+Email+")'>Write a note to seller</a> </p>"

            /*
            m += "<br><p><strong style='font-size: 1.17em;'>Description: </strong>";
            if(carDetails['Description']['#text'] != 'Emp' && carDetails['Description']['#text'] != undefined && carDetails['Description']['#text'] != null){
            m += carDetails['Description']['#text']+"</p>";
            }else{
            m += "</p>"; 
            }
            */
            if (carDetails['Description']['#text'] != 'Emp' && carDetails['Description']['#text'] != undefined && carDetails['Description']['#text'] != null) {
                selectedCarDiscription = carDetails['Description']['#text'];
            }

            m += "<br><p class='Comfort'></p>";

            $('.SellerNotes').empty();
            $('.SellerNotes').append(m);
            CarID1 = carDetails['CarUniqueID']['#text']

            GetCarFeatures(CarID1);



            $('.detPrice, .detPrice2').formatCurrency();
            $('.detMileage').formatCurrency({ symbol: ' ' });
            $('#carDetailsDivHolder').show();

            var settings = { start: 1, change: false };
            $("#adv1 ul").idTabs(settings, true);

            var el = $('#carDet1');
            el.html(el.html().replace(/undefined/ig, "Not Available"));
            var el = $('#carDet0');
            el.html(el.html().replace(/undefined/ig, "Not Available"));



            // Slider1
            $("div#basic").slideViewerPro({
                galBorderWidth: 3,
                autoslide: true,
                thumbsVis: false,
                shuffle: false
            });

            var totalImages = $('div#basic2 ul li').length;
            ////console.log(totalImages);
            $('div#basic2 ul li img').each(function() {

                var img = $(this);
                var width = 0; var height = 0;
                $("<img/>").attr("src", $(this).attr("src")).load(function() {
                    totalImages--;
                    width = this.width;   // Note: $(this).width() will not
                    height = this.height; // work for in memory images.                          

                    var maxWidth = 680; // Max width for the image
                    var maxHeight = 452;    // Max height for the image          


                    ratio = maxWidth / width;   // get ratio for scaling image
                    img.attr("width", maxWidth); // Set new width
                    img.attr("height", height * ratio); // Scale height based on ratio

                    ////console.log(img.width()+", "+img.height()); 

                    if (totalImages == 1) {
                        // Slider2
                        ////console.log(totalImages);
                        $("div#basic2").slideViewerPro({
                            thumbs: 6,
                            thumbsPercentReduction: 14
                        });
                    }

                });
            });
        }

        //if (carDetails['IsActive']['#text'] == 'false') {
        //$('.sellerInfo1, .sellerInfo2').hide();
        //$('.soldCar').show();
        //} else {
        //$('.sellerInfo1, .sellerInfo2').show();
        //$('.soldCar').hide();
        //}

    }
    catch (ex) { }
}



function carFretures(result) {
    ////console.log(result);
    $('.Comfort').empty();
    var p = ''
    var Comfort = [];
    var Seats = [];
    var Safety = [];
    var Sound = [];
    var Windows = [];
    var Other = [];
    for (i = 0; i < result.length; i++) {
        var str = result[i];
        if (str.substring(0, 7) == 'Comfort') {
            Comfort.push(str);
        } else if (str.substring(0, 5) == 'Seats') {
            Seats.push(str);
        } else if (str.substring(0, 6) == 'Safety') {
            Safety.push(str);
        } else if (str.substring(0, 5) == 'Sound') {
            Sound.push(str);
        } else if (str.substring(0, 7) == 'Windows') {
            Windows.push(str);
        } else if (str.substring(0, 5) == 'Other') {
            Other.push(str);
        }
    }

    p += "<h3 style='padding:0; margin:0 0 4px 0'>Car Specifications</h3>"

    p += '<strong>Comfort: </strong><label>';
    for (i = 0; i < Comfort.length; i++) {
        p += Comfort[i].substring(8);
        if (i != Comfort.length - 1) {
            p += ', ';
        }
    }
    p += '</label>';

    p += '<br><strong>Seats: </strong><label>';
    for (i = 0; i < Seats.length; i++) {
        p += Seats[i].substring(6)
        if (i != Seats.length - 1) {
            p += ', ';
        }
    }
    p += '</label>';

    p += '<br><strong>Safety: </strong><label>';
    for (i = 0; i < Safety.length; i++) {
        p += Safety[i].substring(7)
        if (i != Safety.length - 1) {
            p += ', ';
        }
    }
    p += '</label>';

    p += '<br><strong>Sound: </strong><label>';
    for (i = 0; i < Sound.length; i++) {
        ////console.log(Sound[i]);
        p += Sound[i].substring(13)
        if (i != Sound.length - 1) {
            p += ', ';
        }
    }
    p += '</label>';

    p += '<br><strong>Windows: </strong><label>';
    for (i = 0; i < Windows.length; i++) {
        p += Windows[i].substring(8)
        if (i != Other.length - 1) {
            p += ', ';
        }
    }
    p += '</label>';

    p += '<br><strong>Other: </strong><label>';
    for (i = 0; i < Other.length; i++) {
        p += Other[i].substring(6)
        if (i != Other.length - 1) {
            p += ', ';
        }
    }
    p += '</label>';


    p += "<br><p style='padding-top:17px; padding-bottom:14px;'><strong style='font-size: 1.17em;'>Description: </strong>" + selectedCarDiscription;

    p += '<br><div class="clear">&nbsp;</div>';

    p += '<strong style=" float:left; padding-top:4px;">Surrounding towns:&nbsp;</strong><ul class="towns" style="font-size:11px;"></ul>';

    p += '<br><div class="clear">&nbsp;</div><strong >Near by zip codes: </strong><span class="zip" style="font-size:11px;"></span>'

    $('.Comfort').append(p);
    $('.Comfort label').each(function() {
        $(this).text($(this).text().trim());
        var len = $(this).text().length;

        if ($(this).text().charAt(len - 1) == ',') {
            $(this).text($(this).text().substring(0, len - 1));
        }
    });
    /*
    if($('.Comfort strong').html().last() == ','){
    //var len = $(this).html().length;
    $(this).html().substring(0, $(this).html().length - 1);
    }
    */

    ////console.log(selectedMake);
    //SimialarCars(selectedMake);

}
var tooltip = $('<div id="tooltip" class="sliderTip" />').css({
    position: 'absolute',
    top: -25,
    left: -10,
    background: '#fff',
    fontWeight: 'bold'
}).hide();
// MinMaxSlider(){
function MinMaxSlider(result) {
    /* Email, Address1 --> Price
    Address2, City  --> Year
    State, Description -->Mileage
    */
    //console.log(result.Email['#text']);







    var minPrice = parseInt(result.Email['#text']);
    var maxPrice = parseInt(result.Address1['#text']);

    var minMileage = parseInt(result.State['#text']);
    var maxMileage = parseInt(result.Description['#text']);



    var minYear = parseInt(result.Address2['#text']);
    var maxYear = parseInt(result.City['#text']);




    Mileage1 = minMileage;
    Mileage2 = maxMileage;
    Year1a = minYear;
    Year1b = maxYear;
    Price1 = minPrice;
    Price2 = maxPrice;


    //console.log(minPrice, maxPrice, minMileage, maxMileage);
    $('#yearRange, #priceRange, #mileRange').removeAttr('disabled');
    $('#yearRange').val(minYear + ';' + maxYear);


    if (parseInt($.trim($('#hdnPriceMIN').val())) >= minPrice) {
        var minPP = parseInt($.trim($('#hdnPriceMIN').val()));
    } else {
        var minPP = minPrice
    }
    if (parseInt($.trim($('#hdnPriceMAX').val())) <= maxPrice) {
        var maxPP = parseInt($.trim($('#hdnPriceMAX').val()));
    } else {
        var maxPP = maxPrice
    }
    $('#priceRange').val(minPrice + ';' + maxPrice);






    if (parseInt($.trim($('#hdnMileageMIN').val())) >= minMileage) {
        var minMM = parseInt($.trim($('#hdnMileageMIN').val()));
    } else {
        var minMM = minMileage
    }
    if (parseInt($.trim($('#hdnMileageMAX').val())) <= maxMileage) {
        var maxMM = parseInt($.trim($('#hdnMileageMAX').val()));
    } else {
        var maxMM = maxMileage
    }

    //console.log(minPP, maxPP, minMM, maxMM)
    $('#mileRange').val(minMileage + ';' + maxMileage);


    $("#yearRange").slider({
        from: minYear,
        to: maxYear,
        format: { format: '##' },
        step: 1,
        dimension: '&nbsp;(year)',
        callback: function(value) {
            var pp = value.split(';')
            Year1a = pp[0];
            Year1b = pp[1];
            rangeSliderChangge();
        }
    });


    $("#priceRange").slider({
        from: minPrice,
        to: maxPrice,
        //heterogeneity: ['50/50000'],
        step: 1000,
        dimension: '&nbsp;$',
        callback: function(value) {
            var pp = value.split(';')
            Price1 = pp[0];
            Price2 = pp[1];
            rangeSliderChangge();
        }
    });


    $("#mileRange").slider({
        from: minMileage,
        to: maxMileage,
        step: 100,
        round: 1,
        // heterogeneity: ['50/50000'],
        dimension: '&nbsp;mi',
        callback: function(value) {
            var pp = value.split(';')
            Mileage1 = pp[0];
            Mileage2 = pp[1];
            rangeSliderChangge();
        }
    });


}

// CarsMatchedDataBinding

function CarsMatchedDataBinding(CarsAdDetails) {

    var path;
    var AddName = true;

    //console.log(CarsAdDetails);

    // Vertical Car Ads
    if (CarsAdDetails.length > 0 && LoadingPage != 2) {
        var img = '';
        var withinZIp1 = 5;
        var zip1 = 0;
        //console.log(CarsAdDetails);
        $('#grid-carousel').empty();


        for (i = 5; i < CarsAdDetails.length; i++) {
            img = '';
            //var resPath = "'" + CarsAdDetails[i]['YearOfMake']['#text'] + "','" + CarsAdDetails[i]['CarUniqueID']['#text'] + "','" + CarsAdDetails[i]['Make']['#text'] + "','" + CarsAdDetails[i]['Model']['#text'] + "','" + zip1 + "','" + withinZIp1 + "','" + AddName + "'";

            var resPath2 = '../usedcars/' + $.trim(CarsAdDetails[i]['YearOfMake']['#text']) + '-' + $.trim(CarsAdDetails[i]['Make']['#text']) + '-' + $.trim(CarsAdDetails[i]['Model']['#text']) + '-' + $.trim(CarsAdDetails[i]['City']['#text']) + '-' + $.trim(CarsAdDetails[i]['State']['#text']) + '-' + $.trim(CarsAdDetails[i]['CarUniqueID']['#text']);
            
            var thumb1 = '';
            if (CarsAdDetails[i]['PIC0']['#text'] != 'Emp') {
                path = CarsAdDetails[i]['PICLOC0']['#text'] + "/" + CarsAdDetails[i]['PIC0']['#text'];
                for (k = 0; k < 5; k++) {
                    path = path.replace("\\", "/");
                }
                path = path.replace("//", "/");
                thumb1 = "<img src='http://unitedcarexchange.com/" + path + "' class='thumbV'  style='width:100%; height:auto' />";
            } else {
                var carMake = CarsAdDetails[i]['Make']['#text'];
                var carModel = CarsAdDetails[i]['Model']['#text'];
                carMake = carMake.replace(' ', '-');
                carModel = carModel.replace(' ', '-');
                carModel = carModel.replace('/', '@');
                /*
                if(carModel.indexOf('/')>0){
                carModel='Other';			            
                }
                */
                var MakeModel = carMake + "_" + carModel;
                MakeModel = MakeModel.replace(' ', '-');
                MakeModel = MakeModel.replace('/', '@');
                path = "http://unitedcarexchange.com/images/MakeModelThumbs/" + MakeModel + ".jpg";


                thumb1 = "<img src='" + path + "' class='thumbV'  style='width:100%; height:auto' /><div class='stockPhoto2' >Stock Photo</div>";


            }
            //img +=  "<li> "+thumb1+"<strong><a href='javascript:EncryptedCarID("+resPath+");'>"+CarsAdDetails[i]['YearOfMake']['#text']+" "+CarsAdDetails[i]['Make']['#text']+" "+CarsAdDetails[i]['Model']['#text']+"</a></strong> <b class='price11'>"+CarsAdDetails[i]['Price']['#text']+"</b> </li>";
            

            //-------------------------


            img += '<div class="inner">';
            img += '<div class="grid-item">';
            img += '<div class="inner">';
            img += '<div class="picture">';
            img += '<div class="image-slider">';
            img += '<a href="' + resPath2 + '" class="slide">' + thumb1 + '</a></div></div>';

            img += '<div class="like">';
            img += '<a href="' + resPath2 + '"><i class="icon icon-outline-thumb-up"></i></a>';
            img += '</div>';

            img += '<h3><a href="' + resPath2 + '">' + CarsAdDetails[i]["Make"]["#text"] + '  ' + CarsAdDetails[i]["Model"]["#text"] + '</a></h3>';
            img += '<div class="subtitle">' + CarsAdDetails[i]["YearOfMake"]["#text"] + '</div>';




            var price1 = CarsAdDetails[i]['Price']['#text'];
            if (price1 != 'Emp' && price1 != '0' && price1 != 0 && price1 != null && price1 != 'unspecified') {
                img += '<div class="price price11">' + price1 + '</div>';
            } else {
            img += '<div class="price"><a href="' + resPath2 + '" class="contactSellerLink">Contact Seller</a></div>';
            }




            //img += '<div class="description"><p>' + CarsAdDetails[i]["Description"]["#text"] + '</p></div>'
            /*
            img += '<div class="meta">';
            img += '<ul class="clearfix ">';
            img += '<li><i class="icon icon-normal-dashboard"></i>' + CarsAdDetails[i]["Mileage"]["#text"] + ' </li>';
            img += '<li><i class="icon icon-normal-car-door"></i>' + CarsAdDetails[i]["NumberOfDoors"]["#text"] + ' </li>';
            img += '<li><i class="icon icon-normal-cog-wheel"></i>' + CarsAdDetails[i]["DriveTrain"]["#text"] + ' </li>';
            img += '</ul></div>';
            */
            img += '</div></div></div>';

            //-------------------------

            $('#grid-carousel').append(img);
        }

        //console.log(img)


        _initGridCarousel('.grid-carousel');





    };

    $('.price11, .price12').formatCurrency();
    $('.mileageHome').formatCurrency({ symbol: ' ' });

}


// function Null or Emp or 0 or ''
function nullCheck(data) {
    if (data == null || data == '0' || data == 'Emp' || data == undefined || data == '' || data == ' ') {
        data = 'Unspecified';
    }

    return data;
}