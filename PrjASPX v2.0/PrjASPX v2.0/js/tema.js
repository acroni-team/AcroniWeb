$(document).ready(function () {
    var alo = true;
    $("#muda").click(function () {

        
        ////$('#menu-icon').toggleClass('active');
        $('#buttons,#lsection,#login,#menu,li').toggleClass('active');
        if (alo == true) {
            $("body,#lsection,#rsection,nav,#right,#left").css("background-color", "#333");
            //(".hamburger,.hamburger:after,.hamburger:before").css("background-color", "#fff");
            //$('.blue').css("background-color", "#262626");
			$('#img').attr("src","../img/logo2.png");
			$('#muda').val("Teclados escritório").addClass("transition");

            alo = false;
        }
        else {
            $("body,#lsection,#rsection,nav,#right,#left").css("background-color", "#f2f2f2");
            //$(".hamburger,.hamburger:after,.hamburger:before").css("background-color", "#959595");
            $('#busca').css("background-color", "#fff");
            $('#muda').val("Teclados mecânicos").addClass("transition");
            $('#img').attr("src", "../img/apple.png");

			alo = true;
        }
    });
   
    
       
    $("#muda").click(function () {
        $("#fold_p").fadeOut(function () {
            $("#fold_p").text(($("#fold_p").text() == 'Teclados mecânicos') ? 'Teclados escritório' : 'Teclados mecânicos').fadeIn(200);
        })
    })
});
