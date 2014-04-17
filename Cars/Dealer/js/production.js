/*!
* Auther      : Jyothirmayudu.CH
* Created on  : 5 July 2012
* Mail        : ch.jmayudu@gmail.com
* Discription : JS for Production Team
*/

var models;
LoadingPage = 3;
var selectedCarDiscription = "";

var siteURL = "http://UnitedCarExchange.com/";
//var siteURL = "http://cars.hugomirad.com/";



$(function() {
    $('.box1 li a').click(function() {
        var p1 = $(this).attr('id');
        window.location.href = "Home.aspx?C=" + p1 + ""
    });
});

KeyListener = {
    init: function() {
        $('#searchFormHolder').bind('keypress', function(e) {
            var key = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
            var target = e.target.tagName.toLowerCase();
            if (key === 13 && target === 'input') {
                e.preventDefault();
                var button = $('.search');
                if (button.length > 0) {
                    if (typeof (button.get(0).onclick) == 'function') {
                        button.trigger('click');
                    } else if (button.attr('href')) {
                        window.location = button.attr('href');
                    } else {
                        button.trigger('click');
                    }
                }

            }

        });
    }
};

function productionPage(carDetails) {
    //console.log(carDetails);
    $('.stock').hide();
    if (carDetails != 'undefined' && carDetails != undefined && page != 10) {
        var year = carDetails._yearOfMake;
        var make = carDetails._make;
        var model = carDetails._model;
                    make = make.replace(' ', '-');
            model = model.replace(' ', '-');
            model = model.replace('/', '@');
            model = model.replace('&', '@');
                       make = make.replace(' ', '-');
            model = model.replace(' ', '-');
            model = model.replace(' ', '-');
            model = model.replace('/', '@');
            model = model.replace('&', '@');
        var Zip = carDetails._zip;
        var carID = carDetails._carid;
        DealerUniqueID = carDetails._DealerUniqueID
        
        
        CARID = carDetails._carid;

        if (carDetails._PICID0 != 'Emp' && carDetails._PICID0 != 0 && carDetails._PICID0 != '0') {
            PICID0 = carDetails._PICID0;
        } else {
            PICID0 = '';
        }

        var img1 = '';
        var imgCount = 0;
        mainPostingID = carDetails._postingID
        $('.useTopMenu .editCar').click(function() {
            window.location.href = 'EditCar.aspx?CarInventoryID=' + carDetails._CarUniqueID + 'P' + carDetails._postingID + '';
        })

        ////console.log(mainPostingID)
        for (i = 1; i < 21; i++) {
            if (carDetails['_PIC' + i] && carDetails['_PICLOC' + i]) {
                var path = "'" + carDetails['_PICLOC' + i] + "/" + carDetails['_PIC' + i] + "'";
                var loaction = carDetails['_PICLOC' + i];
                var img = carDetails['_PIC' + i]
                path = siteURL + loaction + img;
                img1 += "<li><img  src=" + path + " picId = " + carDetails["_PICID" + i] + "   /></li>";

            } else {
                imgCount++;
            }
        }
        if (imgCount > 19) {
            var path2 = "" + siteURL + "'images/stockMakes/" + carDetails._make + ".jpg'";
            var carMake = carDetails._make;
            var carModel = carDetails._model;

            carMake = carMake.replace(' ', '-');
            carModel = carModel.replace(' ', '-');
            carModel = carModel.replace('/', '@');
            carModel = carModel.replace('&', '@');
            
            var MakeModel = carMake + "_" + carModel;
            MakeModel = MakeModel.replace(' ', '-');
            MakeModel = MakeModel.replace('/', '@');
            
            path2 = "" + siteURL + "images/MakeModelThumbs/" + MakeModel + ".jpg";
            var path1 = "" + siteURL + "'images/no-image.jpg'";

            img1 += "<li><img  src=" + path2 + " /><div class='stock'>Stock Photo</div></li>";
            //$('div.imgHolder').width(($('.box2').width()) - 100);
            //$('div.imgHolder ul').empty().append(img1);
            $('.stock').show();

        } else {
            //$('div.imgHolder').width(($('.box2').width()) - 100);
            //$('div.imgHolder ul').empty().append(img1);
            $('.stock').hide();
        }

        $('.currentStat').text(carDetails._AdStatus);

        $('#resAction1 option').each(function() {
            this.selected = (this.text == carDetails._AdStatus);
        });
        var m = '';

        /*m += carDetails['YearOfMake']+' '+carDetails._make+' '+carDetails._model;	*/

        if (carDetails._Title != 'Emp' && carDetails._Title != '' && carDetails._Title != ' ' && carDetails._Title != 'undefined' && carDetails._Title != 'unspecified') {
            var title = carDetails._Title;
            m += title;
        } else {
            m += carDetails._yearOfMake + " " + carDetails._make + " " + carDetails._model;
        }

        if (carDetails._price != 'Emp' && carDetails._price != '0' && carDetails._price != null && carDetails._price != 'Unspecified') {
            m += ' - <span class="detPrice">' + carDetails._price + '</span>'
        }

        $('.Title').empty().append(m);
        var address = '';

        if (carDetails._carid != 'Emp' && carDetails._carid != '' && carDetails._carid != 'undefined' && carDetails._carid != null) {
            $('.carID').text(carDetails._DealerUniqueID);
        }
        if (carDetails._sellerName != 'Emp' && carDetails._sellerName != '' && carDetails._sellerName != 'undefined' && carDetails._sellerName != null) {
            $('.name').text(carDetails._sellerName);
        }
        if (carDetails._email != 'Emp' && carDetails._email != '' && carDetails._email != 'undefined' && carDetails._email != null) {
            $('.email').text(carDetails._email);
        }
        //console.log(carDetails._city, carDetails._state);
        if (carDetails._city != 'Emp' && carDetails._city != '' && carDetails._city != 'undefined' && carDetails._city != null && carDetails._city != 'Unspecified') {
            address = carDetails._city;
        }
        
        if (carDetails._city != 'Emp' && carDetails._state != 'Emp' && carDetails._state != '' && carDetails._state != 'undefined' && carDetails._state != null && carDetails._state != 'Unspecified') {
            address += ', ' + carDetails._state;
            $('.city').text(address);
        } if (carDetails._city == 'Emp' && carDetails._state != 'Emp' && carDetails._state != '' && carDetails._state != 'undefined' && carDetails._state != null && carDetails._state != 'Unspecified') {
            address +=  carDetails._state;
            $('.city').text(address);
        } else {
            $('.city').text(address);
        }
        
        if (Zip != 'Emp') {
            var totalAdd = $('.city').text() + " " + Zip;
        }

        $('.city').text(totalAdd);



        if (carDetails._phone != 'Emp' && carDetails._phone != '' && carDetails._phone != 'undefined' && carDetails._phone != null) {
            var dum = carDetails._phone;
            var phone = '';
            if (dum != null && dum != undefined && dum != '') {
                phone += dum[0] + '' + dum[1] + '' + dum[2] + '-' + dum[3] + '' + dum[4] + '' + dum[5] + '-' + dum[6] + '' + dum[7] + '' + dum[8] + '' + dum[9];
            } else {
                phone = '';
            }

            $('.phone').text(phone);
        }

        //Buy - Sell - UsedCar / 1991 - Volkswagen - Vanagon - 518445981658
        //$('.link1').attr('href','http://UnitedCarExchange.com/SearchCarDetails.aspx?Make='+make+'&Model='+model+'&ZipCode='+Zip+'&WithinZip=5&C=l3tTlT66'+carID).attr('readonly','readonly');
        $('.link1').attr('href', '' + siteURL + 'Buy-Sell-UsedCar/' + year + '-' + make + '-' + model + '-' + carDetails._CarUniqueID);
        $('.link1').html(encodeURI(('href', '' + siteURL + 'Buy-Sell-UsedCar/' + year + '-' + make + '-' + model + '-' + carDetails._CarUniqueID)));

        $('.url').empty().html(encodeURI($('.link1').attr('href')));

        var det = '';
        det += '<fieldset class="formUploadCar"><legend class="Title2">About This ' + carDetails._make + ' ' + carDetails._model + '</legend>';
        det += "<table style='width:600px; margin:0' id='carDet1' >  <tr>    <td style='width:50%;vertical-align:top'><strong>Make: </strong> " + carDetails._make + "<br /><strong>Model: </strong> " + carDetails._model + "<br /><strong>Year: </strong> " + year + "<br /><strong>Body Style: </strong> ";
        if (carDetails._bodytype != 'Emp' && carDetails._bodytype != 'Unspecified') {
            det += carDetails._bodytype;
        }
        det += "<br /><strong>Exterior Color: </strong>";
        if (carDetails._exteriorColor != 'Emp' && carDetails._exteriorColor != 'Unspecified') {
            det += carDetails._exteriorColor;
        }
        det += "<br /><strong>Interior Color: </strong>";
        if (carDetails._interiorColor != 'Emp' && carDetails._interiorColor != 'Unspecified') {
            det += carDetails._interiorColor;
        }

        // ConditionDescription, DriveTrain
        det += "<br /><strong>Doors: </strong>";
        if (carDetails._numberOfDoors != 'Emp' && carDetails._numberOfDoors != 'Unspecified') {
            det += carDetails._numberOfDoors;
        }
        det += "<br /><strong>Vehicle Condition: </strong>";
        if (carDetails._ConditionDescription != 'Emp' && carDetails._ConditionDescription != 'Unspecified') {
            det += carDetails._ConditionDescription;
        }
        det += "<br /></td><td valign='top' ><strong>Price: </strong><span class='detPrice2'>";
        if (carDetails._price != 'Emp' && carDetails._price != 'Unspecified' && carDetails._price != '0' && carDetails._price != null) {
            det += carDetails._price;
        }
        det += "</span><br /><strong>Mileage:</strong>"
        if (carDetails._mileage != 'Emp' && carDetails._mileage != 'Unspecified' && carDetails._mileage != '0' && carDetails._mileage != null) {
            det += "<span class='detMileage'>" + carDetails._mileage + "</span> mi";
        }
        det += "<br /><strong>Fuel: </strong>"
        if (carDetails._Fueltype != 'Emp' && carDetails._Fueltype != 'Unspecified') {
            det += carDetails._Fueltype;
        }
        det += "<br /><strong>Number Of Cylinder: </strong>"
        if (carDetails._numberOfCylinder != 'Emp' && carDetails._numberOfCylinder != 'Unspecified') {
            det += carDetails._numberOfCylinder;
        }
        det += "<br /><strong>Transmission: </strong>"
        if (carDetails._Transmission != 'Emp' && carDetails._Transmission != 'Unspecified') {
            det += carDetails._Transmission;
        }
        det += "<br /><strong>Drivetrain: </strong>";
        if (carDetails._DriveTrain != 'Emp' && carDetails._DriveTrain != 'Unspecified') {
            det += carDetails._DriveTrain;
        }
        det += "<br /><strong>VIN: </strong>"
        if (carDetails._VIN != 'Emp' && carDetails._VIN != 'Unspecified') {
            det += carDetails._VIN;
        }
        det += "<br /></td></tr>";
        // det += "<tr><td colspan='2'><br /><h3>Description</h3><label>" + carDetails._description + "</label></td></tr>";
        det += "</table>";
        det += "</fieldset>"

        $('.disc').empty();

        $('.disc').append(det);

        var m = '';
        var Email = carDetails._email;


        // m += "<br><p><strong>Description: </strong>"+carDetails._description+"</p><p><a href='javascript:sendMailtoSeller("+Email+")'>Write a note to seller</a> </p>"

        /**
        m += "<br><p><strong style='font-size: 1.17em;'>Description: </strong>";
        if(carDetails._description != 'Emp' && carDetails._description != undefined && carDetails._description != null){
        m += carDetails._description+"</p>";
        }else{
        m += "</p>"; 
        }
        **/
        
        if (carDetails._description != 'Emp' && carDetails._description && carDetails._description != null && carDetails._description != undefined) {
            selectedCarDiscription = carDetails._description;
        } else {
            selectedCarDiscription = "";
        }

      

        m += "<p class='Comfort'></p>";

        $('.SellerNotes').empty();
        $('.SellerNotes').append(m);

        CarID1 = carDetails._CarUniqueID
        //console.log(CarID1);
        GetCarFeaturesDealer(CarID1);

        $('.detPrice, .detPrice2').formatCurrency();
        $('.detMileage').formatCurrency({ symbol: '' });
        $('.proDet').show();
        $('#spinner').hide();
    } else if (page != 10) {
        $('.proDet').hide();
        $('#spinner').hide();
        alert('Dealer Inv ID does not exist..!');
    }

    if (carDetails != 'undefined' && carDetails != undefined && page == 10) {
        ////console.log(carDetails)
        var year = carDetails._yearOfMake;
        var make = carDetails._make;
        var model = carDetails._model;
         make = make.replace(' ', '-');
         make = make.replace(' ', '-');
            model = model.replace(' ', '-');
            model = model.replace(' ', '-');
            model = model.replace(' ', '-');
            model = model.replace('/', '@');
            model = model.replace('/', '@');
            model = model.replace('&','@');
            model = model.replace('&','@');
        var Zip = carDetails._zip;
        var carID = carDetails._carid;
        DealerUniqueID = carDetails._DealerUniqueID
        CARID = carDetails._carid;

        if (carDetails._PICID0 != 'Emp' && carDetails._PICID0 != 0 && carDetails._PICID0 != '0') {
            PICID0 = carDetails._PICID0;
        } else {
            PICID0 = '';
        }
        var img1 = '';
        var imgCount = 0;




        /*
        <li><div>
        <img src="images/thumbs/slr2.jpg" class="thumb">
        <div class="imgDrag" >&nbsp;</div>
        <div class="imgDelete" >&nbsp;</div>
        </div></li>
        */
        
        
        $('#hdnYear').val(carDetails._yearOfMake);
        $('#hdnMake').val(carDetails._make);
        $('#hdnModel').val(carDetails._model);
        
        for (i = 1; i < 21; i++) {
            if (carDetails['_PIC' + i] && carDetails['_PICLOC' + i] && carDetails['_PIC' + i] != 'Emp' && carDetails['_PICLOC' + i] != 'Emp') {
                var path = "'" + carDetails['_PICLOC' + i] + "/" + carDetails['_PIC' + i] + "'";
                var loaction = carDetails['_PICLOC' + i];
                var img = carDetails['_PIC' + i]
                path = siteURL + loaction + img;
                img1 += '<li><div>';
                img1 += '<img src="' + path + '" picId = ' + carDetails["_PICID" + i] + '  class="thumb">';
                img1 += '<div class="imgDrag" >&nbsp;</div>'
                img1 += '<div class="imgDelete" >&nbsp;</div>'
                img1 += '</div></li>';

            } else {
                imgCount++;
            }
        }
        if (imgCount > 19) {
            var path2 = "" + siteURL + "'images/stockMakes/" + carDetails._make + ".jpg'";
            var carMake = carDetails._make;
            var carModel = carDetails._model;

            carMake = carMake.replace(' ', '-');
            carModel = carModel.replace(' ', '-');
            carModel = carModel.replace(' ', '-');
            carModel = carModel.replace(' ', '-');
            carModel = carModel.replace('/', '@');
            carModel = carModel.replace('/', '@');
            carModel = carModel.replace('&','@');
            carModel = carModel.replace('&','@');
            var MakeModel = carMake + "_" + carModel;
            MakeModel = MakeModel.replace(' ', '-');
            MakeModel = MakeModel.replace('/', '@');
                MakeModel = MakeModel.replace(' ', '-');
            MakeModel = MakeModel.replace('/', '@');
            path2 = "" + siteURL + "images/MakeModelThumbs/" + MakeModel + ".jpg";
            var path1 = "" + siteURL + "'images/no-image.jpg'";

            img1 += "<li><img  src=" + path2 + " /><div class='stock'>Stock Photo</div></li>";
            $('div.thumbsUpload-holder').width(($('.box2').width()) - 100);
            $('div.thumbsUpload-holder ul').empty().append(img1);
            $('.stock').show();

        } else {
            $('div.thumbsUpload-holder').width(($('.box2').width()) - 100);
            $('div.thumbsUpload-holder ul').empty().append(img1);
            $('.stock').hide();
            imgDrag();
        }

        // imageOrder Button Enable If images are more than 1
        $('#imageOrder, #imagesSave').attr('disabled', 'disabled');
        if ($('.thumbsUpload li').length <= 1) {
            $('#imageOrder, #imagesSave').attr('disabled', 'disabled');
        } else {
            $('#imageOrder').removeAttr('disabled');
        }

        $('.headding1 span').empty().append(CarID1[1]);
        $('#spinner').hide();
        $('#queue, #file_upload').hide();

        
        
        
        if ($.browser.name == 'safari' || $.browser.name == 'Safari') {

            // Upload Images HTML 
            var links = '<link href="_scripts/uploadHTML5/uploadifive.css" rel="stylesheet" type="text/css" />';
            links += '<script src="_scripts/uploadHTML5/jquery.uploadifive.min.js" type="text/javascript"></script>';
            $('head').append(links);


            //alert($.browser.name);
            $('#queue, #file_upload').show();
            $('#file_upload').uploadifive({
                'auto': true,
                'buttonText': 'Upload Photos',
                'uploadScript': 'FileUploads.aspx?make=' + make + '*' + model + '*' + year + '*' + carID + '',
                'fileSizeLimit': '4MB', //4048576,
                'fileType': 'image',
                'queueSizeLimit': imgCount,
                'simUploadLimit': 2,
                'multi': true,
                'width': 120,
                'onError': function(a, b, c, d) {
                    if (d.status == 404)
                        alert("Could not find upload script. Use a path relative to: " + "<?= getcwd() ?>");
                    else if (d.type === "HTTP")
                        alert("error " + d.type + ": " + d.status);
                    else if (d.type === "File Size")
                        alert(c.name + " " + d.type + " Limit: " + Math.round(d.info / (1024 * 1024)) + "MB");
                    else
                        alert("error " + d.type + ": " + d.text);
                },
                'onQueueComplete': function(event, data) {
                    location.reload();
                }
            });
        } else {

            // Upload Images Flash 
            var links = '<link href="_scripts/uploadify.css" rel="stylesheet" type="text/css" />';
            links += '<script type="text/javascript" src="_scripts/swfobject.js"></script>';
            links += '<script type="text/javascript" src="_scripts/jquery.uploadify.min.js"></script>'
            $('head').append(links);

            $('#queue, #file_upload').hide();
            $('#fuFiles').uploadify({
                'swf': '_scripts/uploadify.swf',
                'uploader': 'FileUploads.aspx?make=' + make + '*' + model + '*' + year + '*' + carID + '',
                'scriptData': { 'RequireUploadifySessionSync': true, 'SecurityToken': UploadifyAuthCookie, 'SessionId': UploadifySessionId },
                'formData': { 'KeyA': 'AValue', 'KeyB': 1, 'RequireUploadifySessionSync': true, 'SecurityToken': UploadifyAuthCookie, 'SessionId': UploadifySessionId}, // If some static data
                'auto': 'true',
                //'cancelImg': '_scripts/cancel.png',
                'fileTypeDesc': 'Image Files',
                'fileTypeExts': '*.gif; *.jpg; *.png',
                'multi': 'true',
                'buttonCursor': 'hand',
                'buttonText': 'Upload Photos',
                'fileSizeLimit': '4MB',
                //'uploadLimit': 2,
                //'queueSizeLimit': imgCount,
                'onError': function(a, b, c, d) {
                    if (d.status == 404)
                        alert("Could not find upload script. Use a path relative to: " + "<?= getcwd() ?>");
                    else if (d.type === "HTTP")
                        alert("error " + d.type + ": " + d.status);
                    else if (d.type === "File Size")
                        alert(c.name + " " + d.type + " Limit: " + Math.round(d.info / (1024 * 1024)) + "MB");
                    else
                        alert("error " + d.type + ": " + d.text);
                },
                'onQueueComplete': function(event, data) {
                    //$('#status-message').text(data.filesUploaded + ' files uploaded, ' + data.errors + ' errors.');
                    //$('.showPicBox').html("<p>Hello Again</p>");
                    //FindDealerCarID(CarID1[1]);
                    location.reload();
                }
            });
        }




    }




}


