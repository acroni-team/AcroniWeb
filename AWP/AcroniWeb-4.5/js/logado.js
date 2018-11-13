var loadFile = function (event) {
    const idFotoPerfil = document.getElementById('ContentPlaceHolder1_fotoPerfil');
    const idFotoPath = document.getElementById('ContentPlaceHolder1_FileUpload1');
    var allowedExtensions = /(\.jpg|\.jpeg|\.png|\.gif|\.tiff|\.bmp)$/i;
    var filePath = idFotoPath.value;

    if (allowedExtensions.exec(filePath)) {
        idFotoPerfil.src = URL.createObjectURL(event.target.files[0]);
        $('.btn-enable-salvar').click();
    }

};

$(document).ready(function () {

    $("#ContentPlaceHolder1_CPF").mask('000.000.000-00');
    $("#ContentPlaceHolder1_CEP").mask('00000-000');

    $('.upload-imagem').change(function () {
        if ($('.upload-imagem').val() != "") {
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

var logado = angular.module("logado", []);

angular.module("logado").directive("ngUploadChange", function () {
    return {
        scope: {
            ngUploadChange: "&"
        },
        link: function ($scope, $element, $attrs) {
            $element.on("change", function (event) {
                $scope.$apply(function () {
                    $scope.ngUploadChange({ $event: event })
                })
            })
            $scope.$on("$destroy", function () {
                $element.off();
            });
        }
    }
});

var controllers = {};

controllers.ctrl = function ($scope) {
    $scope.mudaCor = function ($event) {
        var btnSalva = document.getElementById('ContentPlaceHolder1_btnSalva');
        if (document.querySelectorAll('.textbox.focus.dark')[1].value != "" ||
            document.querySelectorAll('.textbox.focus.dark')[2].value != "" ||
            document.querySelectorAll('.textbox.focus.dark')[3].value != "" ||
            document.querySelectorAll('.textbox.focus.dark')[4].value != "" ||
            document.querySelectorAll('.textbox.focus.dark')[5].value != "" ||
            document.querySelectorAll('.textbox.focus.dark')[6].value != "" ) {
            btnSalva.classList.remove("disabled");
            btnSalva.setAttribute("value", "Salvar");
            btnSalva.disabled = false;
        }
        else {
            btnSalva.classList.add("disabled");
            btnSalva.setAttribute("value", "Salvo");
            btnSalva.disabled = true;
        }
    }
}

logado.controller(controllers);

function placehoderStay(index) {
    var id = $('.textbox-type3').eq(index).val();
    if (id != "") {
        $('.overflow-type3').eq(index).children('.p').addClass('stay');
    }
    if (id == "") {
        $('.overflow-type3').eq(index).children('.p').removeClass('stay');
    }
}