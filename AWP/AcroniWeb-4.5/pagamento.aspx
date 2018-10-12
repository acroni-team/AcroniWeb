<%@ Page Title="" Language="C#" MasterPageFile="~/logado.Master" AutoEventWireup="true" CodeBehind="pagamento.aspx.cs" Inherits="AcroniWeb_4._5.pagamento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right right-logado right-pagamento">
        <div style="width:100%;">
            <div class="pagamento-cabecalho">
               <h1>Informe seus dados de pagamento</h1>
                <p>Você ainda não registrou seu cartão.<p>
                <p>Escolha uma das opções a seguir:</p>
            </div>
            <div class="formas-pagamento">
                <a href="pagamento-cc.aspx"><div class="container-logado">
                    <asp:Image ID="cartaoCredito" runat="server" ImageUrl='img/pagamento/cc.png' />
                    <p>Cartão de credito</p>
                 </div></a>
                <div class="container-logado">
                    <asp:Image ID="cartaoDebito" runat="server" ImageUrl='img/pagamento/cd.png' />
                    <p>Cartão de débito</p>
                 </div>
                <div class="container-logado">
                    <asp:Image ID="debitoConta" CssClass="debitoConta" runat="server" ImageUrl='img/pagamento/dc.png'/>
                    <p>Débito em conta</p>
                 </div>
            </div>
        </div>
    </div>



    <script>
        document.getElementById("pagamento").classList.add("active");
    </script>
</asp:Content>
