$(document).ready(function () {
    
    //Função do menu
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

    //Função das TextBox e buttons
    var bool = false;
    $('.caixxinha,.confirmar,.campos-pergunta,.pergunta').focus(function () {
        $(this).css("border", "1.5px solid #0093ff");
    })

    $('.cadastro').click(function () {
        if (bool == false) {
            //('.but,.cadastro').css("transform", "translateY(0px)");
            $('.centralizalogin').css("height", "225px");
            $('.confirmar').fadeIn();
            bool = true;
        }
        else {
            $('.centralizalogin').css("height", "150px");
            $('.confirmar').fadeOut();
            bool = false;
        }
    })

    $('.caixxinha,.confirmar,.campos-pergunta,.pergunta').blur(function () {
        $(this).css("border", "1.5px solid #fff");
    })
   
});

//	});
//	$("#").click(function(){
//		$(this).css("color","#f2f2f2");
//		$("#tolight").css("color","#f2f2f2");
//		$("#conteudo").css("background-color","#333");
