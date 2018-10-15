<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="cadastro.aspx.cs" Inherits="AcroniWeb_4._5.cadastro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script src="js/jquery.mask.min.js"></script>
    <script src="js/angular.min.js"></script>
    <script src="js/masks.js"></script>
    <script src="js/verificaSenha.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="padrao" ng-controller="validaSenha">
        <div class="modal-wrap" id="modal" runat="server">
            <div class="modal-overflow modal-overflow-alt hidden" id="overflow" runat="server">
                 <div class="modal-body modal-body-step1 modal-body-alt modal-body-cad is-showing animate-first-in" id="modalcad" runat="server">
                    <h1>Só precisamos confirmar que é você mesmo.</h1>
                    <p>A gente te enviou um código no e-mail. Cuidado pra não errar.</p>
                    <input type="button" class="button dark modal-button-cad modal-alt-button" value="Entendi"/>
                </div> 
            </div>
            <div class="modal-background fadeIn" runat="server" id="modalback"></div>
         </div>
        <div class="cad-wraper">
            <div class="textbox-type2-overflow overflow-cad">
               <asp:TextBox  ID="txtNome" runat="server" type="text" class="textbox textbox-type2 textbox-cad aparece" placeholder="Nome Completo" autocomplete="off"></asp:TextBox>
               <asp:TextBox  ID="txtUsu" runat="server" type="text" class="textbox textbox-type2 textbox-cad" placeholder="Usuário" autocomplete="off"></asp:TextBox>
               <asp:TextBox  ID="txtEmail" runat="server" type="text" class="textbox textbox-type2 textbox-cad" placeholder="Digite o seu email :D" autocomplete="off"></asp:TextBox>
               <asp:TextBox  ID="txtCodigo" runat="server" type="text" class="textbox textbox-type2 textbox-cad" placeholder="Enviamos um código no seu email" autocomplete="off"></asp:TextBox>
               <asp:TextBox  ID="txtCpf" runat="server" type="text" class="textbox textbox-type2 textbox-cad" placeholder="CPF" autocomplete="off"></asp:TextBox>
               <asp:TextBox ng-model="senha" TextMode="Password" ng-change="verificar()" ID="txtSenha" runat="server" type="text" class="textbox textbox-type2 textbox-cad" placeholder="Senha" autocomplete="off"></asp:TextBox>
               <asp:TextBox  ID="txtCSenha" TextMode="Password" runat="server" type="text" class="textbox textbox-type2 textbox-cad" placeholder="Confirmar Senha" autocomplete="off"></asp:TextBox>
               <asp:Button ID="btnValida" class="button dark button-type2 button-cad" runat="server" Text="Enviar" OnClick="btnValida_Click" OnClientClick="loader('.lds-ellipsis','.button-cad');"/>
               <div class="lds-ellipsis" style="top:8px;"><div></div><div></div><div></div><div></div></div>
            </div>
        </div>
        
        <div id="erro">
            <asp:Label ID="lblErro" runat="server" Text=""></asp:Label><br/>
            <asp:Label ng-bind="mensagem" ID="lblNivelSenha" runat="server" Text=""></asp:Label><br/>
            <asp:Label ID="lblDica" CssClass="dica" runat="server" Text=""></asp:Label>
            <asp:Button ID="ReenviarEmail" runat="server" Text="Reenviar Email" OnClientClick="loader('.lds-ellipsis','.button-cad');" OnClick="ReenviarEmail_Click" CssClass="ReenviarEmail"/>
        </div>
    </div>
    <div id="info">

     </div>

      <script>
        document.getElementById("cadastro").classList.add("active");
    </script>
</asp:Content>
