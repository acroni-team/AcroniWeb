var loadFile = function (event) {
    const idFotoPerfil = document.getElementById('ContentPlaceHolder1_fotoPerfil');
    const idFotoPath = document.getElementById('ContentPlaceHolder1_FileUpload1');
    var allowedExtensions = /(\.jpg|\.jpeg|\.png|\.gif|\.tiff|\.bmp)$/i;
    var filePath = idFotoPath.value;
    console.log(filePath);
    if (allowedExtensions.exec(filePath)) {
        idFotoPerfil.src = URL.createObjectURL(event.target.files[0]);
    }
    else {
        //Mensagem de erro pq n ser imagem (popup)
        alert("VTNC");
    }
};


//$(".uploadaimg").click(function () {
//    $(".upload-imagem").click();


//});