var loadFile = function (event) {
    const idFotoPerfil = document.getElementById('ContentPlaceHolder1_fotoPerfil');
    var allowedExtensions = /(\.jpg|\.jpeg|\.png|\.gif|\.tiff|\.bmp)$/i
    var filePath = idFotoPerfil.value;
    if (allowedExtensions.exec(filePath)) {
        idFotoPerfil.src = URL.createObjectURL(event.target.files[0]);
    }
    else {
        //Mensagem de erro pq n ser imagem (popup)
    }
};


$(".uploadaimg").click(function () {
    $(".upload-imagem").click();


});