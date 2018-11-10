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

controllers.validaSenha = function($scope) {
    $scope.senha = "";
    $scope.mensagem = "";
    $scope.verificar = function() {
        lengthValidator($scope.senha);
        capitalValidator($scope.senha);
        lowercaseValidator($scope.senha);
        numberValidator($scope.senha);
        symbolValidator($scope.senha);

        var i = 0;

        function contarOp(element) {
            if(element) {
                i += 1;
            }
        }

        var bar = document.querySelector('.grow-bar');

        qtdVal.forEach(contarOp);

        if (i == 0) {
            bar.style.transform = "translateX(-450px)";
            $scope.mensagem = "";
        }
        else if (i == 1) {
            bar.style.transform = "translateX(-360px)";
            bar.style.background = "red";
            $scope.mensagem = "Muito fraca"; 
        }
        else if (i == 2) {
            bar.style.transform = "translateX(-270px)";
            bar.style.background = "orange";
            $scope.mensagem = "Continua fraca";
        }
        else if (i == 3) {
            bar.style.transform = "translateX(-180px)";
            $scope.mensagem = "Podia ser melhor";
            bar.style.background = "yellow";
        }
        else if (i == 4) {
            bar.style.transform = "translateX(-90px)";
            $scope.mensagem = "Tá ficando bom";
            bar.style.background = "green";
        }
        else {
            bar.style.transform = "translateX(0px)";
            $scope.mensagem = "Perfeitinha, atingiu";
            bar.style.background = "#0093ff";
        }
        
    };
    
}

acroni.controller(controllers);