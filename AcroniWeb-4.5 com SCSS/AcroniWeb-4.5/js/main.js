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

    // Modal

    $('#abre-senha').click(function () {
        $('.modal-wrap').toggleClass('is-showing aparece');

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

