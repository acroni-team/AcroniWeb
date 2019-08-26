<%@ Page Title="" Language="C#" MasterPageFile="~/View/layout.Master" AutoEventWireup="true" CodeBehind="escolher-pagamento.aspx.cs" Inherits="AcroniWeb_4._5.View.escolher_pagamento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="m-div carrinho">
        <div class="left left-carrinho">
            <h1 style="margin-bottom:20px">Escolher pagamento</h1>
            <h3> pagar com cartão </h3>
            <div class="pagamento-item-carrinho">
                <p> Page com o cartão de credito ou débito, adicione um cartão clicando no botão abaixo</p>
                <a href="pagamento.aspx"><input type="button" class="button dark button-carrinho" value="Adicionar um novo cartão" /></a>
            </div>
            <h3> pagar com o boleto </h3>            
            <div class="pagamento-item-carrinho">
                <asp:Label ID="lblValorTotalBoleto" runat="server" Text='R$ (colocar valor total aqui)'></asp:Label>
                <p> Você poderá visualizar ou imprimir após a finalização do pedido. A data de vencimento é de X dias corridos após a conclusão do pedido. Após esta data, ele perderá a validade. </p>
                <a href="sucesso.aspx"><input type="button" class="button dark button-carrinho" value="Concluir pedido com boleto" /></a>
            </div>

        </div>
        <div class="right right-carrinho">
            <div class="resumo-compra">
                <h1>Resumo da compra</h1>
                <div class="resumo-compra-itens">
                    <ul>
                        <li class="resumo-item">
                            <div class="resumo-item-label">
                                <asp:Label ID="lblSub" runat="server" Text='Subtotal'></asp:Label>
                            </div>
                            <div class="resumo-item-valor">
                                <asp:Label ID="lblPreco" runat="server" Text='R$'></asp:Label>
                            </div>
                        </li>
                        <li class="resumo-item">
                            <div class="resumo-item-label">
                                <asp:Label ID="Label6" runat="server" Text='Frete'></asp:Label>
                            </div>
                            <div class="resumo-item-valor">
                                <asp:Label ID="lblFrete" CssClass="freteCarrinho" runat="server" Text='--'></asp:Label>
                            </div>
                        </li>
                        <li class="resumo-item">
                            <div class="resumo-item-label">
                                <asp:Label ID="Label2" runat="server" Text='Descontos'></asp:Label>
                            </div>
                            <div class="resumo-item-valor">
                                <asp:Label ID="Label3" runat="server" Text='R$'></asp:Label>
                            </div>
                        </li>
                                                
                        <li class="resumo-item">
                            <div class="resumo-item-label">
                                <asp:Label ID="Label4" runat="server" Text='Valor Total'></asp:Label>
                            </div>
                            <div class="resumo-item-valor">
                                <asp:Label ID="Label5" runat="server" Text='R$'></asp:Label>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
