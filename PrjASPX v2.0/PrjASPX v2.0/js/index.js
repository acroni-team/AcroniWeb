$(document).ready(function(){
	var v = true;
	var c = true;
	$("#icon-ld").click(function(){

       if(c == true){
					$(this).css("color","#333");
					$("#conteudo").css("background-color","#333");
					$("#menu").css("background-color","#730dc4");
					$("#icon-dark").css("display","block");
					$("#icon-box-dark").css("display","none");
					$("#icon").css("display","none");
					$("#icon-box").css("display","block");
        	c = false;
       }
       else{
	        $(this).css("color","#333");
					$("#conteudo").css("background-color","#f2f2f2");
					$("#menu").css("background-color", "#53098e");
					$("#icon").css("display","block");
					$("#icon-box").css("display","none");
					$("#icon-dark").css("display","none");
					$("#icon-box-dark").css("display","block");
        	c = true;
        }

	});

		$("#icon-box-dark").click(function(){
						$("body").css("background-color","#1c1c1c");
						$("#conteudo").css("background-color","#1c1c1c");
						$("#icon-dark").css("display","block");
						$("#icon-box-dark").css("display","none");
						$("#icon").css("display","none");
						$("#icon-box").css("display","block");
						c = false;
		});
		 $("#icon-box").click(function(){
			 		$("body").css("background-color","#333");
					$("#conteudo").css("background-color","#f2f2f2");
					$("#icon").css("display","block");
					$("#icon-box").css("display","none");
					$("#icon-dark").css("display","none");
					$("#icon-box-dark").css("display","block");
					c = true;
			});
			
			
		$("#menu-icon").click(function(){
			if(v == true){
				$("#menu").fadeIn();
				$("#login").fadeOut();
               

				v = false;
			}
			else{
				$("#menu").fadeOut();
				$("#login").fadeIn();
				
				v = true;
			}
		});
			
		

		$("#menu-icon").click(function(){
			$('#menu-icon').toggleClass('active');		
						
		});

		$('#busca').focus(function () {
            $('#busca').attr("placeholder","")
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
