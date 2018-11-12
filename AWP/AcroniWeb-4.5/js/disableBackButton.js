
if (!$('#ContentPlaceHolder1_txtNome').hasClass('aparece')) {
    history.pushState(null, null, location.href);
    window.onpopstate = function () {
        history.go(1);
    };
}

$('.btn-preencher').click(function () {
    $('.textbox').eq(0).val("Emanuel Ruan Nathan Barros");
    $('.textbox').eq(1).val("emanuel01");
    $('.textbox').eq(2).val("emanuelruan165@gmail.com");
    $('.textbox').eq(4).val("025.471.988-00");
    const btnSalva = document.getElementById('ContentPlaceHolder1_btnValida');
    btnSalva.classList.remove("disableded");
    btnSalva.classList.add("button-cad-next");
    btnSalva.disabled = false;
});