function deleteImage() {
    $('#imagesSave').attr('disabled', 'disabled');
    if ($('.thumbsUpload li').length <= 1) {
        $(' #imagesSave').attr('disabled', 'disabled');
    } else {
        $('#imagesSave').removeAttr('disabled');
    }
}


function imgDrag() {

    $("ul.thumbsUpload").dragsort({ dragSelector: "div.imgDrag", dragBetween: true, dragEnd: saveOrder, placeHolderTemplate: "<li class='placeHolder'><div></div></li>" });

    $('#imageOrder').attr('disabled', 'disabled');
    if ($('.thumbsUpload li').length <= 1) {
        $('#imageOrder').attr('disabled', 'disabled');
    } else {
        $('#imageOrder').removeAttr('disabled');
    }


    // thumbsUpload img Hover
    if ($('.archiveBlock ul').children().length > 0) {
        $('.archiveBlock').show();
    } else { $('.archiveBlock').hide(); }
    $('.thumbsUpload li').hover(function() {
        $(this).children().children('.imgDrag').fadeIn();
        $(this).children().children('.imgDelete').fadeIn();
    }, function() {
        $(this).children().children('.imgDrag').fadeOut();
        $(this).children().children('.imgDelete').fadeOut();
    });


    $('.thumbsUpload li .imgDelete').click(function(e) {
        deleteImage();
        e.preventDefault();
        /*
        var newDate = new Date();
        newDate.setDate(newDate.getDate() + 1);
        var cDate = $.format.date(newDate, 'ddd dd MMMM yyyy HH:mm');
        var archiveInfo = "<span class='revertDate'><b>Deleted on</b><br>" + cDate + "</span><a href='#' class='revert'>Revert</a>";
        var deltedPc = '<li><div>' + $(this).parent().html() + '' + archiveInfo + '</div></li>';
        $('.archiveBlock ul').append(deltedPc);
        */

        $(this).parent().parent().remove();
        if ($('.thumbsUpload li ').length <= 0) {
            $('.thumbsUpload').append("<h4 style='color:#ff9900; text-align:center; font-size:18px; font-weifgt:normal; margin-top:100px; display:block; width:100%;'>No images available</h4>");
        }
        /*
        if ($('.archiveBlock ul').children().length > 0) {
        //$('.archiveBlock ul li div').css({ cursor: '', display:'block' });
        $('.archiveBlock li div div').hide();
        $('.archiveBlock').show();
            
        $('.archiveBlock ul li a.revert').click(function(){
					
					var ind = $(this).parent().parent().index();
					
					$(this).prev().remove();
        $(this).remove();								
							
        if($('.thumbsUpload li').length == 0){
        $('.thumbsUpload h4').remove();				
        }
        $('.thumbsUpload').append($('.archiveBlock ul li:eq('+(ind+1)+')'));
        //$('.archiveBlock ul li:eq('+(ind+1)+')').remove();				
							
        })
           
        } else { $('.archiveBlock').hide(); }
        
        */


    });
}


