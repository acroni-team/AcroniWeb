$(document).ready(function () {
    var v = true;

    

    $("#menu-icon").click(function () {
        $('#menu-icon').toggleClass('active');
        if (v == true) {
            $("#menu").fadeIn();
            $("#login").fadeOut();
            $('body').css("overflow-y", "hidden");

            v = false;
        }
        else {
            $("#menu").fadeOut();
            $("#login").fadeIn();
            $('body').css("overflow-y", "auto");

            v = true;
        }
    });

    $('#busca').focus(function () {
        $('#busca').attr("placeholder", "")
    });
    $('#busca').focusout(function () {

        if ($('#busca').attr("placeholder", "")) {
            $('#busca').attr("placeholder", "Busque aqui...")
        }
    });




});

//	});
//	$("#").click(function(){
//		$(this).css("color","#f2f2f2");
//		$("#tolight").css("color","#f2f2f2");
//		$("#conteudo").css("background-color","#333");
