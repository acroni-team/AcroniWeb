// Main.js => Todas as funções das páginas dependentes do layout.master estão aqui

//$(document).ready(function () {
document.addEventListener('DOMContentLoaded', () => {
    //----------------
    // Função do menu 
    //----------------
    $(document).ready(function () {
        $("a").on('click', function (event) {
            if (this.hash !== "") {
                event.preventDefault();
                var hash = this.hash;
                $('html, body').animate({
                    scrollTop: $(hash).offset().top
                }, 800, function () {
                    window.location.hash = hash;
                });
            }
        });
    });

    var lastScroll = 0;
    $(window).on('scroll', function () {
        var st = $(window).scrollTop();
        if (st === 0) {
            $('nav').removeClass('hidden visible');
        }
        else if (st > lastScroll) {
            $('nav').removeClass('visible').addClass('hidden');
        }
        else {
            $('nav').removeClass('hidden').addClass('visible');
        }

        lastScroll = st;
    });

    
 

    //----------- 
    // Modal-eas
    //-----------
    function abremodal() {
        var $step = $('.modal-body-step1');

        $step.addClass('animate-first-in');

        $('.modal-overflow').removeClass('hidden');
        $('.modal-wrap').addClass('is-showing');
        //$('section').addClass('blur');
        $("body").niceScroll().remove();
    }

    $('#abre-senha').click(abremodal);


    $('.modal-background,.modal-button-cad,.modal-button-dc').click(function () {
        var $step = $('.modal-body-step1');
        var $step2 = $('.modal-body-step2');
        $step.removeClass('animate-out').toggleClass('animate-first-in animate-first-out');
        $step2.removeClass('animate-in').addClass('animate-first-out');
        setTimeout(function () {
            //$('section,.left-galeria,.right-logado ').removeClass('blur');
            $('.modal-wrap').removeClass('is-showing');
            $step.toggleClass('animate-first-out animate-first-in');
            $step2.removeClass('animate-first-out').addClass('animate-first-in');
            $("body").niceScroll({ cursorcolor: "#ccc", cursorwidth: "10px", cursorborder: "none", horizrailenabled: false, autohidemode: 'leave', cursoropacitymin: 1, zindex: '99999999' });
            $('.modal-overflow').addClass('hidden');
        }, 200);
    });


    //Função das TextBox e buttons
    var bool = false;

    //------------------
    // Click da loja
    //------------------
    $('figure').click(function () {
        var id = $(this).attr("name");
        $('.modal-overflow').removeClass('hidden');
        $("#Produto" + id).removeClass("animate-out").addClass("is-showing animate-in");
        $("body").niceScroll().remove();

        $('.modal-background, .fecha-janela').click(function () {
            //$("body").niceScroll({ cursorcolor: "#0093ff", cursorwidth: "10px", cursorborder: "none" });
            $("body").niceScroll({ cursorcolor: "#ccc", cursorwidth: "10px", cursorborder: "none", horizrailenabled: false, autohidemode: 'leave', cursoropacitymin: 1, zindex: '99999999' });
            $("#Produto" + id).removeClass("is-showing animate-in").addClass("animate-out");
        });
    });


    //----------
    // Mascaras
    //----------
    $('#ContentPlaceHolder1_txtCPF').mask('000.000.000-00');
    $('#ContentPlaceHolder1_txtCEP').mask('00000-000');
    $('#ContentPlaceHolder1_txtCpf').mask('000.000.000-00');
    $("#ContentPlaceHolder1_CPF").mask('000.000.000-00');
    $("#ContentPlaceHolder1_CEP").mask('00000-000');
    $("#ContentPlaceHolder1_Numero").mask('0000 0000 0000 0000');
    $("#ContentPlaceHolder1_DataValidade").mask('00/00');


    //---------------------------- 
    // Função do calculo de frete
    //----------------------------
    $(".textbox.focus").keyup(function () {
        if ($(this).val().length == 9) {
            //adiciona o loader aqui
            var txt = $(this);
            $.ajax({
                type: "POST",
                url: "loja.aspx/calcularFrete",
                data: '{cep: "' + $(this).val() + '", id: "' + $(this).attr('data-idProduto') + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    txt.next().next().children('span:nth-child(2)').text((parseFloat(txt.attr('data-precoBase')) + parseFloat(data.d)).toFixed(2).replace(".", ","));
                },
                error: function (msg) {
                    alert("Não foi possível calcular o frete :/");
                },
                complete: function () {
                    //retira aqui
                }
            });
        }
    });




});



//------------------
// Função do loader
//------------------
function loader(lds, btn) {
    $(lds).css("opacity", "1");
    $(btn).css("color", "#0093ff");
}

