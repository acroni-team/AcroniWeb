//$(document).ready(function () {
document.addEventListener('DOMContentLoaded', () => {

    //Função do menu
    var v = true;
    $("#menu-icon").click(function () {
        $('#menu-icon').toggleClass('active');
        if (v == true) {
            $("#menu").css("opacity", "1");
            $("#menu").css("pointer-events", "auto");
            $("#login").css("opacity", "0");
            $("#login").css("pointer-events", "none");

            v = false;
        }
        else {
            $("#menu").css("opacity", "0");
            $("#menu").css("pointer-events", "none");
            $("#login").css("opacity", "1");
            $("#login").css("pointer-events", "auto");

            v = true;
        }
    });

    //Loader
    


    // Modal-eas

    $('#abre-senha').click(function () {
        $('.modal-overflow').removeClass('hidden');
        $('.modal-wrap').addClass('is-showing');
        $('section').addClass('blur');
        $("body").niceScroll().remove();
    });

    $('.modal-background,.modal-button-cad').click(function () {
        var $step = $('.modal-body-step1');
        $step.toggleClass('animate-first-in animate-first-out');
        setTimeout(function () {
            $('section,.left-galeria,.right-logado ').removeClass('blur');
            $('.modal-wrap').removeClass('is-showing');
            $step.toggleClass('animate-first-out animate-first-in');
            $("body").niceScroll({ cursorcolor: "#0093ff", cursorwidth: "10px", cursorborder: "none" });
            $('.modal-overflow').addClass('hidden');
            
        }, 200);
    });


    //Função das TextBox e buttons
    var bool = false;
    // --------- Mascaras -----------


    $('#ContentPlaceHolder1_txtCPF').mask('000.000.000-00');
    $('#ContentPlaceHolder1_txtCEP').mask('00000-000');



})

