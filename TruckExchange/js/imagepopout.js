function popop(){
    var Ht = 0;
    var Hl = 0;
    var Vt = 0;
    var Vl = 0;
    $('img.thumbH').hover(function(){            
            //var position = $(this).position();
            //console.log($(this).offset().left, $(this).offset().top);
            $('#myElem2').hide();
            $('#myElem ').removeAttr('src').attr('src',$(this).attr('desc'));
            Ht = ($(this).offset().top)-4;
            Hl = ($(this).offset().left)-4
            $('#myElem').css({left:Hl, top:Ht, width:141,height:86,opacity:0}).show().stop().animate( {
				    width:300,
				    height:183,
				    opacity:1,
				    left:($('#myElem').offset().left)-80,top:($('#myElem').offset().top)-49
				    			
				}, 400
			).addClass('image-popout-shadow');
			
        },function() {
			
		}); //END FUNCTION
		
		$('#myElem').mouseleave(function(){
		    $('#myElem').stop().animate({width:141,height:86,opacity:0, left:Hl, top:Ht},300,function(){$(this).hide().removeClass('image-popout-shadow');})
		    //$('#myElem img').stop().animate({width:200,height:122,opacity:0},250);
		});
		
		
		
    // Vertical Ads
    
     $('img.thumbV').hover(function(){            
            //var position = $(this).position();
            //console.log($(this).offset().left, $(this).offset().top);
            $('#myElem').hide();
            $('#myElem2 ').removeAttr('src').attr('src',$(this).attr('desc'));
            Vt = ($(this).offset().top)-4;
            Vl = ($(this).offset().left)-4
            $('#myElem2').css({left:Vl, top:Vt, width:120,height:73,opacity:0}).show().stop().animate( {
				    width:300,
				    height:183,
				    opacity:1,
				    left:($('#myElem2').offset().left)-90,top:($('#myElem2').offset().top)-56
				    			
				}, 400
			).addClass('image-popout-shadow');
			
        },function() {
			
		}); //END FUNCTION
		
		$('#myElem2').mouseleave(function(){
		    $('#myElem2').stop().animate({width:120,height:73,opacity:0, left:Vl, top:Vt},300,function(){$(this).hide().removeClass('image-popout-shadow');})
		    //$('#myElem img').stop().animate({width:200,height:122,opacity:0},250);
		});
			
		
   
    
	
}