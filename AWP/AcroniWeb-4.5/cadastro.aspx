<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="cadastro.aspx.cs" Inherits="AcroniWeb_4._5.cadastro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/area-restrita.css" rel="stylesheet" />
    <script src="js/jquery.mask.min.js"></script>
    <script src="js/angular.min.js"></script>
    <script src="js/masks.js"></script>
    <script src="js/verificaSenha.js"></script>
</asp:Content>

<asp:Content ID="menu" ContentPlaceHolderID="menu" runat="server">
    <div id="logotext">
       <a href="default.aspx" id="logoacr" style="color:#0093ff">Acroni</a>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="m-div" ng-app="acroni">
        <div id="padrao" ng-controller="validaSenha" class="section section--fadeIn">
            <div class="modal-wrap" id="modal" runat="server">
                <div class="modal-overflow modal-overflow-alt hidden" id="overflow" runat="server">
                    <div class="modal-body modal-body-step1 modal-body-alt modal-body-cad is-showing animate-first-in" id="modalcad" runat="server">
                        <h1>Só precisamos confirmar que é você mesmo.</h1>
                        <p>A gente te enviou um código no e-mail. Cuidado pra não errar.</p>
                        <input type="button" class="button dark modal-button-cad modal-alt-button" value="Entendi" />
                    </div>
                </div>
                <div class="modal-background fadeIn" runat="server" id="modalback"></div>
            </div>
            <div class="btn-preencher"></div>
            <div class="cad-wraper">
                <div class="step-error-wrapper">
                    <div class="step" runat="server" id="step">
                        <div></div>
                        <div></div>
                        <div></div>
                        <div></div>
                        <div></div>
                        <div></div>
                    </div>
                    <asp:Label ID="lblErro" runat="server" class="erro" Text=""></asp:Label>
                </div>
                <div id="border" runat="server" class="textbox-type2-overflow overflow-cad">
                    <asp:TextBox ID="txtNome" ng-model="nome" ng-change="mudaCor()" runat="server" type="text" class="textbox textbox-type2 textbox-cad aparece" placeholder="Digite seu Nome Completo" autocomplete="off"></asp:TextBox>
                    <asp:TextBox ID="txtUsu" ng-model="usu" ng-change="mudaCor()" runat="server" type="text" class="textbox textbox-type2 textbox-cad" placeholder="Digite o nome de usuário desejado" autocomplete="off"></asp:TextBox>
                    <asp:TextBox ID="txtEmail" ng-model="email" ng-change="mudaCor()" runat="server" type="text" class="textbox textbox-type2 textbox-cad" placeholder="Digite o seu email :D" autocomplete="off"></asp:TextBox>
                    <asp:TextBox ID="txtCodigo" ng-model="cod" ng-change="mudaCor()" runat="server" type="text" class="textbox textbox-type2 textbox-cad" placeholder="Digite o seu código" autocomplete="off"></asp:TextBox>
                    <asp:TextBox ID="txtCpf" ng-model="cpf" ng-change="mudaCor()" runat="server" type="text" class="textbox textbox-type2 textbox-cad" placeholder="Digite seu CPF" autocomplete="off"></asp:TextBox>
                    <asp:TextBox ng-model="senha" TextMode="Password" ng-change="mudaCor()" ID="txtSenha" runat="server" type="text" class="textbox textbox-type2 textbox-cad" placeholder="Digite sua melhor senha :D" autocomplete="off"></asp:TextBox>
                    <asp:TextBox ID="txtCSenha" ng-model="csenha" ng-change="mudaCor()" TextMode="Password" runat="server" type="text" class="textbox textbox-type2 textbox-cad" placeholder="Confirmar sua Senha" autocomplete="off"></asp:TextBox>
                    <asp:Button ID="btnValida" class="button dark button-type2 button-cad disableded" style="background-size: 100%;" runat="server" Text="" OnClick="btnValida_Click" OnClientClick="loader('.lds-ellipsis','.button-cad');" disabled/>
                    
                </div>
            </div>
            <asp:Button ID="ReenviarEmail" runat="server" Text="Reenviar Email" OnClientClick="loader('.lds-ellipsis','.button-cad');" OnClick="ReenviarEmail_Click" CssClass="ReenviarEmail" />
            <div class="cad-msg">
                <br />
                <asp:Label ID="lblH1Dica" CssClass="h1dica" runat="server" Text="Hey!"></asp:Label> <br />                
                <asp:Label ID="lblDica" CssClass="dica" runat="server" Text="Você está prestes a entrar pra família Acroni!"></asp:Label>
            </div>
        </div>
        <div id="info">
        </div>
    </div>
    <script>
        document.getElementById("cadastro").classList.add("active");
        document.getElementById("logoacr").style.color = "#959595";
    </script>
    <script src="js/disableBackButton.js"></script>

</asp:Content>
