var logado = angular.module("cartao", []);
var controllers = {};

controllers.ctrl = function ($scope) {
    $scope.verificarCartao = function ($event) {
        var n = $('.cartaozinho').val();
        if (n.length >= 12) {
            if (luhn(n)) {
                n = n.replace(/ /g, '');
                if (n.length == 15) {
                    if (n.substring(0, 2) == "34" || n.substring(0, 2) == "37") {
                        $('#ContentPlaceHolder1_imgCards').attr('src', '../assets/img/pagamento/amex.png');
                        $('#ContentPlaceHolder1_imgCards').attr('class', 'bandeira');
                    } else {
                        alert("n pode esse n cara");
                    }
                } else if (n.length == 16) {
                    var r = new RegExp("^4011|438935|45(1416|76)|50(4175|6699|67|90[4-7])|63(6297|6368)");
                    if (r.test(n)) {
                        $('#ContentPlaceHolder1_imgCards').attr('src', '../assets/img/pagamento/elo.png');
                        $('#ContentPlaceHolder1_imgCards').attr('class', 'bandeira');
                    } else if (n.charAt(0) == '5') {
                        $('#ContentPlaceHolder1_imgCards').attr('src', '../assets/img/pagamento/master.png');
                        $('#ContentPlaceHolder1_imgCards').attr('class', 'bandeira');
                    } else if (n.charAt(0) == '4') {
                        $('#ContentPlaceHolder1_imgCards').attr('src', '../assets/img/pagamento/visa.png');
                        $('#ContentPlaceHolder1_imgCards').attr('class', 'bandeira');
                    }
                }
            } else {
                $('#ContentPlaceHolder1_imgCards').attr('src', '../assets/img/pagamento/cc.png');
                $('#ContentPlaceHolder1_imgCards').removeClass('bandeira');
            }
        } else {
            $('#ContentPlaceHolder1_imgCards').attr('src', '../assets/img/pagamento/cc.png');
            $('#ContentPlaceHolder1_imgCards').removeClass('bandeira');
        }
    }
}


logado.controller(controllers);

function luhn(value) {
    if (/[^0-9-\s]+/.test(value)) return false;
    var nCheck = 0, nDigit = 0, bEven = false;
    value = value.replace(/\D/g, "");
    for (var n = value.length - 1; n >= 0; n--) {
        var cDigit = value.charAt(n),
        nDigit = parseInt(cDigit, 10);
        if (bEven) {
            if ((nDigit *= 2) > 9) nDigit -= 9;
        }
        nCheck += nDigit;
        bEven = !bEven;
    }
    return (nCheck % 10) == 0; 
}