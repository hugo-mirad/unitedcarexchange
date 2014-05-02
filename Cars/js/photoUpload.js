var det;

var siteURL = 'http://images.mobicarz.com/';
//var siteURL = 'http://localhost:44251/Cars/';

var siteURLStock = 'http://images.mobicarz.com/';

var imgCount = 0;  
function productionPage(carDet) {
    //console.log(carDet[0]);
    var carDetails = carDet[0];
    //console.log(carDetails);
    // $('.stock').hide();
    if (carDetails) {
        
        var year = carDetails.YearOfMake;
        var make = carDetails.Make;
        var model = carDetails.Model;
         make = make.replace(' ', '-');
         make = make.replace(' ', '-');
            model = model.replace(' ', '-');
            model = model.replace(' ', '-');
            model = model.replace(' ', '-');
            model = model.replace('/', '@');
            model = model.replace('/', '@');
            model = model.replace('&','@');
            model = model.replace('&','@');
        var Zip = carDetails.Zip;
        var carID = carDetails.Carid;
        
        var img1 = '';




        CARID = carDetails.Carid;
        

        if (carDetails.PICID0 != 'Emp' && carDetails.PICID0 != 0 && carDetails.PICID0 != '0') {
            PICID0 = carDetails.PICID0;
        } else {
            PICID0 = '';
        }


        //  ------------------------------------------------------------------------------------------------------

        for (i = 1; i <= parseInt($('#MaxPhotos').val()); i++) {
            if (carDetails['PIC' + i] && carDetails['PICLOC' + i] && carDetails['PIC' + i] != 'Emp' && carDetails['PICLOC' + i] != 'Emp') {
                var path = "'" + carDetails['PICLOC' + i] + "/" + carDetails['PIC' + i] + "'";
                var loaction = carDetails['PICLOC' + i];
                var img = carDetails['PIC' + i]
                path = siteURL + loaction + img;
                img1 += '<li><div>';
                img1 += '<img src="' + path + '" picId = ' + carDetails["PICID" + i] + '  class="thumb">';
                img1 += '<div class="imgDrag" >&nbsp;</div>'
                img1 += '<div class="imgDelete" >&nbsp;</div>'
                img1 += '</div></li>';

            } else {
                imgCount++;
            }
        }

    //console.log(img1)
        if (imgCount == parseInt($('#MaxPhotos').val())) {
            var path2 = "" + siteURL + "'images/stockMakes/" + carDetails.Make + ".jpg'";
            
            var carMake = carDetails.Make;
            var carModel = carDetails.Model;

            carMake = carMake.replace(' ', '-');
            carModel = carModel.replace(' ', '-');
            carModel = carModel.replace(' ', '-');
            carModel = carModel.replace(' ', '-');
            carModel = carModel.replace('/', '@');
            carModel = carModel.replace('/', '@');
            carModel = carModel.replace('&', '@');
            carModel = carModel.replace('&', '@');
            var MakeModel = carMake + "_" + carModel;
            MakeModel = MakeModel.replace(' ', '-');
            MakeModel = MakeModel.replace('/', '@');
            MakeModel = MakeModel.replace(' ', '-');
            MakeModel = MakeModel.replace('/', '@');
            path2 = "" + siteURLStock + "images/MakeModelThumbs/" + MakeModel + ".jpg";
            var path1 = "" + siteURLStock + "'images/no-image.jpg'";

            img1 += "<li><img  src=" + path2 + " class='thumb' /><div class='stock'>Stock Photo</div></li>";
            $('div.thumbsUpload-holder').width(($('.box1').width()) - 100);
            $('div.thumbsUpload-holder ul').empty().append(img1);
            $('.stock').show();

        } else {
            //console.log('Nostock')
            $('div.thumbsUpload-holder').width(($('.box1').width()) - 100);
            $('div.thumbsUpload-holder ul').empty().append(img1);
            $('.stock').hide();
            imgDrag();
        }

        // imageOrder Button Enable If images are more than 1
        $('#imageOrder, #imagesSave').attr('disabled', 'disabled');
        $('#addPhotosNow').hide();
        if ($('.thumbsUpload li').length < 1) {
            $('#imageOrder, #imagesSave').attr('disabled', 'disabled');
            $('#addPhotosNow').hide();
            
        } else {
            $('#imageOrder').removeAttr('disabled');
            $('#addPhotosNow').show();
        }

        if ($('.thumbsUpload li').length = 1) {
            $('#addPhotosNow').hide();
            $('#btnContinue').val('Continue >');
        }
        

        //$('.headding1 span').empty().append(CarID1[1]);
        //$('#spinner').hide();
       // $('#queue, #file_upload').hide();        
       
    }

   // console.log('imgCount:' + imgCount + ' MaxPhotos:' + parseInt($('#MaxPhotos').val()));
    
    
    /*
    if (imgCount == parseInt($('#MaxPhotos').val()) || imgCount == undefined || !imgCount) {
    imgCount = parseInt($('#MaxPhotos').val());
    } else {
    imgCount = parseInt($('#MaxPhotos').val()) - imgCount;
    }
    */
   

   

    $('#hdnUploadedImages').val(parseInt($('#MaxPhotos').val()) - imgCount)


    //console.log($.browser.name); // || $.browser.name == 'Firefox' || $.browser.name == 'firefox'

    if (($.browser.name == 'safari' || $.browser.name == 'Safari' ) && imgCount > 0) {
            //console.log('safari');
         // Upload Images HTML 
            
            
            var links = '<link href="_scripts/uploadHTML5/uploadifive.css" rel="stylesheet" type="text/css" />'
                        + '<script src="_scripts/uploadHTML5/jquery.uploadifive.min.js" type="text/javascript"></script>';
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
                //'simUploadLimit': 2,
                'multi': true,
                'width': 120,
                'onError': function (a, b, c, d) {
                    if (d.status == 404)
                        alert("Could not find upload script. Use a path relative to: " + "<?= getcwd() ?>");
                    else if (d.type === "HTTP")
                        alert("error " + d.type + ": " + d.status);
                    else if (d.type === "File Size")
                        alert(c.name + " " + d.type + " Limit: " + Math.round(d.info / (1024 * 1024)) + "MB");
                    else
                        alert("error " + d.type + ": " + d.text);
                },
                'onQueueComplete': function (event, data) {
                    location.reload();
                }
            });
        } else if (($.browser.name != 'safari' && $.browser.name != 'Safari') && imgCount > 0) {
            // console.log('Not safari');
        // Upload Images Flash

                //console.log($.browser.name + ',  imgCount = ' + imgCount);

        var links = '<link href="_scripts/uploadify.css" rel="stylesheet" type="text/css" />'
                        + '<script type="text/javascript" src="_scripts/swfobject.js"></script>'
                        + '<script type="text/javascript" src="_scripts/jquery.uploadify.js"></script>';

            //console.log(links);
            
            $('head').append(links);            
            //$('#queue, #file_upload').hide();
            $('#fuFiles').uploadify({
                'swf': '_scripts/uploadify.swf',
                'uploader': 'FileUploads.aspx?make=' + make + '*' + model + '*' + year + '*' + carID + '',
                'scriptData': {
                    'RequireUploadifySessionSync': true,
                    'SecurityToken': UploadifyAuthCookie,
                    'SessionId': UploadifySessionId
                },
                'formData': {
                    'KeyA': 'AValue',
                    'KeyB': 1,
                    'RequireUploadifySessionSync': true,
                    'SecurityToken': UploadifyAuthCookie,
                    'SessionId': UploadifySessionId
                }, // If some static data
                'auto': 'true',
                //'cancelImg': 'scripts/cancel.png',
                'fileTypeDesc': 'Image Files',
                'fileTypeExts': '*.gif; *.jpg; *.png',
                'multi': 'true',
                'buttonCursor': 'hand',
                'buttonText': 'Upload Photos',
                'fileSizeLimit': '4MB',
                'uploadLimit': imgCount,
                //'queueSizeLimit': 1,
                'onError': function (a, b, c, d) {
                    if (d.status == 404)
                        alert("Could not find upload script. Use a path relative to: " + "<?= getcwd() ?>");
                    else if (d.type === "HTTP")
                        alert("error " + d.type + ": " + d.status);
                    else if (d.type === "File Size")
                        alert(c.name + " " + d.type + " Limit: " + Math.round(d.info / (1024 * 1024)) + "MB");
                    else
                        alert("error " + d.type + ": " + d.text);
                },
                'onQueueComplete': function (event, data) {
                    //$('#status-message').text(data.filesUploaded + ' files uploaded, ' + data.errors + ' errors.');
                    //$('.showPicBox').html("<p>Hello Again</p>");
                    //FindDealerCarID(CarID1[1]);
                    window.location = window.location.pathname;
                }
            });
            
            $('.uploadify-button, .uploadify').removeAttr('style');
        }




}


