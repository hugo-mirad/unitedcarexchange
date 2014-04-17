/*!
 * Auther      : Jyothirmayudu.CH
 * Mail        : ch.jmayudu@gmail.com
 * Created on  : 14 Jan 2012
 * Discription : JS for for Search Results Generation
 */
 
 
 
 


        
 
 // START function updateCharCount 
 function updateCharCount(textArea,displayField,displaySentence) {
	// Only proceed if the parameters are valid
	if(null != textArea && null != displayField && null != displaySentence) {
	    // Determine the count
		var count = 1000; // Max length
		count -= textArea.value.length; // Text length
		// Update the count
	    document.getElementById(displayField).innerHTML = count; // Update the number
		// Update sentence color
		if(count > 20) {
			document.getElementById(displaySentence).style.color = "#808080";
            document.getElementById(displaySentence).style.fontWeight = "normal";
		} else if(count > 5) {
			document.getElementById(displaySentence).style.color = "#C24747";
            document.getElementById(displaySentence).style.fontWeight = "normal";
		} else if(count > 0) {
			document.getElementById(displaySentence).style.color = "#FF0000";
            document.getElementById(displaySentence).style.fontWeight = "normal";
		} else {
		    document.getElementById(displaySentence).style.color = "#FF0000";
            document.getElementById(displaySentence).style.fontWeight = "bold";
            textArea.value = textArea.value.substr(0,999);
		} // END if/else
	} // END if
	return false;
} // END function updateCharCount
 
