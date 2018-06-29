$(document).ready(function () {
    var alo = true;
    $("#Button2").click(function () {
        //$('#menu-icon').toggleClass('active');
        $('#lsection,#login').toggleClass('active');
        if (alo == true){
            $("body,#lsection,#rsection").css("background-color", "#333");
            alo = false;
        }
        else {
            $("body,#lsection,#rsection").css("background-color", "#f2f2f2");
            alo = true;
        }
    });


});
