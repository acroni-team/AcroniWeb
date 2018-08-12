<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="AcroniWeb._default1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://unpkg.com/aos@2.3.1/dist/aos.css" rel="stylesheet" />
    <script type="text/javascript" src="js/preload.js"></script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--        Preloader       -->
     <div class="preload">
        <p class="logo animado">Acroni</p>
    </div>

    <section>
        <div id="principal">
            <div data-aos="fade-up" data-aos-delay="300">
                <h1>Compre teclados de marcas famosas ou crie o seu.</h1>
                <p>obtenha uma conta agora e tenha acesso à nossa plataforma completa, de graça.</p>
                <div id="player"></div>
            </div>
        </div>
        <div id="login">
            <form  method="post">
				<div class="centraliza" data-aos="fade-up" data-aos-delay="300">
                    <div>
					<p>Entrar</p>
					<asp:Label runat="server" Text="Entre com sua conta para ter acesso total ao site" id="lblMsg"></asp:Label>
                    </div>
                    <div class="centralizalogin" style="width: 99%;">
					   <asp:Textbox id="txtUsu" class="caixxinha" type="text" placeholder="Usuário" spellcheck="false" required runat="server"></asp:Textbox>
					   <asp:Textbox id="txtPass" class="caixxinha" type="password" placeholder="Senha" spellcheck="false" required runat="server"></asp:Textbox>
                    </div>
                    <div class="centralizabotao" style="width: 100%;">
					   <asp:Button ID="btnEntra" class="blue dark" type="button" Text="Me deixa entrar!" runat="server" OnClick="btnEntra_Click" />  
                    </div>
                    <p id="cadastre-se">Ainda não tem conta? <a>Crie uma!</a></p>
                </div>
			</form>

        </div>

    </section>

    <section id="facilidade">
        <h2 data-aos="fade-up" data-aos-delay="50" data-aos-duration="800" data-aos-easing="ease-out-cubic" class="title-subsection light">Faxcility</h2>
        <p data-aos="fade-up" data-aos-delay="60" data-aos-duration="800" data-aos-easing="ease-out-cubic" class="desc desc-facilidade first">Já pensou em ter um teclado que você sente que é só seu? Fazer tudo isso é mais fácil do que você pensa, e vem com um prazer a mais, o de poder dizer orgulhosamente que foi elaborado por você.</p>
        <p data-aos="fade-up" data-aos-delay="60" data-aos-duration="800" data-aos-easing="ease-out-cubic" class="desc desc-facilidade">Na Acroni seu desejo pode ser realizado. Com o nosso software você poderá fazer tudo que imaginava para o teclado dos sonhos sem sair do conforto do seu computador.</p>
    </section>
    <section class="same-height" id="tamanhos">
        <div class="lsection">
            <img id="dois-teclados" src="img/dois-teclados.png" alt="Alternate Text" />
        </div>
        <div class="rsection">
            <h2 data-aos="fade-up" data-aos-delay="50" data-aos-duration="800" data-aos-easing="ease-out-cubic" class="title-subsection dark tamanhos">Tamanhos para todos</h2>
            <br />
            <p data-aos="fade-up" data-aos-delay="60" data-aos-duration="800" data-aos-easing="ease-out-cubic" class="desc desc-tamanhos">Aqui você escolhe o tamanho de teclado que mais combina com você e que melhor cabe em sua mesa.</p>
            <asp:Button data-aos="fade-up" data-aos-delay="60" data-aos-duration="800" data-aos-easing="ease-out-cubic" ID="btnComeceJa" class="blue btn-comece-ja" runat="server" Text="Começe já" />
        </div>
    </section>
    <section class="same-height" id="escolha-cor">
        <div class="lsection-escolha section-white">
            <h2 data-aos="fade-up" data-aos-delay="50" data-aos-duration="800" data-aos-easing="ease-out-cubic" class="title-subsection title-escolha">Escolha a sua cor</h2>
            <p data-aos="fade-up" data-aos-delay="60" data-aos-duration="800" data-aos-easing="ease-out-cubic" class="desc escolha">Escolha suas cores preferidas para criar um teclado único, elaborado por você.</p>
            <p data-aos="fade-up" data-aos-delay="60" data-aos-duration="800" data-aos-easing="ease-out-cubic" class="desc escolha">Nosso software oferece a customização de forma fácil e rápida. Em apenas alguns minutos você conseguirá criar o teclado dos seus sonhos.</p>
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

    <!--                            Scripts                      -->

    <script>
        document.getElementById("home").classList.add("active");
    </script>
    <script type="text/javascript" src="js/jquery.smoothState.js"></script>
    <script type="text/javascript" src="js/transition.js"></script>
    <script src="https://unpkg.com/aos@next/dist/aos.js"></script>
    <script>
        AOS.init();
    </script>

</asp:Content>
