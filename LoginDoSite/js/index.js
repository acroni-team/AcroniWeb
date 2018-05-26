$(document).ready(function(){
	$('input[type="text"], input[type="password"]').focus(function() { 
		$(this).css("border", "1.5px solid #0093ff");
	})
	
	$('.cadastro').click(function(){
		
		$('button').css("transform", "translateY(0px)");
		$('.confirmar').slideToggle();
	})
	
	$('input[type="text"], input[type="password"]').blur(function() { 
		$(this).css("border", "1.5px solid #fff");
	})
})				 