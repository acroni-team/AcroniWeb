<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="cadastro.aspx.cs" Inherits="AcroniWeb_4._5.cadastro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script src="js/jquery.mask.min.js"></script>
    <script src="js/angular.min.js"></script>
    <script src="js/cadastro.js"></script>
    <script src="js/verificaSenha.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div id="padrao" ng-controller="validaSenha">
        <div class="alinha">
            <div class="alinhado">
                <div class="alo">
                    <asp:Label ID="lblNome" runat="server" Text="Entre com seu nome completo" class="identifica aparece"></asp:Label>
                    <asp:TextBox  ID="txtNome" runat="server" type="text" class="caixa aparece" placeholder="Nome Completo" autocomplete="off" autofocus></asp:TextBox>
                    
                </div>
            </div>
        </div>
        <div class="alinha">
            <div class="alinhado">
                <div class="alo">
                    <asp:Label ID="lblUsu" runat="server" Text="Entre com seu nome de usuário" class="identifica"></asp:Label>
                    <asp:TextBox  ID="txtUsu" runat="server" type="text" class="caixa" placeholder="Usuario" autocomplete="off" autofocus></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="alinha">
            <div class="alinhado">
                <div class="alo">
                    <asp:Label ID="lblEmail" runat="server" Text="Entre com seu Email" class="identifica"></asp:Label>
                    <asp:TextBox  ID="txtEmail" runat="server" type="text" class="caixa" placeholder="Email" autocomplete="off" autofocus></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="alinha">
            <div class="alinhado">
                <div class="alo">
                    <asp:Label ID="lblCpf" runat="server" Text="Entre com seu CPF" class="identifica"></asp:Label>
                    <asp:TextBox  ID="txtCpf" runat="server" type="text" class="caixa" placeholder="CPF" autocomplete="off" autofocus></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="alinha">
            <div class="alinhado">
                <div class="alo">
                    <asp:Label ID="lblSenha" runat="server" Text="Entre com sua senha" class="identifica"></asp:Label>
                    <asp:TextBox ng-model="senha" TextMode="Password" ng-change="verificar()" ID="txtSenha" runat="server" type="text" class="caixa" placeholder="Senha" autocomplete="off" autofocus></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="alinha">
            <div class="alinhado">
                <div class="alo">
                    <asp:Label ID="lblCSenha" runat="server" Text="Confirme sua senha" class="identifica"></asp:Label>
                    <asp:TextBox  ID="txtCSenha" TextMode="Password" runat="server" type="text" class="caixa" placeholder="Confirmar Senha" autocomplete="off" autofocus></asp:TextBox>
                </div>
               <asp:Button ID="btnValida" class="bluev2" runat="server" Text=">" OnClick="btnValida_Click"/>
            </div>
        </div>
        <div id="erro">
            <asp:Label ID="lblErro" runat="server" Text=""></asp:Label><br/>
            <asp:Label ng-bind="mensagem" ID="lblNivelSenha" runat="server" Text=""></asp:Label><br/>
            <asp:Label ID="lblDica" runat="server" Text=""></asp:Label>
        </div>
        <div id="info">

        </div>
    </div>
</asp:Content>
