/*!
 * Auther      : Jyothirmayudu.CH
 * Created on  : 5 July 2012
 * Mail        : ch.jmayudu@gmail.com
 * Discription : JS for Production Team
 */

var models;
LoadingPage = 3;
var selectedCarDiscription = "";
    
    $(function(){
        KeyListener.init();
        $('#spinner').hide();
        $('.txtCarID').numeric();
        $('.txtCarID').val('');
        
        $('.search').click(function(){
            ////console.log($('.txtCarID').val())
            var id = $('.txtCarID').val();
            if(id == '' || id == ' ' || id == '0' || id == '00'|| id == '000'|| id == '0000'|| id == '00000'|| id == '000000'|| id == '0000000' || id == '00000000' || id == '000000000'  ){
                $('.proDet').hide();
                alert('Enter valid Car ID');
                $('.txtCarID').focus();
                $('#spinner').hide();
            }else{
                  $('#spinner').show();
                  productionFindCarID(id);                 
            }
            
        });
    });
    
    KeyListener = {
        init : function() {
            $('#searchFormHolder').bind('keypress', function(e) {
                var key = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
                var target = e.target.tagName.toLowerCase();
                if (key === 13 && target === 'input') {
                    e.preventDefault();
                    var button = $('.search');
                    if (button.length > 0) {
                        if (typeof(button.get(0).onclick) == 'function') {
                            button.trigger('click');
                        }else if (button.attr('href')) {
                            window.location = button.attr('href');
                        }else {
                            button.trigger('click');
                        }
                    }
                   
                }               

            });
        }
    };
    
    function displayCarDetailsProduction(carDetails){
        ////console.log(carDetails); 
        $('.stock').hide();      
        if(carDetails != 'undefined' && carDetails != undefined){
            var year = carDetails['YearOfMake']['#text'];
            var make = carDetails['Make']['#text'];
            var model = carDetails['Model']['#text'];
            var Zip = carDetails['Zip']['#text'];
		    var carID = carDetails['Carid']['#text'];
    		var UrlMake=make;
    		var UrlModel = model;
    		UrlModel= UrlModel.replace('/','@');
    		UrlModel= UrlModel.replace('&','@');    		
    		var img1 = '';            	
            var imgCount = 0;	
            for(i=1;i<21;i++){
                if(carDetails['PIC'+i]['#text'] != 'Emp' && carDetails['PICLOC'+i]['#text'] != 'Emp'){    
                    var path = "'"+carDetails['PICLOC'+i]['#text']+"/"+carDetails['PIC'+i]['#text']+"'";  
                    var loaction = carDetails['PICLOC'+i]['#text'];
                    var img = carDetails['PIC'+i]['#text']
                    path = 'http://UnitedCarExchange.com/' + loaction + img;
                    path = path.replace(' ', '%20');
                    path = path.replace(' ', '%20');
                    path = path.replace(' ', '%20');
                    path = path.replace(' ', '%20');
                    path = path.replace(' ', '%20');
                    console.log(path);
                    img1 += "<li><img  src="+path+"   /></li>";
                   				        
                }else{
                    imgCount++;				        			        
                }
            }
            if(imgCount >19 ){
                var path2 = "'http://www.UnitedCarExchange.com/images/stockMakes/"+carDetails['Make']['#text']+".jpg'";
                var carMake = carDetails['Make']['#text'];			        
                var carModel = carDetails['Model']['#text'];
                
                carMake = carMake.replace(' ','-');
                carMake = carMake.replace(' ','-');
                carModel = carModel.replace(' ','-');
                carModel = carModel.replace('/','@');
                carModel = carModel.replace('&','@');
                  carModel = carModel.replace(' ','-');
                carModel = carModel.replace('/','@');
                carModel = carModel.replace('&','@');
                var MakeModel = carMake+"_"+carModel;			       
                MakeModel = MakeModel.replace(' ','-');
                MakeModel = MakeModel.replace('/','@');
                path2 = "http://www.UnitedCarExchange.com/images/MakeModelThumbs/"+MakeModel+".jpg";    
                var path1 = "'http://www.UnitedCarExchange.com/images/no-image.jpg'";
                
                img1 += "<li><img  src="+path2+" /><div class='stock'>Stock Photo</div></li>";		              
                $('div.imgHolder ul').empty().append(img1);
                $('.stock').show();
                
            }else{                
                $('div.imgHolder ul').empty().append(img1);
                $('.stock').hide();
            }

            var m = '';
		    
            /*m += carDetails['YearOfMake']['#text']+' '+carDetails['Make']['#text']+' '+carDetails['Model']['#text'];	*/
    			
		    
            
		    if (carDetails['Title']['#text'] != 'Emp' && carDetails['Title']['#text'] != '' && carDetails['Title']['#text'] != ' ' && carDetails['Title']['#text'] != 'undefined' && carDetails['Title']['#text'] != 'unspecified') {
                var title = carDetails['Title']['#text'];		       
		        m += title ;
		    } else {
		        m += carDetails['YearOfMake']['#text'] + " " + carDetails['Make']['#text'] + " " + carDetails['Model']['#text'];
		    }
		    
		    if (carDetails['Price']['#text'] != 'Emp' && carDetails['Price']['#text'] != '0' && carDetails['Price']['#text'] != null && carDetails['Price']['#text'] != 'Unspecified') {
		        m += ' - <span class="detPrice">' + carDetails['Price']['#text'] + '</span>'
		    }
		    //console.log(carDetails['AdStatus']['#text'])

		    m += "<label style='display:inline-block; float:right; text-align:right; color:#333; font-size:13px;'>AD Status: <small style='font-size:13px; color:#ff6600;'>" + carDetails['AdStatus']['#text'] + "</small></label>"

    		$('.Title').empty().append(m );		
            var address = '';
            
            
            if(carDetails['Carid']['#text'] != 'Emp' && carDetails['Carid']['#text'] != '' && carDetails['Carid']['#text'] != 'undefined' && carDetails['Carid']['#text'] != null){
                $('.carID').text(carDetails['Carid']['#text']);
            }            
            if(carDetails['SellerName']['#text'] != 'Emp' && carDetails['SellerName']['#text'] != '' && carDetails['SellerName']['#text'] != 'undefined' && carDetails['SellerName']['#text'] != null){
                $('.name').text(carDetails['SellerName']['#text']);
            }
            if(carDetails['Email']['#text'] != 'Emp' && carDetails['Email']['#text'] != '' && carDetails['Email']['#text'] != 'undefined' && carDetails['Email']['#text'] != null){
                $('.email').text(carDetails['Email']['#text']);
            }            
            if (carDetails['City']['#text'] != 'Emp' && carDetails['City']['#text'] != '' && carDetails['City']['#text'] != 'undefined' && carDetails['City']['#text'] != null && carDetails['City']['#text'] != 'Unspecified') {
                address = carDetails['City']['#text'];
            }
            
            if (carDetails['State']['#text'] != 'Emp' && carDetails['State']['#text'] != '' && carDetails['State']['#text'] != 'undefined' && carDetails['State']['#text'] != null && carDetails['State']['#text'] != 'Unspecified') {
                address+= ', '+carDetails['State']['#text'];
                $('.city').text(address);
            }else{
                $('.city').text(address);
            }
            
            var totalAdd = $('.city').text() + " " + Zip;
            $('.city').text(totalAdd);
            

            
		    if(carDetails['Phone']['#text'] != 'Emp' && carDetails['Phone']['#text'] != '' && carDetails['Phone']['#text'] != 'undefined' && carDetails['Phone']['#text'] != null){
                var dum= carDetails['Phone']['#text'];
			    var phone='';			
			    if(dum != null && dum != undefined && dum != ''){
			        phone += dum[0]+''+dum[1]+''+dum[2]+'-'+dum[3]+''+dum[4]+''+dum[5]+'-'+dum[6]+''+dum[7]+''+dum[8]+''+dum[9];
			    }else{
			        phone = '';
			    }
                
                $('.phone').text(phone);
            }

            //Buy - Sell - UsedCar / 1991 - Volkswagen - Vanagon - 518445981658
           var Ma1=make;
           if(Ma1=="W & M") Ma1= "WM";
            //$('.link1').attr('href','http://UnitedCarExchange.com/SearchCarDetails.aspx?Make='+make+'&Model='+model+'&ZipCode='+Zip+'&WithinZip=5&C=l3tTlT66'+carID).attr('readonly','readonly');
            // $('.link1').attr('href', 'http://localhost:50531/Cars/a1/' + year + '-' + Ma1 + '-' + UrlModel + '-' + carDetails['CarUniqueID']['#text']).attr('readonly', 'readonly');
           $('.link1').attr('href', 'http://UnitedCarExchange.com/a1/' + year + '-' + Ma1 + '-' + UrlModel + '-' + carDetails['CarUniqueID']['#text']).attr('readonly', 'readonly');
            
            $('.url').empty().html(encodeURI($('.link1').attr('href')));           
            
            var det = '';
			
			det += "<h3>About This "+carDetails['Make']['#text']+' '+carDetails['Model']['#text']+"</h3><table style='width:600px; margin:0' id='carDet1' >  <tr>    <td style='width:50%;vertical-align:top'><strong>Make: </strong> "+carDetails['Make']['#text']+"<br /><strong>Model: </strong> "+carDetails['Model']['#text']+"<br /><strong>Year: </strong> "+carDetails['YearOfMake']['#text']+"<br /><strong>Body Style: </strong> ";
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
			det +="<br /></td><td valign='top' ><strong>Price: </strong><span class='detPrice2'>";
			if(carDetails['Price']['#text'] != 'Emp' && carDetails['Price']['#text'] != 'Unspecified' && carDetails['Price']['#text'] != '0' && carDetails['Price']['#text'] != null ){
			  det += carDetails['Price']['#text'];  
			}
			det += "</span><br /><strong>Mileage:</strong>"
			if(carDetails['Mileage']['#text'] != 'Emp' && carDetails['Mileage']['#text'] != 'Unspecified' && carDetails['Mileage']['#text'] != '0' && carDetails['Mileage']['#text'] != null ){
			  det += "<span class='detMileage'>"+carDetails['Mileage']['#text']+"</span> mi";  
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
			det += "<br /><strong>Drivetrain: </strong>";
			if(carDetails['DriveTrain']['#text'] != 'Emp' && carDetails['DriveTrain']['#text'] != 'Unspecified'){
			  det += carDetails['DriveTrain']['#text'];  
			}
			det +="<br /><strong>VIN: </strong>"
			if(carDetails['VIN']['#text'] != 'Emp' && carDetails['VIN']['#text'] != 'Unspecified'){
			  det += carDetails['VIN']['#text'];  
			}
			det +="<br /></td></tr>";
			// det += "<tr><td colspan='2'><br /><h3>Description</h3><label>" + carDetails['Description']['#text'] + "</label></td></tr>";
			det += "</table><div class='clear'></div><br /z>";
						
			
			
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
			//if(carDetails['Description']['#text'] != 'Emp' && carDetails['Description']['#text'] != undefined && carDetails['Description']['#text'] != null){
			if (carDetails['Description']['#text']) {
			    selectedCarDiscription = carDetails['Description']['#text'];
			} else {
			    selectedCarDiscription = "";
			}
			    
			//}
			
			m += "<br><p class='Comfort'></p>";
			
			$('.SellerNotes').empty();
			$('.SellerNotes').append(m);
			CarID1 = carDetails['CarUniqueID']['#text']
			////console.log(CarID1);
		    GetCarFeatures(CarID1);
		    
		    $('.detPrice, .detPrice2').formatCurrency();    
		    $('.detMileage').formatCurrency({symbol: ''});    
            $('.proDet').show();
            $('#spinner').hide();
         }else{
            $('.proDet').hide();
            $('#spinner').hide();
            alert('Car ID does not exist..!');
        }
        
    }
    
             
           
    function carFretures(result){
        ////console.log(result);
        $('.Comfort').empty();
        var p = ''
        var Comfort = [];
        var Seats = [];
        var Safety = [];
        var Sound = [];
        var Windows = [];
        var Other = [];
        var Specials = [];
        for(i=0; i< result.length;i++){
            var str = result[i];
            if(str.substring(0,7)=='Comfort'){
                Comfort.push(str);
            }else if (str.substring(0, 5) == 'Other') {
                Other.push(str);
            }else if (str.substring(0, 6) == 'Safety') {
                Safety.push(str);
            }else if (str.substring(0, 5) == 'Seats') {
                Seats.push(str);
            }else if(str.substring(0,5)=='Sound'){
                Sound.push(str);
            }else if(str.substring(0,7)=='Windows'){
                Windows.push(str);
            } else if (str.substring(0, 8) == 'Specials') {
                Specials.push(str);
            }  
                     
        }
        
        p += "<h3 style='padding:0; margin:0 0 4px 0'>Car Specifications</h3>"
        
        p += '<strong>Comfort: </strong><label>';
        for(i=0; i<Comfort.length; i++){
            p += Comfort[i].substring(8);
            if(i!=Comfort.length-1){
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
        for(i=0; i<Safety.length; i++){
            p += Safety[i].substring(7)
            if(i!=Safety.length-1){
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
        for(i=0; i<Sound.length; i++){
            ////console.log(Sound[i]);
            p += Sound[i].substring(13)
            if(i!=Sound.length-1){
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
        for(i=0; i<Windows.length; i++){
            p += Windows[i].substring(8)
            if(i!=Other.length-1){
                p += ', ';
            }
        }
        p += '</label>';
        
        
        
        
        p+= "<br><p style='padding-top:17px; padding-bottom:14px;'><strong style='font-size: 1.17em; width:100px'>Description: </strong>"+selectedCarDiscription;
        
        p+= '<br><div class="clear">&nbsp;</div>';
        
       
        
        
        
        var br = ""
        $('.Comfort').append(br+p);
        $('.Comfort label').each(function(){
            $(this).text($(this).text().trim());
            var len = $(this).text().length;             
                     
            if($(this).text().charAt(len-1)==','){
              $(this).text($(this).text().substring(0, len-1));  
            }
        });
        
        
   }   