$(document).ready(function () {
    var bool = false;
    $('.caixxinha,.confirmar,.campos-pergunta,.pergunta').focus(function() { 
		$(this).css("border", "1.5px solid #0093ff");
	})
	
	$('.cadastro').click(function(){
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
	
    $('.caixxinha,.confirmar,.campos-pergunta,.pergunta').blur(function() { 
		$(this).css("border", "1.5px solid #fff");
	})
})				 