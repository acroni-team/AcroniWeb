// --------Função do youtube player;-----

// loadando o codigo do IFrame Player API.
var tag = document.createElement('script');

tag.src = "https://www.youtube.com/iframe_api";
var firstScriptTag = document.getElementsByTagName('script')[0];
firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);

// Creando um Iframe apartir do div com id = variavel (nesse caso player).
var player;
function onYouTubeIframeAPIReady() {
    player = new YT.Player('player', {
        videoId: 'FEQaC7SWoHQ',
        playerVars: { 'autoplay': 1 },
        events: {
            'onReady': onPlayerReady
        }
    });
}



// API chama a função assim que o player termina de ser carregado.
function onPlayerReady(event) {
    player.setPlaybackRate(1);

}

