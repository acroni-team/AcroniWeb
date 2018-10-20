$(function(){
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