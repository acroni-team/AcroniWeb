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
                    $scope.mensagem = "Vamos lá, você consegue melhorar isso.";
                }
                else if (i == 2) {
                    bordinha.style.borderColor = "#E29400";
                    bordinha.style.color = "#E29400";
                    $scope.mensagem = "Não é a senha dos sonhos, mas...";
                }
                else if (i == 3) {
                    bordinha.style.borderColor = "#D5CD00";
                    bordinha.style.color = "#D5CD00";
                    $scope.mensagem = "Existem senhas mais fortes.";
                }
                else if (i == 4) {
                    bordinha.style.borderColor = "#00ff6b";
                    bordinha.style.color = "#00ff6b";
                    $scope.mensagem = "Já é o sufuciente por aqui.";
                }
                else if (i == 5) {
                    bordinha.style.borderColor = "#0093ff";
                    bordinha.style.color = "#0093ff";
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
            $scope.mensagem = "";
        }
    }

}

acroni.controller(controllers);