(function($) {
    // This function formats a text field to a US 
    // phone number as the user types the information.

    $.fn.usphone = function() {

        var phone = $(this).text();
        console.log(phone.length+' , ');
        if (phone.length == 10 && phone != 'undefined' && phone != '' && phone != ' ' && phone != null) {
            console.log(phone + ' , ');
            var finalPhone = '';
            for (i = 0; i < 10; i++ ) {
                if (i == 0) {
                    finalPhone += "(";
                }
                if (i == 3) {
                    finalPhone += ")";
                }
                if (i == 5) {
                    finalPhone += "-";
                }
                finalPhone += phone.charAt(i);
            }
            console.log(finalPhone);
            return finalPhone;
        }


    };
})(jQuery);