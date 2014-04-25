/*!
* Auther      : Jyothirmayudu.CH
* Mail        : ch.jmayudu@gmail.com
* Created on  : 7th Apr 2014
* Discription : JS for MobiCarz Banner
*/




var testimonials = [

                        {
                            'name': 'James Martin',
                            'rating':5,
                            'testi': "Our decision to sell our BMW 3-Series Sedan through 'MobiCarz' has paid off very well. We experienced a definite increase in buyer responses for our car after posting our advertisement in Mobicarz and sold it with quickly and also managed to get fantastic price."
                        },
                        {
                            'name': 'Paul Jones',
                            'rating': 3,
                            'testi': "I have bought a Mercedes-Benz SLS AMG Roadster using Mobicarz, Thank you very much it's a breathtaking super sports car with the genes of the SLS AMG Coupe, yet with a character all of its own. Loving my Car :)"
                        },
                        {
                            'name': 'Robert White',
                            'rating': 3,
                            'testi': "I wish to thank Mobicarz and your sales team in the way you handled the transaction involving my dream car, BMW X Series. I received it in perfect condition. And many people are admiring it, it's fabulous. Please keep it up selling value for money vehicles. Thanks"
                        },
                        {
                            'name': 'Lisa Turner',
                            'rating': 4,
                            'testi': "I am happy to let you know that I received the vehicle in a very good condition and clean, I personally drove it all the way from Tampa, FL to Alpharetta, GA (490 mi ) without any problems keep Up the good work. The vehicle is for my personal use but I am looking forward to order another before the end of this month."
                        },
                        {
                            'name': 'Barbara Parker',
                            'rating': 3,
                            'testi': "I wish to express my satisfaction over the way Mobicarz managed to sell our 2005 Ferrari F430. I was wondering if I could sell it for good value, and to my luck on the same day I received a call from sales team of Mobicarz. I was impressed the way the sales guy explained me all the plans and I enrolled for Premium - Platinum package, It was a real worth as well the timely handling and confirmation of money transfers and shipments impressed me very much."
                        },
                        {
                            'name': 'Steven Miller',
                            'rating': 3,
                            'testi': "This was my first time purchasing a car on my own and I was extremely stressed out with pushy sales people until I went to Mobicarz, The sales team helped me and was not pushy at all which made me feel at ease. They were friendly and helped me every step of the way and gave me a great deal on my new Ford Mustang! :) I highly recommend Mobicarz if you are looking for a great sales person!"
                        },
                        {
                            'name': 'Thomas Garcia',
                            'rating': 3,
                            'testi': "I received the car yesterday. The people at the bond wanted me to sell it off to them. You chose a very nice and good car for my wife. I really want to thank the sales guy at Mobicarz."
                        }
                        
                    ]
















var slidesArray2 = [

                        {
                            'carID': '1042',
                            'img': 'assets/img/slides/slide1.jpg'
                        },
                        {
                            'carID': '1245',
                            'img': 'assets/img/slides/slide2.jpg'
                        },
                        {
                            'carID': '1247',
                            'img': 'assets/img/slides/slide3.jpg'
                        },
                        {
                            'carID': '1448 ',
                            'img': 'assets/img/slides/slide4.jpg'
                        },
                        {
                            'carID': '1449',
                            'img': 'assets/img/slides/slide5.jpg'
                        }

                    ];



