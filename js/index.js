$(document).ready(function(){

	var c = true;
	$(".icon-ld").click(function(){

       if(c == true){
		$(this).css("color","#333");
		$("#conteudo").css("background-color","#333");
        c = false;
       }
       else{
        $(this).css("color","#333");
		$("#conteudo").css("background-color","#f2f2f2");
        c = true;
        }

	});

});

//	});
//	$("#").click(function(){
//		$(this).css("color","#f2f2f2");
//		$("#tolight").css("color","#f2f2f2");
//		$("#conteudo").css("background-color","#333");
