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





    'use strict';
    // Change this to the location of your server-side upload handler:
    //var url = 'FileUploads.aspx?make=' + make + '*' + model + '*' + year + '*' + carID;
    var url = 'Handler.ashx?make=' + make + '*' + model + '*' + year + '*' + carID;

    //console.log(imgCount);
    var stat = false;
   
    if (imgCount > 0) {

        if ($.browser.name == 'safari' || $.browser.name == 'Safari') {
            stat = true;
            imgCount = 1;
        }

        $('.newFileUploadControler2').show();
        $('#fileupload').fileupload({
            url: url,
            dataType: 'json',
            maxFileSize: 4 * 1024,
            maxNumberOfFiles: imgCount,
            singleFileUploads: stat,
            forceIframeTransport: true,
            locale: {
                'File is too big': 'File is too big, Max allowed file size 4MB ',
                'Filetype not allowed': 'Filetype not allowed',
                'Max number exceeded': 'Max number exceeded, you can upload only ' + imgCount
            },
            // Accept only image file types:           
            acceptFileTypes: /(\.|\/)(gif|jpe?g|png)$/i,
            done: function (e, data) {
                /*
                $.each(data.result.files, function (index, file) {
                    $('<p/>').text(file.name).appendTo('#files');
                });
                */
                window.location.href = window.location.href;

            },
            progressall: function (e, data) {
                var progress = parseInt(data.loaded / data.total * 100, 10);
                $('#progress2 .progress-bar').css(
                    'width',
                    progress + '%'
                );
            }
        }).bind('fileuploadstart', function (e) {
            $('#spinner').show();
        }).bind('fileuploadadd', function (e, data) {
            var fileCount = data.files.length;
            if (fileCount > imgCount) {
                alert("Please select and upload one photo at a time");
                return false;
            }
        }).prop('disabled', !$.support.fileInput)
            .parent().addClass($.support.fileInput ? undefined : 'disabled');




            
    } else {
        $('.newFileUploadControler2').hide();
    }
    


    $('#spinner').hide();

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