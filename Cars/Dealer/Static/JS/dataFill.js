var varType;
var varUrl;
var varData;
var varContentType;
var varDataType;
var varProcessData;
var obj;
var vehicleRresults = [];
var make = [];
var models = [];

//var MainURL = 'http://localhost:4203/CarService/DealerService.svc/'

var MainURL = 'http://unitedcarexchange.com/CarService/DealerService.svc/'

//var MainURL = 'http://cars.hugomirad.com/CarService/DealerService.svc/'

//Generic function to call AXMX/WCF  Service
function CallService() {
    
    //alert(MainURL + varUrl);
    $.support.cors = true;
    $.ajaxSetup({ cache: false });
    $.ajax({
        type: varType, //GET or POST or PUT or DELETE verb
        cache: false,
        async: false,
        url: MainURL + varUrl, // Location of the service
        data: varData, //Data sent to server
        contentType: "application/json; charset = utf-8", // content type sent to server
        dataType: "json", //Expected data format from server
        processdata: true, //True or False
        timeout: 100000,        
        success: function(msg) {//On Successfull service call
            ServiceSucceeded(msg);
        },
        error: function(msg) { ServiceFailed(msg); } // When Service call fails

    });
    $.ajaxSetup({ cache: true });
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + '' + result.statusText);
    //alert('Service call failed: ' + result.status + '' + result.statusText);
    //varType = null; varUrl = null; varData = null; varContentType = null; varDataType = null; varProcessData = null;
}


function ServiceSucceeded(result) {//When service call is sucessful
    var resultObject = null;
    ////console.log(result); 
    $.each(result, function(key, value) {
        var p = key.toString();
        ////console.log(p)
        eval(p)(value);
    })
}





///Get All Makes

function GetMakes() {
    varType = "GET";
    varUrl = "GetMakes";
    varData = '{}';
    CallService();
}


///Get All Models 
function GetModelsInfo() {

    varType = "GET";
    varUrl = "GetModelsInfo";
    varData = '{}';
    CallService();
}


///Get All Models by id
function GetModelsInfoByID(makeID) {
    showSpinner();

    varType = "GET";
    varUrl = "GetModelsInfoByID?MakeID=" + makeID + "";
    varData = '{}';
    CallService();
}


function DealerUpdateCarAdStatus(PostingID, AdStatusID, Count) {
    showSpinner();

    varType = "GET";
    varUrl = "DealerUpdateCarAdStatus?PostingID=" + PostingID + "&AdStatusID=" + AdStatusID + "&Count=" + Count + "";
    varData = '{}';
    CallService();

}

function FindDealerCarID(sDealerCarID, DealerCode) {
    showSpinner();

    varType = "GET";
    varUrl = "FindDealerCarID?sDealerCarID=" + sDealerCarID + "&DealerCode=" + DealerCode + "";
    varData = '{}';
    CallService();

}


function SavePictures(sCarId, pic0,
        pic1, pic2,
        pic3, pic4,
        pic5, pic6,
        pic7, pic8,
        pic9, pic10,
        pic11, pic12,
        pic13, pic14,
        pic15, pic16,
        pic17, pic18,
        pic19, pic20, UserID) {

    varType = "GET";
    varUrl = "SavePictures?sCarId=" + sCarId + "&pic0=" + pic0 +
        "&pic1=" + pic1 + "&pic2=" + pic2 + "&pic3=" + pic3 +
        "&pic4=" + pic4 + "&pic5=" + pic5 + "&pic6=" + pic6 +
        "&pic7=" + pic7 + "&pic8=" + pic8 + "&pic9=" + pic9 +
        "&pic10=" + pic10 +
        "&pic11=" + pic11 + "&pic12=" + pic12 + "&pic13=" + pic13 +
        "&pic14=" + pic14 + "&pic15=" + pic15 + "&pic16=" + pic16 +
        "&pic17=" + pic17 + "&pic18=" + pic18 + "&pic19=" + pic19 +
        "&pic20=" + pic20 + "&UserID=" + UserID + "";
    varData = '{}';
    //console.log(varUrl);
    
    CallService();





}

