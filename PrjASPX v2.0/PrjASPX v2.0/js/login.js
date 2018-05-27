$(document).ready(function(){
	$('.caixxinha,.confirmar').focus(function() { 
		$(this).css("border", "1.5px solid #0093ff");
	})
	
	$('.cadastro').click(function(){
		
		$('.but,.cadastro').css("transform", "translateY(0px)");
		$('.confirmar').slideToggle();
	})
	
	$('.caixxinha,.confirmar').blur(function() { 
		$(this).css("border", "1.5px solid #fff");
	})
})				 