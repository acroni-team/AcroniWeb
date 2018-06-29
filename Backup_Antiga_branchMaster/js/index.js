$(document).ready(function(){
	
	$("#tolight").click(function(){
	
		$(this).css("color","#333");
		$("#todark").css("color","#333");
		$("#conteudo").css("background-color","#f2f2f2");
		
	});
	$("#todark").click(function(){
		$(this).css("color","#f2f2f2");
		$("#tolight").css("color","#f2f2f2");
		$("#conteudo").css("background-color","#333");
		
	});
	
});