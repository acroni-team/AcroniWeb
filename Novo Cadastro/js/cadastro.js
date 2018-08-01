//$(document).ready(function () {
    //$(".bluev2").click(function(){
       // $(".alo:nth-child(1)").removeClass("animacao");
      //  $(".alo:nth-child(1)").addClass("animacao2");
       // $(".alo:nth-child(1)").addClass("animacao");
   // }); 
//});



$(document).ready(function () {
 
    function animateIden() {
        animate(".identifica");
    }
        function animateCaixa() {
        animate(".caixa");
    }
    function animate(alo) {

        $(alo).each(function (i) {
            $(alo).eq(0).removeClass("animacao");
            $(alo).eq(0).addClass("animacao2");
            $(alo).eq(1).addClass("animacao");
                
       
        });
    }
  function animateBoth(){
    
    animateIden();
    animateCaixa();

}

    $(".bluev2").click(animateBoth);
    

    $(document).keypress(function(e) {
        if(e.which == 13) {
            animateBoth();
            
        }
    });
    
});