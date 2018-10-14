var loadFile = function (event) {
    const idFotoPerfil = document.getElementById('ContentPlaceHolder1_fotoPerfil');
    const idFotoPath = document.getElementById('ContentPlaceHolder1_FileUpload1');
    var allowedExtensions = /(\.jpg|\.jpeg|\.png|\.gif|\.tiff|\.bmp)$/i;
    var filePath = idFotoPath.value;

    if (allowedExtensions.exec(filePath)) {
        idFotoPerfil.src = URL.createObjectURL(event.target.files[0]);
        $('.btn-enable-salvar').click();
    }
    else {
        //Mensagem de erro pq n ser imagem (popup)
    }
};

$(document).ready(function () {


    $('.textbox.focus.dark, .upload-imagem').change(function () {
        
        if ($('.textbox.focus.dark').eq(0).val() != "" ||
            $('.textbox.focus.dark').eq(1).val() != "" ||
            $('.textbox.focus.dark').eq(2).val() != "" ||
            $('.textbox.focus.dark').eq(3).val() != "" ||
            $('.textbox.focus.dark').eq(4).val() != "" ||
            $('.textbox.focus.dark').eq(5).val() != "" ||
            $('.upload-imagem').val() != "") {
            $('.button.dark.minha-conta').removeAttr('disabled');
            $('.button.dark.minha-conta').removeClass('disabled');
            $('.button.dark.minha-conta').attr('value','Salvar');
        }
        else {
            $('.button.dark.minha-conta').attr('disabled');
            $('.button.dark.minha-conta').addClass('disabled');
            $('.button.dark.minha-conta').attr('value','Salvo');
        }


    });

    $('.textbox.textbox-type3.focus.dark').change(function () {

        if ($('.textbox.focus.dark').eq(0).val() != "" ||
            $('.textbox.focus.dark').eq(1).val() != "" ||
            $('.textbox.focus.dark').eq(2).val() != "" ||
            $('.textbox.focus.dark').eq(3).val() != "" ||
            $('.textbox.focus.dark').eq(4).val() != "") {
            $('.button.dark.minha-conta').removeAttr('disabled');
            $('.button.dark.minha-conta').removeClass('disabled');
            $('.button.dark.minha-conta').attr('value', 'Salvar');
        }
        else {
            $('.button.dark.minha-conta').attr('disabled');
            $('.button.dark.minha-conta').addClass('disabled');
            $('.button.dark.minha-conta').attr('value', 'Salvo');
        }

    });
});



//funcao do placeholder
function placehoderStay(index) {
    var id = $('.textbox-type3').eq(index).val();
    if (id != "") {
        $('.overflow-type3').eq(index).children('p').addClass('stay');
    }
    if (id == "") {
        $('.overflow-type3').eq(index).children('p').removeClass('stay');
    }
}