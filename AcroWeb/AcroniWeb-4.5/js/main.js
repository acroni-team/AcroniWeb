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

    // Modal-eas

    $('#abre-senha').click(function () {
         $('.modal-wrap').addClass('is-showing');
         $('section').addClass('blur');
    });

    $('.modal-background').click(function () {
        var $step = $('.modal-body-step1');
        $step.toggleClass('animate-in animate-out');
        setTimeout(function () {
            $('section').removeClass('blur');
            $('.modal-wrap').removeClass('is-showing');
            $step.toggleClass('animate-out animate-in');
            
        }, 300);
    });


    //Função das TextBox e buttons
    var bool = false;
    $('.textbox,.campos-pergunta,.pergunta').focus(function () {
        //$(this).css("border", "1.5px solid #0093ff");
        $(this).addClass('foco');
    })

    $('.textbox,.campos-pergunta,.pergunta').blur(function () {
        //$(this).css("border", "1.5px solid #dfdfdf");
        $(this).removeClass('foco');
    })

    // --------- Mascaras -----------


    $('#ContentPlaceHolder1_txtCPF').mask('000.000.000-00');
    $('#ContentPlaceHolder1_txtCEP').mask('00000-000');



})

