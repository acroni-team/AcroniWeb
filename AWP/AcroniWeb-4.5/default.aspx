<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="AcroniWeb._default1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://unpkg.com/aos@2.3.1/dist/aos.css" rel="stylesheet" />
    <script src="js/acroniPlayer.js"></script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="main" class="m-div">
    <!--        Preloader       -->
     <div class="preload">
        <p class="logo animado">Acroni</p>
    </div>

    <asp:ScriptManager ID="SCManager" runat="server" />
    
    <!--    Esqueceu a senha    -->
    <div class="modal-wrap" id="modal" runat="server">
      
        <asp:UpdatePanel ID="SCPanel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="modal-overflow hidden" id="overflow" runat="server">
                <asp:Panel DefaultButton="btnSendEmail" runat="server" ID="SendEmailPanel">
                <div class="modal-body modal-body-step1 is-showing animate-first-in" id="step1" runat="server">
                    <h1>Pode acontecer com qualquer um.</h1>
                    <p>Não esquenta,coloca seu email aqui em baixo que a gente resolve.</p>
                    <div class="textbox-type2-overflow eas-overflow">
                        <asp:Textbox id="txtEmail" class="textbox textbox-eas-2 textbox-type2" type="text" placeholder="nuncamaispercoasenha@example.com" autocomplete="off" spellcheck="false" runat="server"></asp:Textbox>
                        <asp:Button ID="btnSendEmail" runat="server" Text="Enviar" class="button dark button-type2" OnClick="btnSendEmail_Click" OnClientClick="loader('.lds-eas-1','.button-type2');"/>
                        <div class="lds-ellipsis lds-eas-1"><div></div><div></div><div></div><div></div></div>
                    </div>
                    <asp:Label runat="server" Text="" id="lblErro1"></asp:Label>
                 </div> 
                </asp:Panel>
                <asp:Panel DefaultButton="btnSendCode" runat="server" ID="SendCodePanel">
                <div class="modal-body modal-body-step2" id="step2" runat="server">
                    <h1>Só precisamos confirmar que é você mesmo.</h1>
                    <p>A gente te enviou um código no e-mail. Cuidado pra não errar.</p>
                    <div class="textbox-type2-overflow eas-overflow">
                        <asp:Textbox id="txtCodigo" class="textbox textbox-eas-2 textbox-type2" type="text" placeholder="Digite seu código" autocomplete="off" spellcheck="false" runat="server"></asp:Textbox>
                        <asp:Button ID="btnSendCode" runat="server" Text="Enviar" class="button dark button-type2" OnClick="btnSendCode_Click" OnClientClick="loader('.lds-eas-1','.button-type2');"/>
                        <div class="lds-ellipsis lds-eas-1"><div></div><div></div><div></div><div></div></div>
                    </div>
                    <asp:Label runat="server" Text="" id="lblErro2"></asp:Label>
                 </div>
                </asp:Panel>
                <asp:Panel DefaultButton="btnTrocaSenha" runat="server" ID="TrocaSenhaPanel">
                <div class="modal-body modal-body-step3" id="step3" runat="server">
                    <h1>Ótimo! Agora é só mudar sua senha.</h1>
                    <p>Esperamos que você consiga lembrar dessa.</p>
                    <asp:Textbox id="txtSenha" class="textbox" type="text"  placeholder="Nova Senha" spellcheck="false" autocomplete="off" runat="server"></asp:Textbox>
                    <asp:Textbox id="txtCSenha" class="textbox" type="text"  placeholder="Confirmar Nova Senha" spellcheck="false" runat="server"></asp:Textbox>
                    <asp:Button ID="btnTrocaSenha" runat="server" Text="Enviar" class="button dark button-eas-final" OnClick="btnTrocaSenha_Click"/>
                    <asp:Label runat="server" Text="" id="lblErro3"></asp:Label>
                 </div>
                 </asp:Panel>
            </div>
        </ContentTemplate>
        </asp:UpdatePanel>
      
        <div class="modal-background fadeIn"></div>

     </div>
    
    <!--    Primeira seção -->

    <section>

        <div id="principal" > 
            <div>
                <h1>Compre teclados de marcas famosas ou crie o seu.</h1>
                <h3>Obtenha uma conta agora - e tenha acesso à nossa plataforma <a> completa</a>, de graça.</h3>
                <div class="c-quadrado"></div>
            </div>
        </div>

        <div id="login" class="section section-animate section--fadeIn-right">
            <form id="loginform" method="post">               
				<div class="centraliza div--fadeIn">
                    <p id="abre-senha" class="link">Por acaso você esqueceu a senha?</p>
                    <asp:UpdatePanel ID="SCPanel"  runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                    <ContentTemplate>
                    <asp:Panel ID="LoginPanel" DefaultButton="btnEntra" runat="server">
                    <div>
					<p id="logintitle">Entrar</p>
					<asp:Label runat="server" Text="Relaxa, não vamos usar seus dados para o mal." id="lblMsg"></asp:Label>
                    </div>
                    <div class="login" style="width: 99%;">
					   <asp:Textbox id="txtUsu" class="textbox focus" type="text" placeholder="Email ou usuário" spellcheck="false" runat="server"></asp:Textbox>
					   <asp:Textbox id="txtPass" class="textbox focus" type="password" placeholder="Senha" spellcheck="false" runat="server"></asp:Textbox>
                       <asp:CheckBox ID="ckbLogin" class="checkbox" runat="server" />
                    </div>
                    <div class="centralizabotao" style="width: 100%;">
					   <asp:Button ID="btnEntra" class="button dark button-login" type="button" Text="Entrando!" OnClientClick="loader('.lds-login','.button-login');" runat="server" OnClick="btnEntra_Click" /> 
                       <div class="lds-ellipsis lds-login"><div></div><div></div><div></div><div></div></div>
                    </div>
                    <p id="cadastre-se">Ainda não tem conta? <a href="cadastro.aspx" class="link">Crie uma!</a></p>
                    </asp:Panel>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
			</form>
        </div>

        <div id="bg-img"></div>

    </section>

    <!-- Segunda seção -->
    
    <section id="bem-vindo">
  

        <div class="align-text">
            <div class="text">
                <h1>Bem-Vindo(a)!</h1>
                <p>Você está procuirando por teclados pro seu PC? Se não, eu tenho 
                    uma má notícia para te dar. Mas, se por um acaso você estiver a procura
                    de teclados diferentes, baratos e bonitos, então se liga:
                    A Acroni é especializada na fabricação de teclados <b>customizados</b>- O que
                    significa que todo teclado que você comprar aqui que seja da marca 
                    <b>Acroni</b> será inteiramente <b>feito por você</b>.
                </p>
                <a href="loja.aspx"><input type="button" value="Visite a loja" class="button dark button-eas" /></a>
            </div>
         </div>
    </section>    

    <!-- Terceira seção -->

    <section id="video">
        <div class="conteiner" data-aos="fade-up" data-aos-delay="300">
            <div class="c-video">
                <video class="video" src="video/Propaganda.mp4" id="videozinho" poster="img/acroni.png"></video>
                <div class="play-button" onclick="toggleVideo();">
                    <button id="play-pause" type="button" ></button>
                    
                </div>
                <div class="controls-bar">
                   <div class="mute-button" onclick="toggleMute();">
                       <button aria-label="Mute" id="mute-unmute" type="button" ></button>
                   </div>
                </div>
