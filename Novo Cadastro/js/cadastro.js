//$(document).ready(function () {
    //$(".bluev2").click(function(){
       // $(".alo:nth-child(1)").removeClass("animacao");
      //  $(".alo:nth-child(1)").addClass("animacao2");
       // $(".alo:nth-child(1)").addClass("animacao");
   // });
//});



$(document).ready(function () {
    var i = 0;
    function animateBoth(){
        animateIden();
        animateCaixa();
    }

    function animateIden() {
        animate(".identifica");
    }

    function animateCaixa() {
        animate(".caixa");
    }

    function animate(alo) {
        if(i == 0 || i == 1) {
            $(alo).eq(0).addClass("some"); //remove o 1
            $(alo).eq(1).addClass("aparece").focus();  //adiciona o 2
            i = i + 1;
        } else if(i == 2 || i == 3) {
            $(alo).eq(1).addClass("some"); //remove o 2
            $(alo).eq(2).addClass("aparece").focus();  //adiciona o 3
            i = i + 1;
        }
    }

    $(".bluev2").click(animateBoth);

    $(document).keypress(function(e) {
        if(e.which == 13) {
            animateBoth();
        }
    });

});
