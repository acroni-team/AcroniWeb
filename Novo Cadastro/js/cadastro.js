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
            changeGroup(0, 1, alo);
        } else if(i == 2 || i == 3) {
            changeGroup(1, 2, alo);
        }
        else if(i == 4 || i == 5) {
            changeGroup(2, 3, alo);
        }
    }

    function changeGroup(f, l, seletor) {
        $(seletor).eq(f).addClass("some");             //remove o 1
        $(seletor).eq(l).addClass("aparece").focus();  //adiciona o 2
        i = i + 1;
    }

    $(".bluev2").click(animateBoth);

    $(document).keypress(function(e) {
        if(e.which == 13) {
            animateBoth();
        }
    });

});
