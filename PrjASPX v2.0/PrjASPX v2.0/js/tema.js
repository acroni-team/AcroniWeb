$(document).ready(function () {
    var alo = true;
    $(".blue").click(function () {

       
        ////$('#menu-icon').toggleClass('active');
        $('#buttons,#lsection,#login,#menu,li').toggleClass('active');
        if (alo == true) {
            $("body,#lsection,#rsection,nav,#right,#left").css("background-color", "#333");
            $('#busca').css("background-color", "#262626");
			$('#img').attr("src","../img/logo2.png");
			$('#muda').text("Teclados escritório");

            alo = false;
        }
        else {
            $("body,#lsection,#rsection,nav,#right,#left").css("background-color", "#f2f2f2");
            $('#busca').css("background-color", "#fff");
            $('#muda').text("Teclados mecânicos");
            $('#img').attr("src", "../img/apple.png");

			alo = true;
        }
    });


});