function deleteImage() {
    $('#imagesSave').attr('disabled', 'disabled');
    if ($('.thumbsUpload li').length < 1) {
        $(' #imagesSave').attr('disabled', 'disabled');
    } else {
        $('#imagesSave').removeAttr('disabled');
    }
}


function imgDrag() {
   
    $("ul.thumbsUpload").dragsort({
        dragSelector: "div.imgDrag",
        dragBetween: true,
        dragEnd: saveOrder,
        placeHolderTemplate: "<li class='placeHolder'><div></div></li>"
    });
    
    // console.log('drag');

    $('#imageOrder').attr('disabled', 'disabled');
    $('#addPhotosNow').hide();
    if ($('.thumbsUpload li').length < 1) {
        $('#imageOrder').attr('disabled', 'disabled');
        $('#addPhotosNow').hide();
    } else {
    $('#imageOrder').removeAttr('disabled');
    $('#addPhotosNow').show();
    }


    // thumbsUpload img Hover
    if ($('.archiveBlock ul').children().length > 0) {
        $('.archiveBlock').show();
    } else {
        $('.archiveBlock').hide();
    }
    $('.thumbsUpload li').hover(function () {
        //console.log('Hover')
        $(this).children().children('.imgDrag').fadeIn();
        $(this).children().children('.imgDelete').fadeIn();
    }, function () {
        $(this).children().children('.imgDrag').fadeOut();
        $(this).children().children('.imgDelete').fadeOut();
    });


    $('.thumbsUpload li .imgDelete').click(function(e) {
        deleteImage();
        e.preventDefault();

        $(this).parent().parent().remove();
        if ($('.thumbsUpload li ').length <= 0) {
            $('.thumbsUpload').append("<h4 style='color:#ff9900; text-align:center; font-size:18px; font-weifgt:normal; margin-top:100px; display:block; width:100%;'>No images available</h4>");
            $('#btnSave').hide();
        }

    });
}

