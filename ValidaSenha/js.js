window.onload = function() {

    const myInput = document.getElementById('psw');
    const resp = document.getElementById('resposta');
    
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

    myInput.addEventListener('keyup', (event) => {

        const password = myInput.value;
        lengthValidator(password);
        capitalValidator(password);
        lowercaseValidator(password);
        numberValidator(password);
        symbolValidator(password);
        
        var i = 0;

        function contarOp(element) {
            if(element) {
                i += 1;
            }
        }

        qtdVal.forEach(contarOp);
        resp.innerHTML = i;

    }, false);

};