function GetCarMultiSitePostings(PostingID) {
    showSpinner();
    varType = "GET";
    varUrl = "GetDealerMultiSitePostings?sPostingID=" + PostingID + "";
    varData = '{}';
    CallService();

}


function GetDealerMultiSitePostingsResult(result) {
    //console.log(result.length);
    //$('.listingsURL').empty();
    //var m = ""
    
    if (result.length <= 0 || result == null || result == 'undefined' )  {
        $('#listingURL .scroll').hide();
        $('#listingURL h4').show();

    }else{
        $('#listingURL h4').hide();
    }   
    
    
    $('#listingURL').show();
    $('#listingURL .close').live('click', function() {
        $('#listingURL').hide();
    })
    
    hideSpinner();
}





// -----AJAX RETURN FUNCTIONS-----------------------------------------------------------------

function GetMakesResult(result) {

    $('#make').empty();
    ////console.log(result);
    make = result;
    if (make.length > 0) {
        var mm = '';
        mm += "<option value='0'>All makes</option>";
        for (i = 0; i < make.length; i++) {
            mm += "<option value=" + make[i]["_makeID"] + ">" + make[i]["_make"] + "</option>"
        }
        $('#make').empty().append(mm)//.transformSelect();
        /*
        $('ul.transformSelect ul').each(function() {
        if ($(this).children().length > 6) {
        $(this).height('160px').css({ 'overflow-y': 'scroll' });
        }
        });
        */
        GetModelsInfo();
    } else {
        $('#make').empty().attr('disabled', 'disabled');
    }

}


