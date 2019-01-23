<%@ Page Title="" Language="C#" MasterPageFile="~/logado.Master" AutoEventWireup="true" CodeBehind="minha-conta.aspx.cs" Inherits="AcroniWeb_4._5.editar_conta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnValidaEmail">
    <div class="modal-wrap minha-conta" id="modal" runat="server">
        <div class="modal-overflow modal-overflow-alt hidden" id="overflow" runat="server">
            <div class="modal-body modal-body-step1 modal-body-alt is-showing animate-first-in" id="modalcad" runat="server">
                <img style="width: 150px;" alt="icone-erro" src="assets/img/error-icon.png" />
                <asp:Label ID="titleErro" class="h1-modal" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="msgErro" class="p-modal" runat="server" Text="Label"></asp:Label>
                <asp:TextBox ID="txtValidaEmail" runat="server" class="textbox focus dark"></asp:TextBox>
                <asp:Button ID="btnValidaEmail" runat="server" Text="Entendi" class="button dark modal-button-cad modal-alt-button btn-valida" OnClick="btnValidaEmail_Click" />
                <input id="button" runat="server" type="button" class="button dark modal-button-cad modal-alt-button btn-fecha" style="float:initial" value="Entendi" />
                <asp:Button ID="btnReload" runat="server" Text="Entendi" class="button dark modal-button-cad modal-alt-button btn-fecha" style="display:none;" OnClick="btnReload_Click" />
            </div>
        </div>
        <div class="modal-background fadeIn" runat="server" id="modalback"></div>
    </div>
    </asp:Panel>
    <div class="right right-logado right-minha-conta" ng-app="logado">
        <div id="cabecalho">
            <h1>Editar os meus dados pessoais</h1>
        </div>
        <asp:Panel ID="Panel2" runat="server" DefaultButton="btnSalva">
        <div style="margin-top: 30px;" ng-controller="ctrl">
            <div class="minha-conta-forms">
                <div id="informacoes-basicas">
                    <h1>Informações básicas </h1>
                    <div class="textbox-overflow">
                        <asp:TextBox ID="Nome" ng-change="mudaCor()" ng-model="nomeCompleto" runat="server" class="textbox focus dark"></asp:TextBox>
                        <asp:Label ID="lblNome" class="p" runat="server" Text="Nome completo"></asp:Label>
                    </div>
                    <div class="textbox-overflow">
                        <asp:TextBox ID="CPF" ng-change="mudaCor()" ng-model="cpf" runat="server" class="textbox focus dark"></asp:TextBox>
                        <asp:Label ID="lblCPF" class="p" runat="server" Text="CPF"></asp:Label>
                    </div>
                    <div class="textbox-overflow">
                        <asp:TextBox ID="CEP" ng-change="mudaCor()" ng-model="cep" runat="server" class="textbox focus dark"></asp:TextBox>
                        <asp:Label ID="lblCEP" class="p" runat="server" Text="CEP"></asp:Label>
                    </div>
                </div>
                <div id="credenciais">
                    <h1>Credenciais </h1>
                    <div class="textbox-overflow">
                        <asp:TextBox ID="Email" ng-change="mudaCor()" ng-model="email" runat="server" class="textbox focus dark"></asp:TextBox>
                        <asp:Label ID="lblEmail" class="p" runat="server" Text="Email"></asp:Label>
                    </div>
                    <div class="textbox-overflow">
                        <asp:TextBox ID="Usuario" ng-change="mudaCor()" ng-model="usuario" runat="server" class="textbox focus dark"></asp:TextBox>
                        <asp:Label ID="lblUsuario" class="p" runat="server" Text="Usuario"></asp:Label>
                    </div>
                    <div class="textbox-overflow">
                        <asp:TextBox ID="Senha" ng-change="mudaCor()" ng-model="senha" runat="server" class="textbox focus dark" type="password"></asp:TextBox>
                        <asp:Label ID="lblSenha" class="p" runat="server" Text="Senha"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="separa"></div>
            <div id="foto-pricing">
                <h1>Foto e Pricing </h1>
                <div id="foto-pricing-conteudo">
                    <div class="foto">
                        <figure>
                            <figcaption class="uploadaimg">
                                <asp:FileUpload ID="FileUpload1" CssClass="upload-imagem" onchange="loadFile(event);" ng-upload-change="mudaCor($event)" ng-model="img" runat="server" accept="image/*" />
                                <label class="alteraimg">ALTERAR</label>
                            </figcaption>
                            <asp:Image ID="fotoPerfil" runat="server" ImageUrl='assets/img/imgperf.jpeg' ImageAlign="Middle" />
                        </figure>
                    </div>
                    <div class="plano">
                        <p>Você está usando o seguinte plano:</p>
                        <h1>Básico</h1>
                        <div class="info-plano">
                            <ul>
                                <li>Coleções ilimitadas;</li>
                                <li>Teclados ilimitados;</li>
                                <li>Registro de 1 cartão de crédito;</li>
                                <li>Customização basica</li>
                            </ul>
                        </div>
                        <asp:Button ID="btnAlteraPlano" runat="server" Text="Alterar Plano" class="button-alt dark minha-conta" OnClick="btnAltera_Click" />
                        <asp:Button ID="btnExcluiConta" runat="server" Text="Apagar conta" class="button-alt dark minha-conta" OnClick="btnExcluiConta_Click" />
                    </div>
                    <div class="lds-ellipsis lds-minha-conta"><div></div><div></div><div></div><div></div></div>
                </div>
            </div>
            <asp:Button ID="btnSalva" runat="server" Text="Salvo" class="button dark minha-conta disabled" OnClientClick="loader('.lds-minha-conta','.button.minha-conta');" OnClick="btnSalva_Click" disabled />
            
        </div>
        </asp:Panel>
    </div>
    <script>
        document.getElementById("minha-conta").classList.add("active");
    </script>
</asp:Content>
