<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="AcroniWeb._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" type="text/css" href="css/default.css" />
    <script type="text/javascript" src="js/tema.js"></script>

    <script>
        // loadando o codigo do IFrame Player API.
        var tag = document.createElement('script');

        tag.src = "https://www.youtube.com/iframe_api";
        var firstScriptTag = document.getElementsByTagName('script')[0];
        firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);

        // Creando um Iframe apartir do div com id = var.
        var player;
        function onYouTubeIframeAPIReady() {
            player = new YT.Player('player', {
                height: '100%',
                width: '100%',
                videoId: 'vfCozg8Yhxk',
                playerVars: { 'autoplay': 1 },
                events: {
                    'onReady': onPlayerReady
                }
            });
        }



        // API chama a função assim que o player termina de ser carregado.
        function onPlayerReady(event) {
            player.setPlaybackRate(1);

        }

    </script>

       <script type="text/javascript">
        $(window).on('load', function () {

            $('.preload').addClass('completo');

            //$('.item').each(function (i) {
            //setTimeout(function () {
            //$('.item').eq(i).addClass('visivel');

            // }, 100 * i);

            // });

        });

    </script>

</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="preload">
        <%--<div class="anima">
            <div class="item"></div>
            <div class="item"></div>
            <div class="item"></div>
            <div class="item"></div>
            <div class="item"></div>
            <div class="item"></div>
        </div>--%>
        <p class="logo animado">Acroni</p>
    </div>
    
    <div id="main" class="m-div">
        <div class="troca troca--fadeIn">
    </div>

        <section id="lsection" class="section section--fadeIn">
            <div>
                <h1>Acroni </h1>
                <br />
                <p>Mais que um teclado. O seu.</p>
                <div id="buttons">
                    <asp:Button class="blue" runat="server" Text="Fale conosco" OnClick="alo"  />
                    <!-- <asp:Button id="muda" class="blue" runat="server"  Text="Teclados mecânicos" ClientIDMode="Static" OnClientClick="return false"/>  <!-- OnClientClick="return false;">   ClientIDMode="Static" OnClientClick="return false;-->
                    <a href="default-dark.aspx"><div id="mud" class="blue">
                        <h3 id="fold_p">Teclados mecânicos</h3>
                    </div></a>
                </div>

                <div id="player"></div>
            </div>
        </section>
        <section id="rsection" class="section section--fadeIn">
            <div>
                <img src="img/apple.png" id="img" />
            </div>
        </section>
    <section id="facilidade">
        <h2 class="title-subsection light">Facilidade</h2>
        <p class="desc desc-facilidade first">Já pensou em ter um teclado que você sente que é só seu? Fazer tudo isso é mais fácil do que você pensa, e vem com um prazer a mais, o de poder dizer orgulhosamente que foi elaborado por você.</p>
        <p class="desc desc-facilidade">Na Acroni seu desejo pode ser realizado. Com o nosso software você poderá fazer tudo que imaginava para o teclado dos sonhos sem sair do conforto do seu computador.</p>
    </section>
    <section class="same-height" id="tamanhos">
        <div class="lsection">
            <img id="dois-teclados" src="img/dois-teclados.png" alt="Alternate Text" />
        </div>
        <div class="rsection">
            <h2 class="title-subsection dark tamanhos">Tamanhos para todos</h2>
            <br />
            <p class="desc desc-tamanhos">Aqui você escolhe o tamanho de teclado que mais combina com você e que melhor cabe em sua mesa.</p>
            <asp:Button ID="btnComeceJa" class="blue btn-comece-ja" runat="server" Text="Começe já" />
        </div>
    </section>
    <section class="same-height" id="escolha-cor">
        <div class="lsection-escolha section-white">
            <h2 class="title-subsection title-escolha">Escolha a sua cor</h2>
            <p class="desc escolha">Escolha suas cores preferidas para criar um teclado único, elaborado por você.</p>
            <p class="desc escolha">Nosso software oferece a customização de forma fácil e rápida. Em apenas alguns minutos você conseguirá criar o teclado dos seus sonhos.</p>
        </div>
        <div class="rsection-escolha section-white">
            <img src="img/demo-acroni.jpg" id="demo-acroni" alt="Alternate Text" />
        </div>
    </section>
    <footer id="footi">
        <div id="div-logo">
            <h1 id="logo-footer">Acroni</h1>
            <p id="subtitulo-logo-footer">Construindo o seu teclado</p>
        </div>
        <hr class="divisor"/>
        <div id="menu-footer">
            <ul id="menu-lista">
                <li><a href="#">Fale Conosco</a></li>
                <li><a href="#">Sobre a Acroni</a></li>
                <li><a href="#">Unidades</a></li>
            </ul>
        </div>
    </footer>
    </div>
    <script>
        document.getElementById("home").classList.add("active");
    </script>
    <script type="text/javascript" src="js/jquery.smoothState.js"></script>
    <script type="text/javascript" src="js/transition.js"></script>

</asp:Content>
