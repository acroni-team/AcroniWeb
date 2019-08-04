$(document).ready(function () {

    $(".textbox.focus").keyup(function () {
        if ($(this).val().length == 9) {
            //adiciona o loader aqui
            var txt = $(this);
            $.ajax({
                type: "POST",
                url: "loja.aspx/calcularFrete",
                data: '{cep: "' + $(this).val() + '", id: "' + $(this).attr('data-idProduto') + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    txt.next().next().children('span:nth-child(2)').text((parseFloat(txt.attr('data-precoBase')) + parseFloat(data.d)).toFixed(2).replace(".", ","));
                },
                error: function (msg) {
                    alert("Não foi possível calcular o frete :/");
                },
                complete: function () {
                    //retira aqui
                }
            });
        }
    });
});
