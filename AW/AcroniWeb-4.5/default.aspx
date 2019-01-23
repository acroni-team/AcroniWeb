<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="AcroniWeb._default1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://unpkg.com/aos@2.3.1/dist/aos.css" rel="stylesheet" />
    <script src="js/acroniPlayer.js"></script>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
</asp:Content>

<asp:Content ID="menu" ContentPlaceHolderID="menu" runat="server">
    <div id="logotext">
       <a href="#principal" id="logoacr">Acroni</a>
    </div>

    <ul id="menu-items">
        <li><a id="sobre" href="#video">Sobre</a></li>
        <li><a id="bem-vindo-vai" href="loja.aspx">Loja</a></li>
        <li><a id="dowload" href="default.aspx#download" runat="server">Download</a></li>
        <li><a id="equipe" href="default.aspx#team" runat="server">Equipe</a></li>
        <%--<li><a id="fale-conosco" href="construct.aspx">Fale Conosco</a></li>--%>
<%--                <li><a id="cadastro" href="cadastro.aspx">Cadastrar</a></li>--%>
   </ul>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="main" class="m-div default">
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
                    <asp:Textbox id="txtSenha" class="textbox" type="password"  placeholder="Nova Senha" spellcheck="false" autocomplete="off" runat="server"></asp:Textbox>
                    <asp:Textbox id="txtCSenha" class="textbox" type="password"  placeholder="Confirmar Nova Senha" spellcheck="false" runat="server"></asp:Textbox>
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

    <section id="primeira">

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
                    <p id="abre-senha" class="link">Você esqueceu a sua senha?</p>
                    <p class="link link-sqn">Manter logado</p>
                    <asp:CheckBox ID="ckbLogin" class="checkbox" runat="server" />
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
                <asp:Button ID="BtnIrloja" runat="server" class="button dark button-eas" Text="Visite a loja" Onclick="BtnIrloja_Click"/>
            </div>
         </div>
    </section>    

    <!-- Terceira seção -->

    <section id="video">
        <div class="conteiner" data-aos="fade-up" data-aos-delay="300">
            <div class="c-video">
                <video class="video" src="video/Propaganda.mp4" id="videozinho" poster="assets/img/acroni.png"></video>
                <div class="play-button" onclick="toggleVideo();">
                    <i class="material-icons" id="play-pause"></i>
                    <%--<button id="play-pause" type="button" ></button>--%>
                    
                </div>
                <div class="controls-bar">
                   <div class="mute-button" onclick="toggleMute();">
                       <i class="material-icons" aria-label="Mute" id="mute-unmute"></i>
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
         <img alt="imagem do software de customização" src="/assets/img/pczinho.png" />
        <div class="align-text">
            <div class="text">
                <h1>Baixe agora o software.</h1>
                <p>Através do nosso programa pra desktop, você consegue fazer as customizações que deseja no seu teclado. O que está esperando?
                </p>
                <asp:Button ID="BtnDownload" runat="server" Text="Download" class="button dark button-eas" OnClick="BtnDownload_Click"/>
            </div>
         </div>
    </section>

     <!-- Quinta e Sexta seção -->
    <section id="planos">
        <div class="plan-box plan-basic">
            <header>
                <h1>Plano Básico</h1>
                <h3>Características</h3>
            </header>
            <ul>
                <li><p style="line-height: 5px;margin-bottom:20px">Acesso a 3 teclados<br/> customizados;</p></li>
                <li><p>Acesso a 5 coleções;</p></li>
                <li><p class="blue-left">Customização</p><p class="blue">limitada</p>;</li>
            </ul>

        </div>
        <div class="plan-box plan-premium">
            <header>
                <h1>Plano Premium</h1>
                <h3>Características</h3>
            </header>
            <ul>
                <li><p style="line-height: 5px;margin-bottom:20px">Acesso a 10 teclados<br/> customizados;</p></li>
                <li><p>Acesso a 15 coleções;</p></li>
                <li><p class="blue-left">Customização</p><p class="blue">completa</p>;</li>
                <li><p style="line-height: 5px;">Descontos exclusivos <br/> nos teclados da loja;</p></li>
            </ul>
            <asp:Button ID="btnPlano" runat="server" Text="Quero agora!" class="button dark button-gradient" disabled/>
        </div>
        
    </section>  
    
    <svg xmlns="http://www.w3.org/2000/svg" width="1920" height="253" viewBox="0 0 1920 253"><path d="M0,0V242.6c49.51,3.19,80.85-14.85,137.48-46.35,116.72-64.93,202.06-74.41,277.13,8.89S542.25,73,633,66s132.6,75.65,222.4,55.42S1068.51-31,1240.51,9.75s160.22,200.74,264.39,170.89,125.46-98.79,203.36-79.85c64.65,15.77,100.49,121.11,177.74,87a218.89,218.89,0,0,1,34-12V0Z" fill="#363942"/></svg>

    <section id="team">
        <h1>Equipe</h1>
        <p>Sem eles, a Acroni simplesmente não existiria.</p>
        <div class="team-members-wrapper">
            <div class="team-members-box">
                <figure>
                    <div>
                        <img alt="Felipi Yuri" src="assets/img/team/picepalm.jpg" />
                    </div>
                    <figcaption>
                        <h1>Felipi Yuri</h1>
                        <p>Desenvolvedor <br /> Desktop</p>
                    </figcaption>
                </figure>
            </div>
            <div class="team-members-box">
                  <figure>
                    <div>
                        <img alt="Felipi Figueira" src="assets/img/team/Fillers.jpg" />
                    </div>
                    <figcaption>
                        <h1>Felipi Figueira</h1>
                        <p>Designer</p>
                    </figcaption>
                </figure>
            </div>
            <div class="team-members-box">
                  <figure>
                    <div>
                        <img alt="Gabriel Braga" src="assets/img/team/Bragamen.jpg" />
                    </div>
                    <figcaption>
                        <h1>Gabriel Braga</h1>
                        <p>Desenvolvedor <br /> Desktop</p>
                    </figcaption>
                </figure>
            </div>
            <div class="team-members-box">
                  <figure>
                    <div>
                        <img alt="Guilherme Mota" src="assets/img/team/Moutinhas.jpg" />
                    </div>
                    <figcaption>
                        <h1>Guilherme Mota</h1>
                        <p>Desenvolvedor <br /> Desktop</p>
                    </figcaption>
                </figure>
            </div>
            <div class="team-members-box">
                 <figure>
                    <div>
                        <img alt="Gustavo Palma" src="assets/img/team/palmen.jpg" />
                    </div>
                    <figcaption>
                        <h1>Gustavo Palma</h1>
                        <p>Desenvolvedor <br /> Web</p>
                    </figcaption>
                </figure>
            </div>
            <div class="team-members-box">
                  <figure>
                    <div>
                        <img alt="Gustavo Pereira" src="assets/img/team/pezinho.jpg" />
                    </div>
                    <figcaption>
                        <h1>Gustavo Pereira</h1>
                        <p>Desenvolvedor <br /> Web</p>
                    </figcaption>
                </figure>
            </div>
        </div>
     </section>
    <section id="last-section"></section>               
    <!-- FOOTI -->

    <!--                            Scripts                      -->
   </div>
    <script>
        document.getElementById("home").classList.add("active");
    </script>
    <script src="https://unpkg.com/aos@next/dist/aos.js"></script>
    <script>
        AOS.init();
    </script>

</asp:Content>