var dum22 = [];
function carFretures(result) {
    //console.log(result);
    //dum22 = result;
    $('.Comfort').empty();
    var p = ''
    var Comfort = [];
    var Seats = [];
    var Safety = [];
    var Sound = [];
    var Windows = [];
    var Other = [];
    var Specials = [];
    var New = [];
    for (i = 0; i < result.length; i++) {
        var str = result[i];
        if (str.substring(0, 7) == 'Comfort') {
            Comfort.push(str);
        } else if (str.substring(0, 5) == 'Other') {
            Other.push(str);
        } else if (str.substring(0, 6) == 'Safety') {
            Safety.push(str);
        } else if (str.substring(0, 5) == 'Seats') {
            Seats.push(str);
        } else if (str.substring(0, 5) == 'Sound') {
            Sound.push(str);
        } else if (str.substring(0, 7) == 'Windows') {
            Windows.push(str);
        } else if (str.substring(0, 8) == 'Specials') {
            Specials.push(str);
        } else if (str.substring(0, 3) == 'New') {
            New.push(str);
        }

    }

    p += '<fieldset class="formUploadCar"><legend class="Title2">Vehicle Features</legend>';

    p += '<strong>Comfort: </strong><label>';
    for (i = 0; i < Comfort.length; i++) {
        p += Comfort[i].substring(8);
        if (i != Comfort.length - 1) {
            p += ', ';
        }
    }
    p += '</label>';


    p += '<br><strong>New: </strong><label>';
    for (i = 0; i < New.length; i++) {
        p += New[i].substring(4)
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



    p += '<br><strong>Safety: </strong><label>';
    for (i = 0; i < Safety.length; i++) {
        p += Safety[i].substring(7)
        if (i != Safety.length - 1) {
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

    p += '<br><strong>Sound: </strong><label>';
    for (i = 0; i < Sound.length; i++) {
        ////console.log(Sound[i]);
        p += Sound[i].substring(13)
        if (i != Sound.length - 1) {
            p += ', ';
        }
    }
    p += '</label>';




    p += '<br><strong>Specials: </strong><label>';
    for (i = 0; i < Specials.length; i++) {
        p += Specials[i].substring(9)
        if (i != Specials.length - 1) {
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

    p += "<br><p style='padding-top:17px; padding-bottom:0;'><strong style='font-size: 1.17em; width:100px'>Description: </strong>" + selectedCarDiscription;

    p += '<div class="clear">&nbsp;</div> </fieldset>';

    var br = ""
    $('.Comfort').append(br + p);
    $('.Comfort label').each(function() {
        $(this).text($(this).text().trim());
        var len = $(this).text().length;

        if ($(this).text().charAt(len - 1) == ',') {
            $(this).text($(this).text().substring(0, len - 1));
        }
    });


}   