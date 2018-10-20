
if (!$('#ContentPlaceHolder1_txtNome').hasClass('aparece')) {
    history.pushState(null, null, location.href);
    window.onpopstate = function () {
        history.go(1);
    };
}