var slidesArray = [

                        {
                            'name': 'BMW',
                            'subtitle': 'Z4',
                            'img': 'assets/img/slides/slide1.png',
                            'Year': '2011',
                            'Manufacturer': 'BMW industries',
                            'Condition': 'Importerd',
                            'Miles': '150,000 mi',
                            'Fuel': 'Petrol',
                            'Engine': '2000',
                            'Transmission': 'Automatic'
                        },

                        {
                            'name': 'Range Rover',
                            'subtitle': 'SUV',
                            'img': 'assets/img/slides/slide2.png',
                            'Year': '2014',
                            'Manufacturer': 'Range Rover industries',
                            'Condition': 'NZ New',
                            'Miles': '1,000 mi',
                            'Fuel': 'Petrol',
                            'Engine': '5000',
                            'Transmission': 'Automatic'
                        },
                        {
                            'name': 'Toyota Yaris',
                            'subtitle': 'V8, TDi',
                            'img': 'assets/img/slides/slide6.png',
                            'Year': '2000',
                            'Manufacturer': 'Toyota industries',
                            'Condition': 'NZ New',
                            'Miles': '12,400 mi',
                            'Fuel': 'Petrol',
                            'Engine': '3000',
                            'Transmission': 'Manual'
                        },
                        {
                            'name': 'Mustang ',
                            'subtitle': 'Shelby Cobra',
                            'img': 'assets/img/slides/slide3.png',
                            'Year': '2005',
                            'Manufacturer': 'Ford',
                            'Condition': 'NZ New',
                            'Miles': '135,000 mi',
                            'Fuel': 'Petrol',
                            'Engine': '2500',
                            'Transmission': 'Manual'
                        },
                        {
                            'name': 'Ford Explorer',
                            'subtitle': 'Sports Car SUV',
                            'img': 'assets/img/slides/slide4.png',
                            'Year': '2011',
                            'Manufacturer': 'Ford',
                            'Condition': 'NZ New',
                            'Miles': '235,000 mi',
                            'Fuel': 'Petrol',
                            'Engine': '5000',
                            'Transmission': 'Automatic'
                        },
                        {
                            'name': 'Audi Q7',
                            'subtitle': 'SUV',
                            'img': 'assets/img/slides/slide5.png',
                            'Year': '2013',
                            'Manufacturer': 'Audi',
                            'Condition': 'NZ New',
                            'Miles': '12,400 mi',
                            'Fuel': 'Petrol',
                            'Engine': '3000',
                            'Transmission': 'Automatic'
                        }

                    ];



// $('.highlighted-wrapper.gray').append(slides);



// Loop
/*
var img = '<div class="slide"><a href="detail.html">'+
            '<img src="assets/img/slides/toyota-1.png" alt="#"></a>'+
            '<div class="color-overlay"></div></div>';

*/








function DummyBanner() {
    var imgBanner = '';
    var slideData = '';

    for (i = 0; i < slidesArray.length; i++) {
        imgBanner += '<div class="slide"><a href="detail.html">' +
                '<img src="' + slidesArray[i].img + '" alt="#"></a>' +
                '<div class="color-overlay"></div></div>';


        slideData += '<div class="overview">' +
                    '<div class="overview-table">' +
                    '<div class="item title">' +
                        '<h3>' + slidesArray[i].name + '</h3>' +
                        '<div class="subtitle">' + slidesArray[i].subtitle + '</div></div>' +

                    '<div class="item line">' +
                        '<span class="property">Year</span> <span class="value">' + slidesArray[i].Year + '</span></div>' +

                    '<div class="item line">' +
                    '<span class="property">Manufacturer</span> <span class="value">' + slidesArray[i].Manufacturer + '</span></div>' +

                    '<div class="item line">' +
                        '<span class="property">Condition</span> <span class="value">' + slidesArray[i].Condition + '</span></div>' +

                    '<div class="item line">' +
                        '<span class="property">Miles</span> <span class="value">' + slidesArray[i].Miles + '</span></div>' +

                    '<div class="item line">' +
                        '<span class="property">Fuel Type</span> <span class="value">' + slidesArray[i].Fuel + '</span></div>' +

                    '<div class="item line">' +
                        '<span class="property">Engine</span> <span class="value">' + slidesArray[i].Engine + '</span></div>' +

                    '<div class="item line">' +
                        '<span class="property">Transmission</span> <span class="value">' + slidesArray[i].Transmission + '</span></div>' +

                '</div></div>';


    }

    $('.slidesData').append(slideData);
    $('.slidesData .overview:eq(0)').addClass('active');

    var arrows = '<div id="slider-navigation"><div class="prev"></div><div class="next"></div></div>';
    $('.slidesData').append(arrows);

    $('.slidesImg').append(imgBanner);
    $('.slidesImg .slide:eq(0)').addClass('active');



    _initSlider('#slider');

    // slidesData  slidesImg


}





    



                    
                    
                    
                        
                    

