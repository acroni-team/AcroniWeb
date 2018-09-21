<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="cadastro.aspx.cs" Inherits="AcroniWeb_4._5.cadastro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script src="js/jquery.mask.min.js"></script>
    <script src="js/angular.min.js"></script>
    <script src="js/cadastro.js"></script>
    <script src="js/verificaSenha.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div id="padrao" ng-controller="validaSenha">
        <div class="cad-wraper">
            <div class="textbox-type2-overflow overflow-cad">
               <asp:TextBox  ID="txtNome" runat="server" type="text" class="textbox textbox-type2 textbox-cad aparece" placeholder="Nome Completo" autocomplete="off"></asp:TextBox>
               <asp:TextBox  ID="txtUsu" runat="server" type="text" class="textbox textbox-type2 textbox-cad" placeholder="Usuário" autocomplete="off"></asp:TextBox>
               <asp:TextBox  ID="txtEmail" runat="server" type="text" class="textbox textbox-type2 textbox-cad" placeholder="Digite o seu email :D" autocomplete="off"></asp:TextBox>
               <asp:TextBox  ID="txtCodigo" runat="server" type="text" class="textbox textbox-type2 textbox-cad" placeholder="Enviamos um código no seu email" autocomplete="off"></asp:TextBox>
               <asp:TextBox  ID="txtCpf" runat="server" type="text" class="textbox textbox-type2 textbox-cad" placeholder="CPF" autocomplete="off"></asp:TextBox>
               <asp:TextBox ng-model="senha" TextMode="Password" ng-change="verificar()" ID="txtSenha" runat="server" type="text" class="textbox textbox-type2 textbox-cad" placeholder="Senha" autocomplete="off"></asp:TextBox>
               <asp:TextBox  ID="txtCSenha" TextMode="Password" runat="server" type="text" class="textbox textbox-type2 textbox-cad" placeholder="Confirmar Senha" autocomplete="off"></asp:TextBox>
               <asp:Button ID="btnValida" class="button dark button-type2 button-cad" runat="server" Text="Enviar" OnClick="btnValida_Click"/>
            </div>
        </div>
        <div id="erro">
            <asp:Label ID="lblErro" runat="server" Text=""></asp:Label><br/>
            <asp:Label ng-bind="mensagem" ID="lblNivelSenha" runat="server" Text=""></asp:Label><br/>
            <asp:Label ID="lblDica" CssClass="dica" runat="server" Text=""></asp:Label>
        </div>
        <div id="info">

        </div>
    </div>
</asp:Content>
