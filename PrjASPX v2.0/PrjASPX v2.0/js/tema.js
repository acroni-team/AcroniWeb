$(document).ready(function () {
    var alo = true;
    $("#muda").click(function () {

       
        ////$('#menu-icon').toggleClass('active');
        $('#buttons,#lsection,#login,#menu').toggleClass('active');
        if (alo == true) {
            $("body,#lsection,#rsection,nav,#right,#left").css("background-color", "#333");
            $('#busca').css("background-color", "#262626")
            $('#menu').css("color", "#f2f2f2")
            $("li").css("color", "#f2f2f2");
			$('#img').attr("src","../img/logo2.png");
			$('#muda').text("Teclados escritório");

            alo = false;
        }
        else {
            $("body,#lsection,#rsection,nav,#right,#left").css("background-color", "#f2f2f2");
            $('#busca').css("background-color", "#fff")
            $('#menu').css("color", "#333")
            $("li").css("color", "#333");
            $('#muda').text("Teclados mecânicos");
            $('#img').attr("src", "../img/apple.png");

			alo = true;
        }
    });


});