//  -------- Bind MOdel -------------------------------
function GetModelsInfoResult(result) {

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
                if (id == models[i]["_MakeID"]) {
                    mm += "<option value=" + models[i]["_MakeModelID"] + ">" + models[i]["_Model"] + "</option>"
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



    hideSpinner();
}

//  -------- Bind Years -------------------------------
function bindYears() {
    $('#year').empty();
    for (i = 2013; i > 1910; i--) {
        $('#year').append("<option value=" + i + ">" + i + "</option>")
    }
    $('#year').removeAttr('disabled')
}








// -----------------Search Results ------------



// GetDealerCars( carMakeid, CarModalId, YearID, PriceOrderby, 
// MarginRangeOrderby, NoofDayActive, AdStatus, CarActive, VehicleTypeTrim,
//  InventoryID, currentPage, pageSize)

function searchVehicle() {
    //alert('Ok');
    var carMakeid = $('#make option:selected').text();
    var CarModalId = $('#model option:selected').text();
    var YearID = $('#year option:selected').val();
    var PriceOrderby = $('#priceRange option:selected').val();
    var MarginRangeOrderby = $('#marginRange option:selected').val();
    var NoofDayActive = $('#numOfDays option:selected').val();
    var AdStatus = $('#status option:selected').val();
    var CarActive = '1';
    var VehicleTypeTrim = $('#vTrim').val();
    var InventoryID = "";
    var DealerID = $('#Header1_lblDealerCode').text();

    GetDealerCars(carMakeid, CarModalId, YearID, PriceOrderby, MarginRangeOrderby, NoofDayActive, AdStatus, CarActive, VehicleTypeTrim, InventoryID, DealerID);
}


//lblPublished, lblPrePublished, Withdrawn
/*
$('#lblPublished').click(function() {
alert('Ok')
});
$('#lblPrePublished').click(function() {
searchVehiclePrePublished();
});
$('#Withdrawn').click(function() {
searchVehicleWithdrawn();
});
*/



//showSpinner();
//hideSpinner();
/*
1	Active
2	Preliminary
3	Withdraw
4	Sold
5	Admin Cancel

*/

function searchAllVehicles() {

    showSpinner();
    $('#lblPublished').css('act');
    $('#lblPrePublished').css('');
    $('#Withdrawn').css('');
    //alert('Ok')
    var carMakeid = 'All makes';
    var CarModalId = 'All models';
    var YearID = '0';
    var PriceOrderby = 'ASC';
    var MarginRangeOrderby = 'ASC';
    var NoofDayActive = '400';
    var AdStatus = '0';
    var CarActive = '1';
    var VehicleTypeTrim = '';
    var InventoryID = "0";
    var DealerID = $('#Header1_lblDealerCode').text();
    GetDealerCars(carMakeid, CarModalId, YearID, PriceOrderby, MarginRangeOrderby, NoofDayActive, AdStatus, CarActive, VehicleTypeTrim, InventoryID, DealerID);
}

function searchVehiclePublished() {
    showSpinner();
    $('#lblPublished').css('act');
    $('#lblPrePublished').css('');
    $('#Withdrawn').css('');
    //alert('Ok')
    var carMakeid = 'All makes';
    var CarModalId = 'All models';
    var YearID = '0';
    var PriceOrderby = 'ASC';
    var MarginRangeOrderby = 'ASC';
    var NoofDayActive = '400';
    var AdStatus = '1';
    var CarActive = '1';
    var VehicleTypeTrim = '';
    var InventoryID = "0";
    var DealerID = $('#Header1_lblDealerCode').text();
    GetDealerCars(carMakeid, CarModalId, YearID, PriceOrderby, MarginRangeOrderby, NoofDayActive, AdStatus, CarActive, VehicleTypeTrim, InventoryID, DealerID);
}
function searchVehiclePrePublished() {
    showSpinner();
    $('#lblPublished').css('');
    $('#lblPrePublished').css('act');
    $('#Withdrawn').css('');

    var carMakeid = 'All makes';
    var CarModalId = 'All models';
    var YearID = '0';
    var PriceOrderby = 'ASC';
    var MarginRangeOrderby = 'ASC';
    var NoofDayActive = '400';
    var AdStatus = '6';
    var CarActive = '1';
    var VehicleTypeTrim = '';
    var InventoryID = "0";
    var DealerID = $('#Header1_lblDealerCode').text();
    GetDealerCars(carMakeid, CarModalId, YearID, PriceOrderby, MarginRangeOrderby, NoofDayActive, AdStatus, CarActive, VehicleTypeTrim, InventoryID, DealerID);
}
function searchVehicleWithdrawn() {
    showSpinner();
    $('#lblPublished').css('');
    $('#lblPrePublished').css('');
    $('#Withdrawn').css('act');

    var carMakeid = 'All makes';
    var CarModalId = 'All models';
    var YearID = '0';
    var PriceOrderby = 'ASC';
    var MarginRangeOrderby = 'ASC';
    var NoofDayActive = '400';
    var AdStatus = '3';
    var CarActive = '1';
    var VehicleTypeTrim = '';
    var InventoryID = "0";
    var DealerID = $('#Header1_lblDealerCode').text();
    GetDealerCars(carMakeid, CarModalId, YearID, PriceOrderby, MarginRangeOrderby, NoofDayActive, AdStatus, CarActive, VehicleTypeTrim, InventoryID, DealerID);
}

function searchVehicleSold() {
    showSpinner();
    $('#lblPublished').css('');
    $('#lblPrePublished').css('');
    $('#Withdrawn').css('act');

    var carMakeid = 'All makes';
    var CarModalId = 'All models';
    var YearID = '0';
    var PriceOrderby = 'ASC';
    var MarginRangeOrderby = 'ASC';
    var NoofDayActive = '400';
    var AdStatus = '4';
    var CarActive = '1';
    var VehicleTypeTrim = '';
    var InventoryID = "0";
    var DealerID = $('#Header1_lblDealerCode').text();
    GetDealerCars(carMakeid, CarModalId, YearID, PriceOrderby, MarginRangeOrderby, NoofDayActive, AdStatus, CarActive, VehicleTypeTrim, InventoryID, DealerID);
}

// -----------Search BY INVENTORY ID---------------
function inventoryIdSearch() {

    if (page == 0) {
        $('.links1 li a').each(function() { $(this).removeClass('act') })
        $('.links2 li a').each(function() { $(this).removeClass('act') })

        var InventoryID = $.trim($('#txtMainSearch').val());

        if (InventoryID.length <= 0 && InventoryID == '') {
            alert('Enter keywords to search');
        } else {
            showSpinner();
            var carMakeid = 'All makes';
            var CarModalId = 'All models';
            var YearID = '0';
            var PriceOrderby = 'ASC';
            var MarginRangeOrderby = 'ASC';
            var NoofDayActive = '400';
            var AdStatus = '0';
            var CarActive = '0';
            var VehicleTypeTrim = '';
            var InventoryID = InventoryID;
            var DealerID = $('#Header1_lblDealerCode').text();
            GetDealerCars(carMakeid, CarModalId, YearID, PriceOrderby, MarginRangeOrderby, NoofDayActive, AdStatus, CarActive, VehicleTypeTrim, InventoryID, DealerID);
        }
    } else {
        var InventoryID = $.trim($('#txtMainSearch').val());

        if (InventoryID.length <= 0 && InventoryID == '') {
            alert('Enter keywords to search');
        } else {

            var p1 = 'inventoryIdSearch'
            window.location.href = "Home.aspx?C=" + p1 + "&Q=" + InventoryID + "";
        }
    }

    // --  On success we ha to call GetDealersSearchCarsNewResult(value) as return for binding grid ------
}



// Archive Admin Cancel
function searchVehicleAdminCancel() {
    showSpinner();
    $('#lblPublished').css('');
    $('#lblPrePublished').css('');
    $('#Withdrawn').css('act');

    var carMakeid = 'All makes';
    var CarModalId = 'All models';
    var YearID = '0';
    var PriceOrderby = 'ASC';
    var MarginRangeOrderby = 'ASC';
    var NoofDayActive = '400';
    var AdStatus = '5';
    var CarActive = '1';
    var VehicleTypeTrim = '';
    var InventoryID = "0";
    var DealerID = $('#Header1_lblDealerCode').text();
    GetDealerCars(carMakeid, CarModalId, YearID, PriceOrderby, MarginRangeOrderby, NoofDayActive, AdStatus, CarActive, VehicleTypeTrim, InventoryID, DealerID);
}




// Archive Results
function searchVehicleArchive() {
    showSpinner();
    $('#lblPublished').css('');
    $('#lblPrePublished').css('');
    $('#Withdrawn').css('act');

    var carMakeid = 'All makes';
    var CarModalId = 'All models';
    var YearID = '0';
    var PriceOrderby = 'ASC';
    var MarginRangeOrderby = 'ASC';
    var NoofDayActive = '400';
    var AdStatus = '7';
    var CarActive = '1';
    var VehicleTypeTrim = '';
    var InventoryID = "0";
    var DealerID = $('#Header1_lblDealerCode').text();
    GetDealerCars(carMakeid, CarModalId, YearID, PriceOrderby, MarginRangeOrderby, NoofDayActive, AdStatus, CarActive, VehicleTypeTrim, InventoryID, DealerID);
}




//---------- DOC READY ---------------------


$(function() {
    $('.links1 li a').click(function() {
        var ind = $(this).parent().index();
        $('.links1 a').each(function() {
            $(this).removeClass('act')
        });
        $('.links2 a').each(function() {
            $(this).removeClass('act')
        });
        $('.links1 li:eq(' + ind + ') a').addClass('act');
    });


    $('.links2 li a').click(function() {
        var ind = $(this).parent().index();
        $('.links1 a').each(function() {
            $(this).removeClass('act')
        });
        $('.links2 a').each(function() {
            $(this).removeClass('act')
        });
        $('.links2 li:eq(' + ind + ') a').addClass('act');
    });

})



function showSpinner() {
    $('#spinner').show();
}
function hideSpinner() {
    $('#spinner').hide();
}

/* Date */

function getDate(dat) {
    var fullDate = '';
    if (dat) {
        var d = new Date(parseInt(dat.slice(6, -2)));
        fullDate = '' + (1 + d.getMonth()) + '/' + d.getDate() + '/' + d.getFullYear();
    }
    return fullDate;
}

function getDate2(dat) {
    var fullDate = '';
    if (dat) {
        var d = new Date(dat);
        fullDate = '' + (1 + d.getMonth()) + '/' + d.getDate() + '/' + d.getFullYear() + ' - ' + d.getHours() + ':' + d.getMinutes();
    }
    return fullDate;
}


function FindDealerCarIDResult(result) {
    ////console.log(result[0]);
    productionPage(result[0]);
}