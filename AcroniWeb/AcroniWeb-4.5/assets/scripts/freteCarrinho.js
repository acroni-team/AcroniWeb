$('#freteCarrinho').on('click', function () {
    $.ajax({
        type: "POST",
        url: "loja.aspx/calcularFrete",
        data: '{cep: "' + $('#ContentPlaceHolder1_txtFrete').val() + '", id: "' + $('.btn-delete.material-icons').eq(0).attr('value') + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $('.freteCarrinho').text("R$" + String(data.d).replace(".", ","));
        },
        error: function (msg) {
            alert("Não foi possível calcular o frete :/");
        },
        complete: function () {
            //retira aqui
        }
    });
});


