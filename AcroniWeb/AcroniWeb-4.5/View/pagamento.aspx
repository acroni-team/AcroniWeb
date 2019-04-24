<%@ Page Title="" Language="C#" MasterPageFile="~/View/logado.Master" AutoEventWireup="true" CodeBehind="pagamento.aspx.cs" Inherits="AcroniWeb_4._5.pagamento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right right-logado right-pagamento">
        <div style="width: 100%;">
            <div class="pagamento-cabecalho">
                <h1>Informe seus dados de pagamento</h1>
                <p>
                    Você ainda não registrou seu cartão.<p>
                <p>Escolha uma das opções a seguir:</p>
            </div>
            <div class="formas-pagamento">
                <a id="pagamentoCC" href="pagamento-cc.aspx?type=cc">
                    <div class="container-logado">
                        <asp:Image ID="cartaoCredito" runat="server" ImageUrl='assets/img/pagamento/cc.png' />
                        <p>Cartão de crédito</p>
                    </div>
                </a>
                <a id="pagamentoCD" href="pagamento-cc.aspx?type=cd">
                    <div class="container-logado">
                        <asp:Image ID="cartaoDebito" runat="server" ImageUrl='assets/img/pagamento/cd.png' />
                        <p>Cartão de débito</p>
                    </div>
                </a>
                <a href="pagamento-dc.aspx">
                    <div class="container-logado">
                        <asp:Image ID="debitoConta" CssClass="debitoConta" runat="server" ImageUrl='assets/img/pagamento/dc.png' />
                        <p>Débito em conta</p>
                    </div>
                </a>
            </div>
        </div>
    </div>

    <script>
        document.getElementById("pagamento").classList.add("active");
    </script>
</asp:Content>
