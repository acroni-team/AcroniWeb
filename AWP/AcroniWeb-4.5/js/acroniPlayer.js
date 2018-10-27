function toggleVideo() {
    const video = document.getElementById('videozinho');
    const btn = document.getElementById('play-pause');
    var play = document.querySelector('.play-button');


    if (video.paused) {
        btn.className = 'pause';
        video.play();
    }
    else {
        btn.className = 'play';
        video.pause();
    }

}

function toggleMute() {
    const video = document.getElementById('videozinho');
    const mute = document.getElementById('mute-unmute');
    if (video.muted) {
        video.muted = false;
        mute.className = 'mute';
    }
    else {
        video.muted = true;
        mute.className = 'muted';
    }
}

    //const video = document.getElementById('videozinho');
    //var bool = true;
    //if (bool === true) {
    //    video.setAttribute("muted", "true");
    //}
    //else {
    //    video.setAttribute("muted", "false");
    //}