function saveOrder() {
    //console.log('SaveOrder')
    $('#imagesSave').removeAttr('disabled')
    var data = $("#list1 li").map(function() { return $(this).children().html(); }).get();
    $("input[name=list1SortOrder]").val(data.join("|"));
};

$(function() {
    // Images Order  

    //var pic0 = pic1 = pic2 = pic3 = pic4 = pic5 = pic6 = pic7 = pic8 = pic9 = pic10 = pic11 = pic12 = pic13 = pic14 = pic15 = pic16 = pic17 = pic18 = pic19 = pic20 = 0;
/*
$('#imagesSave, #imagesSave').click(function() {
        
        console.log('imageOrder Click')
        //showSpinner();
        var dum = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];




        for (i = 0; i < $('.thumbsUpload li').length; i++) {
            dum[i] = $('.thumbsUpload li:eq(' + i + ') img.thumb').attr('picid');
        }
         console.log(dum)
        $('#hdnCarID').empty().val(CARID);
        //$('#hdnYear').empty().val($('#hdnYear').val());
        //$('#hdnMake').empty().val($('#hdnMake').val());
        //$('#hdnModel').empty().val($('#hdnModel').val());
        $('#hdnPic0').empty().val(PICID0);
        $('#hdnPic1').empty().val(dum[0]);
        $('#hdnPic2').empty().val(dum[1]);
        $('#hdnPic3').empty().val(dum[2]);
        $('#hdnPic4').empty().val(dum[3]);
        $('#hdnPic5').empty().val(dum[4]);
        $('#hdnPic6').empty().val(dum[5]);
        $('#hdnPic7').empty().val(dum[6]);
        $('#hdnPic8').empty().val(dum[7]);
        $('#hdnPic9').empty().val(dum[8]);
        $('#hdnPic10').empty().val(dum[9]);
        $('#hdnPic11').empty().val(dum[10]);
        $('#hdnPic12').empty().val(dum[11]);
        $('#hdnPic13').empty().val(dum[12]);
        $('#hdnPic14').empty().val(dum[13]);
        $('#hdnPic15').empty().val(dum[14]);
        $('#hdnPic16').empty().val(dum[15]);
        $('#hdnPic17').empty().val(dum[16]);
        $('#hdnPic18').empty().val(dum[17]);
        $('#hdnPic19').empty().val(dum[18]);
        $('#hdnPic20').empty().val(dum[19]);
        
        
      
    });


*/
   


})

function setImagesOrder(){
     // console.log('imageOrder Click')
        //showSpinner();
        var dum = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];




        for (i = 0; i < $('.thumbsUpload li').length; i++) {
            dum[i] = $('.thumbsUpload li:eq(' + i + ') img.thumb').attr('picid');
        }
        // console.log(dum)
        $('#hdnCarID').val(CARID);
        //$('#hdnYear').empty().val($('#hdnYear').val());
        //$('#hdnMake').empty().val($('#hdnMake').val());
        //$('#hdnModel').empty().val($('#hdnModel').val());
        $('#hdnPic0').val(PICID0);
        $('#hdnPic1').val(dum[0]);
        $('#hdnPic2').val(dum[1]);
        $('#hdnPic3').val(dum[2]);
        $('#hdnPic4').val(dum[3]);
        $('#hdnPic5').val(dum[4]);
        $('#hdnPic6').val(dum[5]);
        $('#hdnPic7').val(dum[6]);
        $('#hdnPic8').val(dum[7]);
        $('#hdnPic9').val(dum[8]);
        $('#hdnPic10').val(dum[9]);
        $('#hdnPic11').val(dum[10]);
        $('#hdnPic12').val(dum[11]);
        $('#hdnPic13').val(dum[12]);
        $('#hdnPic14').val(dum[13]);
        $('#hdnPic15').val(dum[14]);
        $('#hdnPic16').val(dum[15]);
        $('#hdnPic17').val(dum[16]);
        $('#hdnPic18').val(dum[17]);
        $('#hdnPic19').val(dum[18]);
        $('#hdnPic20').val(dum[19]);    
        
      
   
    
    return;
}


function SavePicturesResult(result) {
    hideSpinner();
    alert('Images order updated successfully..!');
}