$(function() {
    // Images Preload
	//$(".image-loading ").preloader({ imagedelay:300 });
		
		
  $('#yourZip, #form-1-submit, #within').attr('disabled',true);
  
    $('input[type=text], textarea').bind("cut copy paste",function(e) {
      e.preventDefault();
  });
  
   $('#resultsPerPage').change(function(){       
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
   
    $('.rightArrow').click(function(){
        //alert('maxPages: '+maxPages);
        $('#PaginationBlock, #botNav1').hide();
        if(maxPages == 1){
            $('.leftArrow div').removeClass('leftAct');
            $('.leftArrow div').addClass('leftDis');
            $('.rightArrow div').removeClass('rightAct');
            $('.rightArrow div').addClass('rightDis');
        }else if(page<maxPages){
            page++;           
            $('.leftArrow div').removeClass('leftDis');
            $('.leftArrow div').addClass('leftAct');
            if( page >= maxPages){
                $('.rightArrow div').removeClass('rightAct');
                $('.rightArrow div').addClass('rightDis');  
                             
            } 
            //showSpinner();  
            //PageResultsCount = parseInt($('#resultsPerPage option:selected').val());
            //sFilterType = parseInt($('#filterSortBy option:selected').val());  
            
            PageResultsCount = 25;
            sFilterType = 1;  
            $('.searchResultsHolder').hide();
            GetPageData(PageResultsCount, page) ;  
            // alert('PageResultsCount: '+PageResultsCount);
                              
//            if(sFilterType != 0 && sFilterType != '0'){
//                SortData(sFilterType, PageResultsCount);
//            }
                  
        }else if(maxPages == 0){
            $('.leftArrow div').removeClass('leftAct');
            $('.leftArrow div').addClass('leftDis');
            
            $('.rightArrow div').removeClass('rightAct');
            $('.rightArrow div').addClass('rightDis');
            
        }else{
           $('.rightArrow div').removeClass('rightAct');
           $('.rightArrow div').addClass('rightDis'); 
           
           $('.leftArrow div').removeClass('leftDis');
           $('.leftArrow div').addClass('leftAct');
           
            //PageResultsCount = parseInt($('#resultsPerPage option:selected').val());
            PageResultsCount = 25;
            
           
                      
        }
    });
    
    $('.leftArrow').click(function(){   
        $('#PaginationBlock, #botNav1').hide();
        if(maxPages == 1){
            $('.leftArrow div').removeClass('leftAct');
            $('.leftArrow div').addClass('leftDis');
            $('.rightArrow div').removeClass('rightAct');
            $('.rightArrow div').addClass('rightDis');
        }else if(page>1){
            page--;                 
            $('.rightArrow div').removeClass('rightDis');
            $('.rightArrow div').addClass('rightAct');
            if( page == 1){
                $('.leftArrow div').removeClass('leftAct');
                $('.leftArrow div').addClass('leftDis');
            }
            //showSpinner(); 
            //PageResultsCount = parseInt($('#resultsPerPage option:selected').val());
            //sFilterType = parseInt($('#filterSortBy option:selected').val());  
            PageResultsCount = 25;
            sFilterType = 1;  
            GetPageDecrement(PageResultsCount, page) ; 
            $('.searchResultsHolder').hide();             
            
        }else if(maxPages <= 0){
            $('.leftArrow div').removeClass('leftAct');
            $('.leftArrow div').addClass('leftDis');
            
            $('.rightArrow div').removeClass('rightAct');
            $('.rightArrow div').addClass('rightDis');
            
        }else{
            $('.leftArrow div').removeClass('leftAct');
            $('.leftArrow div').addClass('leftDis');
            
            $('.rightArrow div').removeClass('rightDis');
            $('.rightArrow div').addClass('rightAct');
            
        }
    });
    
    
    
    
});


function NoOfResultsandPagecount(result){
     maxPages = result[0];
     totalTesults = result[1];
     PageResultsCount = 25;
     // 1-25 of 116
     
     var m = '';
     if(maxPages >1){
        m += startNum+'-'+endNum+' of '+totalTesults;
     }else if(maxPages == 1){
        m += startNum+'-'+totalTesults+' of '+totalTesults;
     }else if( maxPages == 0 && page == 1){
        m += '<strong>0</strong>';       
     }
     $('#totalResultsFound').empty();
     $('#totalResultsFound').append(m);
     
      arrowsAct();
}

 function  showSpinner(){
            $('#spinner').show();
        }
        function  hideSpinner(){
            $('#spinner').hide();
        } 
        

 // Make Dropdown
 function BindMakes(result){ 
            WithinZipBinding(); 
            make = result;         
		    if(make.length>0){
			    var mm = '';
			    mm += "<option value='0'>All makes</option>";
			    for(i=0;i<make.length;i++){				
				    mm += "<option value="+make[i]["MakeID"]+">"+make[i]["Make"]+"</option>" 	
			    }
			    $('#make').empty();
			    $('#make').append(mm);
		    }else{
		         $('#make').empty();
		    }			    
		   
 }
        
    // Models Dropdown 
    function ModelsBinding(result){
     
        models = result; 
        $('#make').removeAttr('disabled');                  
        //alert(models.length);
        var mm = "<option value='0'>All models</option>";
        $('#model').empty();
        $('#model').append(mm);
                    
        $('#make').bind('change keypress',function(){
            if(models.length > 0){
                $('#model').removeAttr('disabled'); 
                var id = $('#make option:selected').val();
                //alert(id);
                var mm = '';
                var count = 0;
                mm += "<option value='0'>All models</option>";
                for(i=0;i<models.length;i++){                    
                    if(id == models[i]["MakeID"]['#text']){
                        mm += "<option value="+models[i]["MakeModelID"]['#text']+">"+models[i]["Model"]['#text']+"</option>" ;
                        count ++;
                    }
                }
                $('#model').empty();
                if(count >0){                    
                    $('#model').append(mm);
                }else{
                    var mm = '';                    
                    mm += "<option value='0'>All models</option>";
                    $('#model').empty();
                    $('#model').append(mm);
                    $('#model').attr('disabled',true);
                    
                }
            }
	    }); 
	    
	    
	    
	    
	    
	    //GetSearchCriteria(); 
	    searchCri(); 
	    $('#yourZip, #form-1-submit, #within').removeAttr('disabled'); 
	       
    }
    

        
     // Within Dropdow1n 
    function WithinZipBinding(){   // function WithinZipBinding(withinZip){         
	   // alert(within);
	    if(within.length>0){
		    var mm = '';
		    //mm += "<option value='Select distance'>Select distance</option>";
		    for(i=0;i<within.length;i++){				
			    if(i<within.length-1){			
				    mm += "<option value="+(i+1)+">"+within[i]+" miles</option>" ;
			    }else{
				    mm += "<option value="+(i+1)+">"+within[i]+"</option>" ;
			    }	 	
		    }
		    $('#within').empty();
		    $('#within').append(mm);
        }
         $('#within option').each(function(){
            $(this).removeAttr('selected');
         });
         if(LoadingPage == 1){
            $('#within option[value='+3+']').attr('selected', 'selected');
         }
   }
   
   $('#within').bind('change keypress',function(){
        var id = $('#within option:selected').val();
        $('#within option').each(function(){
            $(this).removeAttr('selected');
         });
         $('#within option[value='+id+']').attr('selected', 'selected');
   });
   
   // Search Button Submit
   function search(){
        //alert('Click');
        
        var SelectedMake = $('#make option:selected').val();
        var SelectedModel = $('#model option:selected').val();
        var SelectedDistance = $('#within option:selected').val();
        var EnteredZip = $('#yourZip').val();
        
        if(SelectedMake == 'Select make'){
            alert('Select a make');
        }else if(SelectedModel == 'null'){
            alert('Select a model');
        }else if(SelectedDistance == 'Select distance'){
            alert('Select distance');
        }else if(EnteredZip == '' || EnteredZip == null){
            alert('Enter your ZIP');
        }else if( EnteredZip.length < 5 ){
            alert('Enter valid ZIP');
        }else{
        
        //CarsSearch(carMakeid, CarModalId, ZipCode, WithinZip)
            
        showSpinner();           
        ChekZip(EnteredZip);
           
           
           
            //alert('Make: '+SelectedMake+',  Model:'+SelectedModel+',  Within:'+SelectedDistance+',  ZIP:'+EnteredZip);
        }
   };
   
   // Search Button Submit
   function search2(){
        //alert('Click');
        
        var SelectedMake = $('#make option:selected').val();
        var SelectedModel = $('#model option:selected').val();
        var SelectedDistance = $('#within option:selected').val();
        var EnteredZip = $('#yourZip').val();
        
        if(SelectedMake == 'Select make'){
            alert('Select a make');
        }else if(SelectedModel == 'null'){
            alert('Select a model');
        }else if(SelectedDistance == 'Select distance'){
            alert('Select distance');
        }else if(EnteredZip == '' || EnteredZip == null){
            alert('Enter your ZIP');
        }else if( EnteredZip.length < 5 ){
            alert('Enter valid ZIP');
        }else{
        
        //CarsSearch(carMakeid, CarModalId, ZipCode, WithinZip)
            
        showSpinner();           
        ChekZip2(EnteredZip);        
           
           
           
            //alert('Make: '+SelectedMake+',  Model:'+SelectedModel+',  Within:'+SelectedDistance+',  ZIP:'+EnteredZip);
        }
   };
   
   
   
   // Search Results Display  
   function SearchResultsDisplay(){
       
       try
        {
        if (SearchResults!=undefined )
        {
                resultsLength = SearchResults.length;
		//alert(resultsLength);
        dummyArraySet = SearchResults;
		//$('#totalResultsFound').text(SearchResults.length);
		$('.searchResultsHolder').empty();
		 $('.searchResultsHolder').show();
		
		if(SearchResults.length>0){
			var res = '';
			//withinZipRange = $('#within  option:selected').text();
			
			
			
			$('.searchResultsHolder').empty();
			for(i=0;i<SearchResults.length;i++){	
			   
			   // $('#totalResultsFound').text(SearchResults.length+' Used Cars');
			    var m = '';
			    m+= "<ul></ul>";
			    $('.searchResultsHolder').append(m);
			    m = '';
			    var path = ''
			    var withinZIp1 = $('#within option:selected').val();
			    var zip1 = $('#yourZip').val();
			    var resPath = '"'+SearchResults[i]['Carid']['#text']+'","'+SearchResults[i]['Make']['#text']+'","'+SearchResults[i]['Model']['#text']+'","'+zip1+'","'+withinZIp1+'"';
			    var thumb1='';
			    if(SearchResults[i]['PIC0']['#text'] != 'Emp'){
			        path = SearchResults[i]['PICLOC0']['#text']+"/"+SearchResults[i]['PIC0']['#text'];
			        for(k=0;k<3;k++){
			            path = path.replace("\\", "/");
			        }
			        path = path.replace("//", "/");
			        thumb1 = "<img src='"+path+"' class='thumb' onclick='javascript:EncryptedCarID("+resPath+");' width='80' height='50' />";
			    }else{
			        //path = "images/stockMakes/"+SearchResults[i]['Make']['#text']+".jpg";
			        
			        var carMake = SearchResults[i]['Make']['#text'];			        
			        var carModel = SearchResults[i]['Model']['#text'];
			        carMake = carMake.replace(' ','-');
			        carModel = carModel.replace(' ','-');
			        if(carModel.indexOf('/')>0){
			            carModel='Other';
			        }
			        var MakeModel = carMake+"_"+carModel;
			        MakeModel = MakeModel.replace(' ','-');
			        path = "images/MakeModelThumbs/"+MakeModel+".jpg";
			        
			        thumb1 = "<img src='"+path+"' class='thumb' width='80' height='50' /><br><div class='stockPhoto1' >Stock Photo</div>";
			    
			        
			    }
			    
			    m+= "<li><a href='javascript:EncryptedCarID("+resPath+");'>"+thumb1+" <h4>"+SearchResults[i]['YearOfMake']['#text']+" "+SearchResults[i]['Make']['#text']+" "+SearchResults[i]['Model']['#text']+"</h4>";
			    
			    
			    
			     if(SearchResults[i]['Price']['#text'] != 'Emp' && SearchResults[i]['Price']['#text'] != '0' && SearchResults[i]['Price']['#text'] != 'Unspecified'){
			        m+= "<strong>Price: </strong><span class='price'>"+parseInt(SearchResults[i]['Price']['#text'])+"</span><br>";
			    }else{
			        m+= "<strong>Price: </strong><br>"
			    }
			    
			    if(SearchResults[i]['Mileage']['#text'] != 'Emp' && SearchResults[i]['Mileage']['#text'] != '0' && SearchResults[i]['Mileage']['#text'] != 'Unspecified'){
			        m+= "<strong>Mileage: </strong><span class='mileage'>"+parseInt(SearchResults[i]['Mileage']['#text'])+"</span><br>";
			    }else{
			        m+= "<strong>Mileage: </strong><br>"
			    }
			    
			    if(SearchResults[i]['ExteriorColor']['#text'] != 'Emp' && SearchResults[i]['ExteriorColor']['#text'] != '0' && SearchResults[i]['ExteriorColor']['#text'] != 'Unspecified'){
			        m+= "<strong>ExteriorColor: </strong>"+SearchResults[i]['ExteriorColor']['#text']+"<br>";
			    }else{
			        m+= "<strong>ExteriorColor: </strong><br>"
			    }
			    
			  	if(SearchResults[i]['City']['#text'] != 'Emp'){
                    var city = SearchResults[i]['City']['#text'];
                    city = $.trim(city);
                    m+= city+", ";
                }

                if(SearchResults[i]['State']['#text'] != 'Emp'){
                    m+= SearchResults[i]['State']['#text']
                }
			    
			    if(SearchResults[i]['Phone']['#text'] != 'Emp'){
                    m+= "<br>"+SearchResults[i]['Phone']['#text']
                }			   
			    
			    m+= "</a></li>"
			    
			    
			    
			 	
			   
			    $('.searchResultsHolder ul').append(m);
			}
			
			 $('.price').formatCurrency();
			 $('.mileage').formatCurrency({symbol: ' '});
			 		
		}
		
		//showSpinner();
        hideSpinner();
        
        }
        else 
        {
        $('#totalResultsFound').text('0');
		    $('#PaginationBlock').hide();
		    $('.searchResultsHolder').empty();
		    $('.searchResultsHolder').append("<h4 style='color:#FF9900; text-align:center; line-height:100px;'>No records found..!</h4>");
         hideSpinner();
        }     
        
        //arrowsAct();
        }
         catch (ex)
        { }
		
   }
   function searchCri(){
           //alert(SessionArray[0]+', '+SessionArray[1]+', '+SessionArray[3]+', '+SessionArray[2])
        
        // make1, Modal1, ZipCode1, WithinZipNew; 
        
        
            //WithinZipNew=WithinZipNew.split("#").join("");;

            //withinZipRange = SessionArray[3];
            $('#within option').each(function(){
                $(this).removeAttr('selected');
            });   
                      
            //$('#make option[text='+make1+']').attr('selected', 'selected'); 
            $('#make option').each(function(){                
                    $(this).removeAttr('selected');               
            })
            
            $('#make option').each(function(){
                if($(this).text()== make1){
                    $(this).attr('selected', 'selected'); 
                }
            });
            
            $('#model').removeAttr('disabled');           
            var id = $('#make option:selected').val();
            var mm = '';
            var count = 0;
            mm += "<option value='0'>All models</option>";
            for(i=0;i<models.length;i++){
                if(id == models[i]["MakeID"]['#text']){
                    mm += "<option value="+models[i]["MakeModelID"]['#text']+">"+models[i]["Model"]['#text']+"</option>" ;
                    count ++;
                }
            }
            $('#model').empty();
            if(count >0){                    
                $('#model').append(mm);
            }else{
                var mm = '';                    
                mm += "<option value='0'>All models</option>";
                $('#model').empty();
                $('#model').append(mm);
                $('#model').attr('disabled',true);

            }
            $('#model option').each(function(){                
                    $(this).removeAttr('selected');                
            }); 
            
            $('#model option').each(function(){
                if($(this).text()== Modal1){
                    $(this).attr('selected', 'selected');
                }
            });           
            
           
            $('#within option').each(function(){
                $(this).removeAttr('selected');
            });
            $('#within option[value='+WithinZipNew+']').attr('selected', 'selected');
            
            $('.mileage2').empty();
            var str = $('#within option[text='+WithinZipNew+']').text()
            var newStr = str.substring(0, str.length-6);
           // alert(newStr)
            $('.mileage2').text(newStr);
            
            if(ZipCode1.length >= 4 && ZipCode1 !=='' && ZipCode1 != null && ZipCode1 != undefined && LoadingPage != 3 ){
                $('#yourZip').val(ZipCode1);
            }else if(LoadingPage != 3){
                $('#yourZip').val('');
            }
            
            
       
        
   }
   
   // Search Results Display with FILTER  
   function SearchResultsDisplayFilter(SearchResultsArray){
        // Results   
         $('.searchResultsHolder').show();      
		withinZipRange = $('#within option:selected').text();
		//alert(withinZipRange);
		//hideSpinner();
		if (SearchResultsArray!=undefined && SearchResultsArray.length!=undefined && SearchResultsArray.length>0 ) {
		    resultsLength = SearchResultsArray.length;
		    //alert(resultsLength);
		    if(SearchResultsArray.length > 0 && SearchResultsArray[0] != null && SearchResultsArray[0] != '' && SearchResultsArray[0] != [] ){
		       // $('#totalResultsFound').text(SearchResultsArray.length);
		    }
		    $('.searchResultsHolder').empty();
		
		    if(SearchResultsArray.length > 0 && SearchResultsArray[0] != null && SearchResultsArray[0] != '' && SearchResultsArray[0] != []){
		    
		        
			    var res = '';
			    $('.searchResultsHolder').empty();			
			    
			    var m = '';
			    m+= "<ul></ul>";
			    var resCount = 1;		    
			    
			    $('.searchResultsHolder').append(m);
			    
			    for(i=0;i<SearchResultsArray.length;i++){
				   
			    m = '';
			    resCount ++;
			    if(resCount == 5){     
			        m += "<li><div  class='gAd1'></div></li>";
			        resCount = 1;		        
			    }
			   
			    var path = ''
			    var withinZIp1 = $('#within option:selected').val();
			    var zip1 = $('#yourZip').val();
			    var resPath = '"'+SearchResultsArray[i]['Carid']['#text']+'","'+SearchResultsArray[i]['Make']['#text']+'","'+SearchResultsArray[i]['Model']['#text']+'","'+zip1+'","'+withinZIp1+'"';
			    var thumb1='';
			    if(SearchResultsArray[i]['PIC0']['#text'] != 'Emp'){
			        path = SearchResultsArray[i]['PICLOC0']['#text']+"/"+SearchResultsArray[i]['PIC0']['#text'];
			        for(k=0;k<3;k++){
			            path = path.replace("\\", "/");
			        }
			        path = path.replace("//", "/");
			        thumb1 = "<img src='http://www.UnitedCarExchange.com/"+path+"'  />";
			    }else{
			        //path = "images/stockMakes/"+SearchResults[i]['Make']['#text']+".jpg";
			        
			        var carMake = SearchResultsArray[i]['Make']['#text'];			        
			        var carModel = SearchResultsArray[i]['Model']['#text'];
			        carMake = carMake.replace(' ','-');
			        carModel = carModel.replace(' ','-');
			        if(carModel.indexOf('/')>0){
			            carModel='Other';
			        }
			        var MakeModel = carMake+"_"+carModel;
			        MakeModel = MakeModel.replace(' ','-');
			        path = "images/MakeModelThumbs/"+MakeModel+".jpg";
			        
			        thumb1 = "<img src='http://www.UnitedCarExchange.com/"+path+"'  /><div class='stockPhoto1' >Stock Photo</div>";
			    
			        
			    }
			    
			    m+= "<li><a href='javascript:EncryptedCarID("+resPath+");'>"+thumb1+" <h4>"+SearchResultsArray[i]['YearOfMake']['#text']+" "+SearchResultsArray[i]['Make']['#text']+" "+SearchResultsArray[i]['Model']['#text']+"</h4>";
			    
			    
			    
			     if(SearchResultsArray[i]['Price']['#text'] != 'Emp' && SearchResultsArray[i]['Price']['#text'] != '0' && SearchResultsArray[i]['Price']['#text'] != 'Unspecified'){
			        m+= "<strong>Price: </strong><label class='price'>"+parseInt(SearchResultsArray[i]['Price']['#text'])+"</label><br>";
			    }else{
			        m+= "<strong>Price: </strong><br>"
			    }
			    
			    if(SearchResultsArray[i]['Mileage']['#text'] != 'Emp' && SearchResultsArray[i]['Mileage']['#text'] != '0' && SearchResultsArray[i]['Mileage']['#text'] != 'Unspecified'){
			        m+= "<strong>Mileage: </strong><label class='mileage'>"+parseInt(SearchResultsArray[i]['Mileage']['#text'])+"</label> mi<br>";
			    }else{
			        m+= "<strong>Mileage: </strong><br>"
			    }
			    
			    if(SearchResultsArray[i]['ExteriorColor']['#text'] != 'Emp' && SearchResultsArray[i]['ExteriorColor']['#text'] != '0' && SearchResultsArray[i]['ExteriorColor']['#text'] != 'Unspecified' && SearchResultsArray[i]['ExteriorColor']['#text'] != '' && SearchResultsArray[i]['ExteriorColor']['#text'] != ' ' && SearchResultsArray[i]['ExteriorColor']['#text'] != null && SearchResultsArray[i]['ExteriorColor']['#text'] != 'undefined' ){
			        m+= "<strong>ExteriorColor: </strong>"+SearchResultsArray[i]['ExteriorColor']['#text']+"<br>";
			    }else{
			        m+= "<strong>ExteriorColor: </strong><br>"
			    }
			    
			  	if(SearchResultsArray[i]['City']['#text'] != 'Emp'){
                    var city = SearchResultsArray[i]['City']['#text'];
                    city = $.trim(city);
                    m+= city+", ";
                }

                if(SearchResultsArray[i]['State']['#text'] != 'Emp'){
                    m+= SearchResultsArray[i]['State']['#text']
                }
                
                if(SearchResultsArray[i]['Zip']['#text'] != 'Emp'){
                    m+= " "+SearchResultsArray[i]['Zip']['#text']
                }
                
               
			    
			    if(SearchResultsArray[i]['Phone']['#text'] != 'Emp'){
			    
			        var phone= SearchResultsArray[i]['Phone']['#text'];
			        
                    m+= "<br><label class='phone'>"+phone[9]+""+phone[8]+""+phone[7]+"-"+phone[6]+""+phone[5]+""+phone[4]+"-"+phone[3]+""+phone[2]+""+phone[1]+""+phone[0]+"</label>";
                }			   
			    
			    m+= "</a><div class='clear' style='height:1px;'>&nbsp;</div></li>"	
			   
			    $('.searchResultsHolder ul').append(m);
			}
			
			 $('.price').formatCurrency();
			 $('.mileage').formatCurrency({symbol: ' '});
			 $('#PaginationBlock, #botNav1').show();
			 onTime();
			  //$('#totalResultsFound').text(SearchResultsArray.length+' Used Cars');
		    }else{
		        $('#totalResultsFound').text('0');		       
		        $('.searchResultsHolder').empty();
		        $('.searchResultsHolder').append("<h4 style='color:#FF9900; text-align:center; line-height:100px;'>No records found..!</h4>");
		        $('#PaginationBlock, #botNav1').hide();
		        
		        //alert('No records found..!');		    
		    }
		}else{		
		    $('#totalResultsFound').text('0');
		    $('#PaginationBlock, #botNav1').hide();
		    $('.searchResultsHolder').empty();
		    $('.searchResultsHolder').append("<h4 style='color:#FF9900; text-align:center; line-height:100px;'>No records found..!</h4>");
		    
		    //alert('No records found..!');			
		}
        hideSpinner();
        
        //onTime();
       
        /* $('#botAd iframe, #botAd table, #botAd img, #botAd td').width('642')
        $('#botAd iframe, #botAd table, #botAd img').width('642'); 
        $('#botAd td').width('209');  
        $('#botAd img').height('90');
        */   
   }
   
   function newSearch(){ 
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
        
        if(SelectedMake == 'Select make'){
            alert('Select a make');
        }else if(SelectedModel == 'null'){
            alert('Select a model');
        }else if(SelectedDistance == 'Select distance'){
            alert('Select distance');
        }else if(EnteredZip == '' || EnteredZip == null){
            alert('Enter your ZIP');
        }else if( EnteredZip.length < 5 ){
            alert('Enter valid ZIP');
        }else{
	        if($('.make1:visible').length > 0 && $('.make2:visible').length > 0 ){
	            if(id1!='Select model' && id1!='' && id1!=null && id2!='Select model' && id2!='' && id2!=null ){
    	           // if(id0 != id1 != id2){
    	                //GetCarsMultiSearch(array); makeA
    	                var searchArray1 = [];
    	                var make1 = $('#makeA option:selected').text();
    	                var make2 = $('#makeB option:selected').text();
    	                showSpinner();
    	                searchArray1.push(SelectedMake+','+SelectedModel+','+EnteredZip+','+SelectedDistance+','+'1'+','+'25'+','+'price');
    	                searchArray1.push(make1+','+id1+','+EnteredZip+','+SelectedDistance+','+'1'+','+'25'+','+'price');
    	                searchArray1.push(make2+','+id2+','+EnteredZip+','+SelectedDistance+','+'1'+','+'25'+','+'price');
    	                GetCarsMultiSearch(searchArray1);
    	                
    	            //}else{
    	            //    alert('Duplicate search criteria...')
    	           // }
	            }else{
	                alert('Select Make & Model');
	            }    	        
	        }else if($('.make1:visible').length <= 0 && $('.make2:visible').length > 0 ){              
	           if( id2!='Select model' && id2!='' && id2!=null ){
    	           // if(id0 != id2){
    	                var searchArray1 = [];    	                
    	                var make2 = $('#makeB option:selected').text();
    	                 showSpinner();
    	                searchArray1.push(SelectedMake+','+SelectedModel+','+EnteredZip+','+SelectedDistance+','+'1'+','+'25'+','+'price');    	                
    	                searchArray1.push(make2+','+id2+','+EnteredZip+','+SelectedDistance+','+'1'+','+'25'+','+'price');
    	                GetCarsMultiSearch(searchArray1);
    	               
    	           // }else{
    	            //    alert('Duplicate search criteria...')
    	           // }
	            }else{
	                alert('Select Make & Model');
	            }
	        }else if($('.make1:visible').length > 0 && $('.make2:visible').length <= 0 ){
	            if(id1!='Select model' && id1!='' && id1!=null){
    	           //if(id0 != id1){
    	                var searchArray1 = [];
    	                var make1 = $('#makeA option:selected').text();  
    	                showSpinner();	  	               
    	                searchArray1.push(SelectedMake+','+SelectedModel+','+EnteredZip+','+SelectedDistance+','+'1'+','+'25'+','+'price');
    	                searchArray1.push(make1+','+id1+','+EnteredZip+','+SelectedDistance+','+'1'+','+'25'+','+'price');   
    	                GetCarsMultiSearch(searchArray1); 
    	                                
    	           // }else{
    	           //     alert('Duplicate search criteria...')
    	           // }
	            }else{
	                alert('Select Make & Model');
	            }
	        }else if($('.make1:visible').length <= 0 && $('.make2:visible').length <= 0 ){
	            if(id0!='Select model' && id0!='' && id0!=null ){
	                showSpinner();	                
	                 CarsSearch(SelectedMake,SelectedModel,EnteredZip,SelectedDistance,'1','25','price');
	                 
	            }else{
    	            
	            }    	       
	        }else{
	            if(id0!='Select model' && id0!='' && id0!=null ){	
	                  showSpinner();                
	                 CarsSearch(SelectedMake,SelectedModel,EnteredZip,SelectedDistance,'1','25','price');
	                 
	            }else{
    	            
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
   
   function carDetailsDisplay(){
   
   try{
        if (carDetails!=undefined){	
            
            var m = '';
            m += carDetails['YearOfMake']['#text']+' '+carDetails['Make']['#text']+' '+carDetails['Model']['#text'];	

            if(carDetails['Price']['#text'] != 'Emp' && carDetails['Price']['#text'] != '0' && carDetails['Price']['#text'] != null && carDetails['Price']['#text'] != 'Unspecified'){
               m += " - <strong style='font-size:16px;' class='price'>"+carDetails['Price']['#text']+"</strong>";
            }

            $("h3.h2").empty().append(m);
            m = '';
            $('.price1').text(carDetails['Price']['#text']);
            $('.SellerType').text(carDetails['SellerType']['#text']);  //carDetails['SellerType']['#text']
            if(carDetails['SellerName']['#text'] != 'Emp'){
              $('.SellerName').text(carDetails['SellerName']['#text']); 
            }else{
	            $('.SellerName').text('');
            }


            var dum= carDetails['Phone']['#text'];
            var phone='';			
            if(dum != null && dum != undefined && dum != ''){
	            phone += dum[0]+''+dum[1]+''+dum[2]+'-'+dum[3]+''+dum[4]+''+dum[5]+'-'+dum[6]+''+dum[7]+''+dum[8]+''+dum[9];
            }else{
	            phone = '';
            }
            $('.phone1').empty().append(phone);

            if(carDetails['Email']['#text'] != '' && carDetails['Email']['#text'] != ' ' && carDetails['Email']['#text'] != '  ' && carDetails['Email']['#text'] != 'Emp' && carDetails['Email']['#text'] != null ){
	            $('.SellerEmail').text(carDetails['Email']['#text']);
            }else{
               $('.SellerEmail').css('display','none'); 
               $('.SellerEmail').prev('strong').css('display','none'); 
               $('.SellerEmail').prev().prev().remove(); 		   
            }
            			
            var dumArray = [];
            dumArray[0] = carDetails['Address1']['#text'];
            dumArray[1] = carDetails['City']['#text'];
            dumArray[2] = carDetails['State']['#text'];
            dumArray[3] = carDetails['Zip']['#text'];
            var address = ''
            var city = ''
            var state = ''
            var zip = ''

            if(dumArray[0] != 'Emp' && dumArray[0] != '' && dumArray[0] != ' ' && dumArray[0] != 'Unspecified' && dumArray[0] != 'Not Available' && dumArray[0] != undefined){
	            address = dumArray[0] ;
            }
            if(dumArray[1] != 'Emp' && dumArray[1] != '' && dumArray[1] != ' ' && dumArray[1] != 'Unspecified' && dumArray[1] != 'Not Available' && dumArray[1] != undefined){
	            city = dumArray[1] ;
            }
            if(dumArray[2] != 'Emp' && dumArray[2] != '' && dumArray[2] != ' ' && dumArray[2] != 'Unspecified' && dumArray[2] != 'Not Available' && dumArray[2] != undefined && dumArray[2] != 'UN'){
	            state = dumArray[2] ;
            }
            if(dumArray[3] != 'Emp' && dumArray[3] != '' && dumArray[3] != ' ' && dumArray[3] != 'Unspecified' && dumArray[3] != 'Not Available' && dumArray[3] != undefined){
	            zip = dumArray[3] ;
            }			
            city = city.toLowerCase();
            city.charAt(0).toUpperCase();
            address = address.toLowerCase();
            address.charAt(0).toUpperCase();


            if(address != '' && address != ' ' && address != '  ' && (city != '' || state != '')){
	            address = $.trim(address);
	            address+='';			    
            }else{
	            address = '';
            }

            if(city != '' && state != ''){
	            city = $.trim(city);
	            city+=', '
            }else {
	            city = '';
            }

            if(state != '' && state != 'UN'){
	            state+= ' ';
            }

            var ppp = '<br />'
            $('.SellerAddress').empty();
            $('.SellerAddress').append(city+''+state+''+zip+' '+ ppp);
            $('.SellerAddress2').append(address);

            $('.SellerAddress, .SellerAddress2').css('text-transform','capitalize');
            $('#yourZip').val(carDetails['Zip']['#text']);

            var det = '';

            det += "<table style='width:99%; margin:0' >  <tr>    <td style='vertical-align:top'><strong>Make: </strong> "+carDetails['Make']['#text']+"<br /><strong>Model: </strong> "+carDetails['Model']['#text']+"<br /><strong>Year: </strong> "+carDetails['YearOfMake']['#text']+"<br /><strong>Body Style: </strong> ";
            if(carDetails['Bodytype']['#text'] != 'Emp' && carDetails['Bodytype']['#text'] !='Unspecified'){
              det += carDetails['Bodytype']['#text'];  
            }
            det += "<br /><strong>Exterior Color: </strong>";
            if(carDetails['ExteriorColor']['#text'] != 'Emp' && carDetails['ExteriorColor']['#text'] != 'Unspecified'){
              det += carDetails['ExteriorColor']['#text'];  
            }
            det +="<br /><strong>Interior Color: </strong>";
            if(carDetails['InteriorColor']['#text'] != 'Emp' && carDetails['InteriorColor']['#text'] != 'Unspecified'){
              det += carDetails['InteriorColor']['#text'];  
            }

            // ConditionDescription, DriveTrain
            det += "<br /><strong>Doors: </strong>";
            if(carDetails['NumberOfDoors']['#text'] != 'Emp' && carDetails['NumberOfDoors']['#text'] !=  'Unspecified'){
              det += carDetails['NumberOfDoors']['#text'];  
            }
            det += "<br /><strong>Vehicle Condition: </strong>";
            if(carDetails['ConditionDescription']['#text'] != 'Emp' && carDetails['ConditionDescription']['#text'] != 'Unspecified'){
              det += carDetails['ConditionDescription']['#text'];  
            }			
            det +="<br /><strong>Price: </strong> <span class='price2'>";
            if(carDetails['Price']['#text'] != 'Emp' && carDetails['Price']['#text'] != 'Unspecified' && carDetails['Price']['#text'] != '0' && carDetails['Price']['#text'] != null ){
              det += carDetails['Price']['#text'];  
            }
            det += "</span><br /><strong>Mileage: </strong>"
            if(carDetails['Mileage']['#text'] != 'Emp' && carDetails['Mileage']['#text'] != 'Unspecified' && carDetails['Mileage']['#text'] != '0' && carDetails['Mileage']['#text'] != null ){
              det += "<span class='detMileage'>"+carDetails['Mileage']['#text']+"</span> ml";  
            }
            det += "<br /><strong>Fuel: </strong>"
            if(carDetails['Fueltype']['#text'] != 'Emp' && carDetails['Fueltype']['#text'] != 'Unspecified'){
              det += carDetails['Fueltype']['#text'];  
            }
            det +="<br /><strong>Engine: </strong>"
            if(carDetails['NumberOfCylinder']['#text'] != 'Emp' && carDetails['NumberOfCylinder']['#text'] != 'Unspecified'){
              det += carDetails['NumberOfCylinder']['#text'];  
            }
            det +="<br /><strong>Transmission: </strong>"
            if(carDetails['Transmission']['#text'] != 'Emp' && carDetails['Transmission']['#text'] != 'Unspecified'){
              det += carDetails['Transmission']['#text'];  
            }
            det += "<br /><strong>DriveTrain: </strong>";
            if(carDetails['DriveTrain']['#text'] != 'Emp' && carDetails['DriveTrain']['#text'] != 'Unspecified'){
              det += carDetails['DriveTrain']['#text'];  
            }
            det +="<br /><strong>VIN: </strong>"
            if(carDetails['VIN']['#text'] != 'Emp' && carDetails['VIN']['#text'] != 'Unspecified'){
              det += carDetails['VIN']['#text'];  
            }
            det +="<br /></td></tr></table><div class='clear'></div>"
            			


            $('.vehicalDisc').empty();
            $('.vehicalDisc').append(det);	

            var m = '';
            var Email = carDetails['Email']['#text'];


            m += "<br><p><strong>Description: </strong>";
            if(carDetails['Description']['#text'] != 'Emp' && carDetails['Description']['#text'] != undefined && carDetails['Description']['#text'] != null){
	            m += carDetails['Description']['#text']+"</p>";
            }else{
	            m += "</p>"; 
            }
            $('.SellerNotes').empty();
            $('.SellerNotes').append(m);
            CarID1 = carDetails['Carid']['#text']
            GetCarFeatures(CarID1);
            	


             $('.price, .price1, .price2').formatCurrency();
             $('.detMileage').formatCurrency({symbol: ' '});
              
        
            //--------- Images Displaying--------------------------------------------------------------------------
            var img1 = [];			 	
            var imgCount = 0;
           
            for(i=1;i<21;i++){
	            if(carDetails['PIC'+i]['#text'] != 'Emp' && carDetails['PICLOC'+i]['#text'] != 'Emp'){
		            var path = ""+carDetails['PICLOC'+i]['#text']+"/"+carDetails['PIC'+i]['#text']+"";  
		            for(k=0;k<5;k++){
			            path = path.replace("\\", "/");
		            }
                    path = path.replace("//", "/");  
                    url = 'http://UnitedCarExchange.com/'                      		           
                    var im = "<img  src='"+url+path+"' class='carImg ' />";		
		            //var im = "<img  src="+path+" width='250' height='199' class='slide1a ' />";	           
		            img1.push(im);
	            }else{
		            imgCount++;				        			        
	            }
            }
          
            if(imgCount > 19 ){
	            var path2 = "'http://www.UnitedCarExchange.com/images/stockMakes/"+carDetails['Make']['#text']+".jpg'";
	            var carMake = carDetails['Make']['#text'];			        
	            var carModel = carDetails['Model']['#text'];
	            carMake = carMake.replace(' ','-');
	            carModel = carModel.replace(' ','-');

	            if(carModel.indexOf('/')>0){
		            carModel='Other';
	            }
	            var MakeModel = carMake+"_"+carModel;
	            MakeModel = MakeModel.replace(' ','-');
	            path2 = "http://www.UnitedCarExchange.com/images/MakeModelThumbs/"+MakeModel+".jpg";			    
	            var path1 = "'http://www.UnitedCarExchange.com/images/no-image.jpg'";     
	            var im = "<div style='position:relative;	z-index:10;'><img  src="+path2+" class='carImg ' /><div class='stock2'>Stock Photo</div></div>";
	            //alert(im)
	            $('.profileImg').empty().append(im); 
	            $('.prevImg, .nextImg').hide();
            }else{
                //alert(img1[0])					       
	            var currentImg = 0;
	            $('.profileImg').empty().append(img1[0]); 	
	             $('.prevImg').hide();	 
	             if(img1.length > 1){
	                $('.nextImg').show();
	             }	
	             
	            $('.nextImg').click(function(){
	                if(currentImg < (img1.length-1)){
	                    $('.prevImg').show();
	                    currentImg++;
	                    $('.profileImg').empty().append(img1[currentImg]); 
	                    if(currentImg == (img1.length-1)){
	                        $('.nextImg').hide();
	                    }
	                }
	            }) 
	            
	            $('.prevImg').click(function(){
	                if(currentImg > 0){
	                    $('.nextImg').show();
	                    currentImg--;
	                    $('.profileImg').empty().append(img1[currentImg]); 
	                    if(currentImg == 0){
	                        $('.prevImg').hide();
	                    }
	                }
	            }) 
	             
	                
            }
             
    	    // -----------------------------------------------------------------------------------
        }
	  
    }
    catch (ex){ } 
   }
   
   
   
   function carFretures(result){
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
        if(result.length>0){
            p += "<h3 style='padding:0; margin:0 0 4px 0'>Car Specifications</h3>"
        }
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
        
        
        $('.Comfort').append(p);
        
   }
   
   
   

   
