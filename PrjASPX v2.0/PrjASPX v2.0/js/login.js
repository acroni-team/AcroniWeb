$(document).ready(function(){
    $('.caixxinha,.confirmar,.campos-pergunta,.pergunta').focus(function() { 
		$(this).css("border", "1.5px solid #0093ff");
	})
	
	$('.cadastro').click(function(){
		
        //('.but,.cadastro').css("transform", "translateY(0px)");
        $('.confirmar').fadeIn();
        $('.centralizalogin').css("height", "240px");
	})
	
    $('.caixxinha,.confirmar,.campos-pergunta,.pergunta').blur(function() { 
		$(this).css("border", "1.5px solid #fff");
	})
})				 