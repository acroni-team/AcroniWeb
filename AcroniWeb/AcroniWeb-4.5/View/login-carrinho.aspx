<%@ Page Title="" Language="C#" MasterPageFile="~/View/layout.Master" AutoEventWireup="true" CodeBehind="login-carrinho.aspx.cs" Inherits="AcroniWeb_4._5.View.login_carrinho" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu" runat="server">
    <div id="logotext">
       <a href="default.aspx" id="logoacr" runat="server" style="color:#0093ff">Acroni</a>
    </div>
   <ul id="menu-items">
        <li><a id="loja" href="loja.aspx">Loja</a></li>
        <%--<li><a id="cadastro" href="cadastro.aspx">Cadastrar</a></li>--%>
   </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="m-div carrinho login-carrinho">
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

        <!--    Login    -->
        <div id="login" class="section section-animate section--fadeIn">
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
                    <p id="cadastre-se">Ainda não tem conta? <a href="cadastro.aspx?compra=1" class="link">Crie uma!</a></p>
                    </asp:Panel>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
			</form>
        </div>



    </div>
</asp:Content>