<%--                <div>
                    <h1>Vídeo promocional da Acroni</h1>
                    <p>Um vídeo Bon et'fácil da Acroni made in Fi.</p>
                </div>
                <div style="padding:56.25% 0 0 0;position:relative;"><iframe src="https://player.vimeo.com/video/287846455?color=0093ff&title=0&byline=0&portrait=0" style="position:absolute;top:0;left:0;width:100%;height:100%;" frameborder="0" webkitallowfullscreen mozallowfullscreen allowfullscreen></iframe></div><script src="https://player.vimeo.com/api/player.js"></script>--%>
            </div>
        </div>
         <div class="frase">
                <h1>"Nice"</h1>
                <p>-Michael Rosen</p> 
         </div>
    </section>
    
    <!-- Quarta seção -->

    <section id="download">
         <img alt="imagem do software de customização" src="../../img/pczinho.png" />
        <div class="align-text">
            <div class="text">
                <h1>Baixe agora o software.</h1>
                <p>Através do nosso programa pra desktop, você consegue fazer as customizações que deseja no seu teclado. O que está esperando?
                </p>
                <a href="loja.aspx"><input type="button" value="Download" class="button dark button-eas" /></a>
            </div>
         </div>
    </section>

    
    <!-- FOOTI -->

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
   </div>
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
