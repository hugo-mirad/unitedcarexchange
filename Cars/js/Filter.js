﻿  /*!
 * Auther      : Jyothirmayudu.CH
 * Created on  : 8 Jan 2012
 * Mail        : ch.jmayudu@gmail.com
 * Discription : JS for search criteria Filter
 */
   
   var dummySearchResults = [];  
   /*
   var dummyArraySet = [] ;    
   var dummyArraySet2 = [] ;
   var dummyArraySet3 = [] ;
   var dummyArraySet4 = [] ;
   var dummyArraySet5 = [] ;
   var dummyArraySet6 = [] ;   
   
ExteriorColor
NumberOfSeats
NumberOfDoors
NumberOfCylinder
   
   
   
   */
   
   var PhotoChoice = 'withoutpic';  
   
   
   // New Added Function  ------------------------------------------------------------------------------------------
        function sortReturn(){
            // Search Filter Checkbox on change
           // alert('Return');
           /*
            if($('#Filter #choiceMileage ul li input:checked').length < 1){                
               // alert('Select at least one Mileage range ') ;
                $(this).attr('checked','checked');  
                $(this).parent().css('font-weight','bold');              
            }else if($('#Filter #choiceYear ul li input:checked').length < 1){                 
                 alert('Select at least one Year range ') ;
                 $(this).attr('checked','checked');
                 $(this).parent().css('font-weight','bold');
            }else if($('#Filter #choicePrice ul li input:checked').length < 1){                 
                 alert('Select at least one Price range ') ;
                 $(this).attr('checked','checked');
                 $(this).parent().css('font-weight','bold');
            }else 
            */
            if($('#Filter #choiceBody ul li input:checked').length < 1){                  
                   $(this).attr('checked', 'checked');
                   $(this).change();
                   alert('Select at least one Body Type ');
                 //$(this).parent().css('font-weight','bold');
            }else if($('#Filter #choiceFuel ul li input:checked').length < 1){            
                 $(this).attr('checked', 'checked');
                 $(this).change();
                 alert('Select at least one Fuel Type ');
                 //$(this).parent().css('font-weight','bold');
            }else if($('#Filter #choiceSeller ul li input:checked').length < 1){
                   
                   $(this).attr('checked', 'checked');
                   $(this).change();
                   alert('Select at least one Seller type ');
                 //$(this).parent().css('font-weight','bold');
            }   
            
            page = 1;
            $('.leftArrow div').removeClass('leftAct');
            $('.leftArrow div').addClass('leftDis');
                      
            filterChecked();            
                   
        
        
        
        }
    
   function rangeSliderChangge(){
       $('.moreResults').hide();
         if($('#Filter #choiceBody ul li input:checked').length < 1){
                   alert('Select at least one Body Type ') ;
                   $(this).attr('checked', 'checked');
                   $(this).change();
                 //$(this).parent().css('font-weight','bold');
            }else if($('#Filter #choiceFuel ul li input:checked').length < 1){                 
                 alert('Select at least one Fuel Type ') ;
                 $(this).attr('checked', 'checked');
                 $(this).change();
                 //$(this).parent().css('font-weight','bold');
            }else if($('#Filter #choiceSeller ul li input:checked').length < 1){
                   alert('Select at least one Seller type ') ;
                   $(this).attr('checked', 'checked');
                   $(this).change();
                 //$(this).parent().css('font-weight','bold');
            }   
            
            page = 1;
            $('.leftArrow div').removeClass('leftAct');
            $('.leftArrow div').addClass('leftDis');
                      
            filterChecked();      
   
   }
     
   $(function() {
   
        // Filter Photos Availablity RadioButton onchange
        $('#choicePhotos input:radio[name=photo]').click(function() {
            $('#choicePhotos input:radio[name=photo]').each(function(){
                if($(this).is(':checked')){
                    $(this).next('span').css('font-weight','bold');  
                }else{
                    $(this).next('span').css('font-weight','normal');                                       
                }
            });   
             if($('#choicePhotos input:radio[name=photo]:checked').val() == '1'){
                 PhotoChoice = 'withpic'; 
                 //$('#photo1').attr('checked','checked');
                 //$('#photo2').attr('checked',false);
                 
             }  else if($('#choicePhotos input:radio[name=photo]:checked').val() == '2'){
             PhotoChoice = 'withpic'; 
                 //$('#photo2').attr('checked','checked');
                 //$('#photo1').attr('checked',false);
             }
             //alert(PhotoChoice);
             
              filterChecked();       
            
        });
        
        // Search Filter On Sort change [Price, Year, Mileage]
        $('#filterSortBy').change('change keypress',function(){

            $('.moreResults').hide();
        
            var id = $('#filterSortBy option:selected').val();
            //GetSearchCriteria(id);
            if(id != '0'){
                //alert(id);
                showSpinner(); 
                PageResultsCount = parseInt($('#resultsPerPage option:selected').val());      
                startNum = 1;
                $('.leftArrow div').removeClass('leftAct');
                $('.leftArrow div').addClass('leftDis');
                endNum = PageResultsCount;
                 
                page = 1;
                SortData(id,PageResultsCount); 
                //filterChecked();   
            }
            
        });
        
        
        
        // Search Filter Checkbox on change
        $('#Filter li input[type=checkbox]').change(function() {
        
            
            /*if($('#Filter #choiceMileage ul li input:checked').length < 1){                
               // alert('Select at least one Mileage range ') ;
                $(this).attr('checked','checked');  
                $(this).parent().css('font-weight','bold');              
            }else if($('#Filter #choiceYear ul li input:checked').length < 1){                 
                 alert('Select at least one Year range ') ;
                 $(this).attr('checked','checked');
                 $(this).parent().css('font-weight','bold');
            }else if($('#Filter #choicePrice ul li input:checked').length < 1){                 
                 alert('Select at least one Price range ') ;
                 $(this).attr('checked','checked');
                 $(this).parent().css('font-weight','bold');
            }else
            */
             if($('#Filter #choiceBody ul li input:checked').length < 1){
                   alert('Select at least one Body Type ') ;
                   $(this).attr('checked', 'checked');
                   $(this).change();
                 //$(this).parent().css('font-weight','bold');
            }else if($('#Filter #choiceFuel ul li input:checked').length < 1){                 
                 alert('Select at least one Fuel Type ') ;
                 $(this).attr('checked', 'checked');
                 $(this).change();
                 //$(this).parent().css('font-weight','bold');
            }else if($('#Filter #choiceSeller ul li input:checked').length < 1){
                   alert('Select at least one Seller type ') ;
                   $(this).attr('checked', 'checked');
                   $(this).change();
                // $(this).parent().css('font-weight','bold');
            }   
            
            page = 1;
            $('.leftArrow div').removeClass('leftAct');
            $('.leftArrow div').addClass('leftDis');
                      
            filterChecked();            
                   
        });	
        
        
        
		
		
		$('.hed input[type=checkbox]').change(function () {
		    if($(this).is(':checked')){
                var id = $(this).parent().next('div').attr('id');
                resetGroupCheckboxes(id);
            } 
		});
		
		// choiceMileage, choiceYear, choicePrice, choiceBody, choiceFuel, choicePhotos, choiceSeller, 
		$('#choiceMileage ul li input[type=checkbox]').change(function () {
		    var count = $('#choiceMileage input[type=checkbox]').filter(':checked').length;
		    if(count < 7){		        
		        $('.hh1 input[type=checkbox]').removeAttr('checked');
		    }else{
		        $('.hh1 input[type=checkbox]').attr('checked','checked');
		    }
		});
		$('#choiceYear ul li input[type=checkbox]').change(function () {
		    var count = $('#choiceYear input[type=checkbox]').filter(':checked').length;
		    if(count < 9){		        
		        $('.hh2 input[type=checkbox]').removeAttr('checked');
		    }else{
		        $('.hh2 input[type=checkbox]').attr('checked','checked');
		    }
		});
		$('#choicePrice ul li input[type=checkbox]').change(function () {
		    var count = $('#choicePrice input[type=checkbox]').filter(':checked').length;
		    if(count < 5){		        
		        $('.hh3 input[type=checkbox]').removeAttr('checked');
		    }else{
		        $('.hh3 input[type=checkbox]').attr('checked','checked');
		    }
		});
		$('#choiceBody ul li input[type=checkbox]').change(function () {
		    var count = $('#choiceBody input[type=checkbox]').filter(':checked').length;
		    if(count < 9){		        
		        $('.hh4 input[type=checkbox]').removeAttr('checked');
		    }else{
		        $('.hh4 input[type=checkbox]').attr('checked','checked');
		    }
		});
		$('#choiceFuel ul li input[type=checkbox]').change(function () {
		    var count = $('#choiceFuel input[type=checkbox]').filter(':checked').length;
		    if(count < 5){		        
		        $('.hh5 input[type=checkbox]').removeAttr('checked');
		    }else{
		        $('.hh5 input[type=checkbox]').attr('checked','checked');
		    }
		});
		$('#choiceSeller ul li input[type=checkbox]').change(function () {
		    var count = $('#choiceSeller input[type=checkbox]').filter(':checked').length;
		    if(count < 2){		        
		        $('.hh6 input[type=checkbox]').removeAttr('checked');
		    }else{
		        $('.hh6 input[type=checkbox]').attr('checked','checked');
		    }
		});
		
		
			
   });  
    
    function resetGroupCheckboxes(id){
       
        $('#'+id+' ul li input[type=checkbox]').each(function() { 
             $(this).attr('checked','checked'); 
             $(this).parent().css('font-weight','bold');                   
        }); 
        filterChecked(); 
    }
  
  function totalCheckedID(){
    filterarryaycoutn = 0;
    $('#Filter ul li input[type=checkbox]').each(function() { 
            if($(this).is(':checked')){
               filterarryaycoutn++; 
            }           
        });  
        return filterarryaycoutn;
    
  }
  
  
   // Display Search Results depending on Filter on Change CheckBox
  function filterChecked() {       
     $('.searchResultsHolder').empty();
   // 
        //alert(id);
        //alert(PhotoChoice);  
        var checkBoxIDs = [];
        /*
        $('#choiceMileage ul li input[type=checkbox]').each(function() { 
            if($(this).is(':checked')){
                            checkBoxIDs.push($(this).attr('id'));  
            }           
        });   
        $('#choiceYear ul li input[type=checkbox]').each(function() { 
            if($(this).is(':checked')){
                checkBoxIDs.push($(this).attr('id'));  
            }           
        });  
        $('#choicePrice ul li input[type=checkbox]').each(function() { 
            if($(this).is(':checked')){
                checkBoxIDs.push($(this).attr('id'));  
            }           
        });  
        */
        
   
    
    $('#hdMil1').text(Mileage1);
    
    checkBoxIDs.push(Mileage1);
    checkBoxIDs.push(Mileage2);
    checkBoxIDs.push(Year1a);
    checkBoxIDs.push(Year1b);
    checkBoxIDs.push(Price1);
    checkBoxIDs.push(Price2);
        /*
        checkBoxIDs.push();
        Mileage1, Mileage2
        Year1a, Year1b
        Price1, Price2;
        */
        
        $('#choiceBody ul li input[type=checkbox]').each(function() { 
            if($(this).is(':checked')){
                checkBoxIDs.push($(this).attr('id'));  
            }           
        });  
        $('#choiceFuel ul li input[type=checkbox]').each(function() { 
            if($(this).is(':checked')){
                checkBoxIDs.push($(this).attr('id'));  
            }           
        });  
        $('#choiceSeller ul li input[type=checkbox]').each(function() { 
            if($(this).is(':checked')){
                checkBoxIDs.push($(this).attr('id'));  
            }           
        });
        
        checkBoxIDs.push(PhotoChoice);
          
            
            
        PageResultsCount = parseInt($('#resultsPerPage option:selected').val()); 
        
          
        showSpinner();
        
         //////****//////
      
       // GetCarsFilter(checkBoxIDs,PageResultsCount);  
       //-----------Starts 30-07-2013--------------//
       
      // console.log(checkBoxIDs,PageResultsCount);
       GetCarsFilterSpeed(checkBoxIDs,PageResultsCount);  
        //---------------End--------------//
        startNum = 1;
        $('.leftArrow div').removeClass('leftAct');
        $('.leftArrow div').addClass('leftDis');
        endNum = PageResultsCount;
        page = 1;
        
        sFilterType = parseInt($('#filterSortBy option:selected').val());    
        //var Orderby =    {'Orderby': sFilterType };        
        //checkBoxIDs.push(Orderby);
        //if(sFilterType != 0 && sFilterType != '0'){
        //SortData(sFilterType, PageResultsCount);
        //}

        $('.moreResults').hide(); 
                    
    }
    
   
    
    function arrowsAct(){
       $('#PaginationBlock').css('display','block');
        if(page < maxPages && maxPages > 1){            
            $('.rightArrow div').removeClass('rightDis');
            $('.rightArrow div').addClass('rightAct');            
        }else if(page == maxPages){
            $('.rightArrow div').removeClass('rightAct');
            $('.rightArrow div').addClass('rightDis');
        }else if(maxPages == 1){
            $('.leftArrow div').removeClass('leftAct');
            $('.leftArrow div').addClass('leftDis');
            $('.rightArrow div').removeClass('rightAct');
            $('.rightArrow div').addClass('rightDis');
        }
        else if(maxPages == 0)
        {
            $('#PaginationBlock').css('display','none');
            $('.leftArrow div').removeClass('leftAct');
            $('.leftArrow div').addClass('leftDis');
            
            $('.rightArrow div').removeClass('rightAct');
            $('.rightArrow div').addClass('rightDis');
        
        }
   }