//----------------------
// Transição de páginas
//----------------------
$(function () {
    'use strict';
    var $page = $('#modal,#main'),
        options = {
            debug: false, //Ainda tentando entender esses comandos aqui
            prefetch: true,
            cacheLength: 2,
            onStart: {  // No incio da página/ loading
                duration: 500, // Duração da animação
                render: function ($container) { //Função daquela 'classe' (smoothStatejs) que ativa tal ação quando o usuário estiver saindo de uma página

                    $container.addClass('saindo-da-pagina'); // Adiciona aquela classe la pra reverter a animação

                    smoothState.restartCSSAnimations();  // Reinicia a animção
                }
            },
            onReady: { // quando pronto(dps da troca de pagina)
                duration: 0,
                render: function ($container, $newContent) {
                    // Remove a classe 'saindo-da-pagina' (que reverte a animação)
                    $container.removeClass('saindo-da-pagina');
                    // Inject the new content
                    $container.html($newContent);
                }
            }
        },
        smoothState = $page.smoothState(options).data('smoothState');
});


//---------------------
// Disable back button
//---------------------
if (!$('#ContentPlaceHolder1_txtNome').hasClass('aparece')) {
    history.pushState(null, null, location.href);
    window.onpopstate = function () {
        history.go(1);
    };
}

$('.btn-preencher').click(function () {
    $('.textbox').eq(0).val("Emanuel Ruan Nathan Barros");
    $('.textbox').eq(1).val("emanuel01");
    $('.textbox').eq(2).val("emanuelruan165@gmail.com");
    $('.textbox').eq(4).val("025.471.988-00");
    const btnSalva = document.getElementById('ContentPlaceHolder1_btnValida');
    btnSalva.classList.remove("disableded");
    btnSalva.classList.add("button-cad-next");
    btnSalva.disabled = false;
});

//---------
//CSS RULE
//---------
var s = document.styleSheets[1];

console.log(s);

function changeStylesheetRule(stylesheet, selector, property, value) {
    selector = selector.toLowerCase();
    property = property.toLowerCase();
    value = value.toLowerCase();

    for (var i = 0; i < s.cssRules.length; i++) {
        var rule = s.cssRules[i];
        if (rule.selectorText === selector) {
            rule.style[property] = value;
            return;
        }
    }

    stylesheet.insertRule(selector + " { " + property + ": " + value + "; }", 0);
}


//---------------              
// Acroni Player 
//---------------
function toggleVideo() {
    const video = document.getElementById('videozinho');
    const btn = document.getElementById('play-pause');
    var play = document.querySelector('.play-button');
    const cvideo = document.querySelector('.c-video');

    if (video.paused) {
        btn.className = 'material-icons pause';
        play.className = 'play-button play';
        cvideo.onmouseout = function () { play.className = 'play-button playing'; };
        video.play();
    }
    else {
        btn.className = 'material-icons play';
        play.className = 'play-button';
        cvideo.onmouseout = null;
        video.pause();
    }

}

function toggleMute() {
    const video = document.getElementById('videozinho');
    const mute = document.getElementById('mute-unmute');
    if (video.muted) {
        video.muted = false;
        mute.className = 'material-icons mute';
    }
    else {
        video.muted = true;
        mute.className = 'material-icons muted';
    }
}



//____________
//            |  
// Angular.js |
//____________|
var acroni = angular.module('acroni', []);
var controllers = {};

var qtdVal = [];

/*
    Mini protocolo do array qtdVal:
    0: indica se a senha é maior que oito
    1: indica se a senha tem letras maiúsculas
    2: indica se a senha tem letras minúsculas
    3: indica se a senha tem números
    4: indica se a senha tem símbolos
*/

const lengthValidator = (pass) => {
    if (pass.length >= 8) {
        qtdVal[0] = true;
    } else {
        qtdVal[0] = false;
    }
};

const capitalValidator = (pass) => {
    const upperCaseLetters = /[A-Z]/g;
    if (pass.match(upperCaseLetters)) {
        qtdVal[1] = true;
    } else {
        qtdVal[1] = false;
    }
};

const lowercaseValidator = (pass) => {
    const lowerCaseLetters = /[a-z]/g;
    if (pass.match(lowerCaseLetters)) {
        qtdVal[2] = true;
    } else {
        qtdVal[2] = false;
    }
};

const numberValidator = (pass) => {
    const numbers = /[0-9]/g;
    if (pass.match(numbers)) {
        qtdVal[3] = true;
    } else {
        qtdVal[3] = false;
    }
};

