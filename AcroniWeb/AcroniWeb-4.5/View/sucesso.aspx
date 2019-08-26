<%@ Page Title="" Language="C#" MasterPageFile="~/View/layout.Master" AutoEventWireup="true" CodeBehind="sucesso.aspx.cs" Inherits="AcroniWeb_4._5.View.sucesso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="m-div carrinho" style="flex-direction: column;">
        <h1>Sucesso</h1>
        <div class="sucesso">
            <p> Sua compra foi finalizada com sucesso, imprima o boleto clicando no botão abaixo </p>
            <asp:Button ID="btnGeraBoleto" runat="server" Text="Imprimir boleto" class="button button-dc dark minha-conta" />
            <a href="loja.aspx">Voltar a loja</a>
        </div>        

    </div>

</asp:Content>