const symbolValidator = (pass) => {
    const symbols = /[$-/:-?{-~!"^_`\[\]]/;
    if (pass.match(symbols)) {
        qtdVal[4] = true;
    } else {
        qtdVal[4] = false;
    }
};

controllers.validaSenha = function ($scope) {
    $scope.senha = "";
    $scope.mensagem = "";

    $scope.mudaCor = function ($event) {
        const btnSalva = document.getElementById('ContentPlaceHolder1_btnValida');
        const bordinha = document.getElementById('ContentPlaceHolder1_border');
        if (document.querySelectorAll('.textbox.textbox-type2.textbox-cad')[0].value != "" ||
            document.querySelectorAll('.textbox.textbox-type2.textbox-cad')[1].value != "" ||
            document.querySelectorAll('.textbox.textbox-type2.textbox-cad')[2].value != "" ||
            document.querySelectorAll('.textbox.textbox-type2.textbox-cad')[3].value != "" ||
            document.querySelectorAll('.textbox.textbox-type2.textbox-cad')[4].value != "" ||
            document.querySelectorAll('.textbox.textbox-type2.textbox-cad')[5].value != "" ||
            document.querySelectorAll('.textbox.textbox-type2.textbox-cad')[6].value != "") {
            btnSalva.classList.remove("disableded");
            btnSalva.classList.add("button-cad-next");
            btnSalva.disabled = false;
            if (document.querySelectorAll('.textbox.textbox-type2.textbox-cad')[5].value != "") {
                bordinha.classList.add("textbox-expanded");

                lengthValidator($scope.senha);
                capitalValidator($scope.senha);
                lowercaseValidator($scope.senha);
                numberValidator($scope.senha);
                symbolValidator($scope.senha);

                var i = 0;

                function contarOp(element) {
                    if (element) {
                        i += 1;
                    }
                }

                qtdVal.forEach(contarOp);

                if (i == 1) {
                    bordinha.style.borderColor = "#FF393A";
                    bordinha.style.color = "#FF393A";
                    btnSalva.style.filter = "hue-rotate(150deg)";
                    $scope.mensagem = "Vamos lá, você consegue melhorar isso." //"Vamos lá, você consegue melhorar isso.";
                }
                else if (i == 2) {
                    bordinha.style.borderColor = "#E29400";
                    bordinha.style.color = "#E29400";
                    btnSalva.style.filter = "hue-rotate(195deg)";
                    $scope.mensagem = "Não é a senha dos sonhos, mas...";
                }
                else if (i == 3) {
                    bordinha.style.borderColor = "#D5CD00";
                    bordinha.style.color = "#D5CD00";
                    btnSalva.style.filter = "hue-rotate(215deg)";
                    $scope.mensagem = "Existem senhas mais fortes.";
                }
                else if (i == 4) {
                    bordinha.style.borderColor = "#00ff6b";
                    bordinha.style.color = "#00ff6b";
                    btnSalva.style.filter = "hue-rotate(300deg)";
                    $scope.mensagem = "Já é o sufuciente por aqui."//"Já é o sufuciente por aqui.";
                }
                else if (i == 5) {
                    bordinha.style.borderColor = "#0093ff";
                    bordinha.style.color = "#0093ff";
                    btnSalva.style.filter = "hue-rotate(350deg)";
                    $scope.mensagem = "Nossa! Muito forte, cara, impressionante!";
                }

            }
        }
        else {
            btnSalva.classList.add("disableded");
            btnSalva.disabled = true;
            if (bordinha.classList.contains("textbox-expanded")) {
                bordinha.classList.remove("textbox-expanded");
            }
            bordinha.style.borderColor = "#0093ff";
            bordinha.style.color = "#0093ff";
            btnSalva.style.filter = "hue-rotate(350deg)";
            $scope.mensagem = "";
        }
    }

}

acroni.controller(controllers);



//----------------------------------------
// Código Antigo
//-----------------------------------------
    //var v = true;
    //$("#menu-icon").click(function () {
    //    $('#menu-icon').toggleClass('active');
    //    if (v == true) {
    //        $("#menu").css("opacity", "1");
    //        $("#menu").css("pointer-events", "auto");
    //        $("#login").css("opacity", "0");
    //        $("#login").css("pointer-events", "none");

    //        v = false;
    //    }
    //    else {
    //        $("#menu").css("opacity", "0");
    //        $("#menu").css("pointer-events", "none");
    //        $("#login").css("opacity", "1");
    //        $("#login").css("pointer-events", "auto");

    //        v = true;
    //    }
    //});



//// --------Função do youtube player;-----

//// loadando o codigo do IFrame Player API.
//var tag = document.createElement('script');

//tag.src = "https://www.youtube.com/iframe_api";
//var firstScriptTag = document.getElementsByTagName('script')[0];
//firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);

//// Creando um Iframe apartir do div com id = variavel (nesse caso player).
//var player;
//function onYouTubeIframeAPIReady() {
//    player = new YT.Player('player', {
//        videoId: 'FEQaC7SWoHQ',
//        playerVars: { 'autoplay': 1 },
//        events: {
//            'onReady': onPlayerReady
//        }
//    });
//}



//// API chama a função assim que o player termina de ser carregado.
//function onPlayerReady(event) {
//    player.setPlaybackRate(1);

//}
