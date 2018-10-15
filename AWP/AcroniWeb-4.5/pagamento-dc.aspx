<%@ Page Title="" Language="C#" MasterPageFile="~/logado.Master" AutoEventWireup="true" CodeBehind="pagamento-dc.aspx.cs" Inherits="AcroniWeb_4._5.pagamento_dc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right right-logado right-pagamento-cc" ng-app="">
            <div class="cabecalho cabecalho-cc">
                <div class="cabecalho-info">
                    <h1>Informe seus dados do débito em conta</h1>
                    <p>Não se preucupe. A Acroni só irá te cobrar pelas coisas que você quiser pagar<p>
                </div>
                <img alt="Cartões de credito" src="img/pagamento/dc.png" />
            </div>
            <div class="card-form dc-form">
                    <div class="align align-align">
                        <div class="align align-card-form align-dc">
                            <div class="textbox-overflow overflow-type3 dc">
                                <asp:TextBox ID="Nome" runat="server" class="textbox textbox-type3 focus dark" aria-label="Nome" ng-model="nome" onblur="placehoderStay(0);"></asp:TextBox>
                                <p>Nome</p>
                            </div>
                            <div class="textbox-overflow overflow-type3 dc">
                                <asp:TextBox ID="Sobrenome" runat="server" class="textbox textbox-type3 focus dark" aria-label="Sobrenome" ng-model="sobrenome" onblur="placehoderStay(1);"></asp:TextBox>
                                <p>Sobrenome</p>
                            </div>
                            <div class="textbox-overflow overflow-type3 dc">
                                <asp:TextBox ID="Numero" runat="server" class="textbox textbox-type3 focus dark" aria-label="Número do cartão" ng-model="numero" onblur="placehoderStay(2);"></asp:TextBox>
                                <p>Número do cartão</p>
                            </div>
                            <div class="textbox-overflow overflow-type3 dc">
                                <asp:TextBox ID="DataValidade" runat="server" class="textbox textbox-type3 focus dark" aria-label="Data de validade" ng-model="data" onblur="placehoderStay(3);"></asp:TextBox>
                                <p>Data de validade</p>
                            </div> 
                            <div class="textbox-overflow overflow-type3 textbox-with-button dc">
                                <asp:Button ID="btnSalva" runat="server" Text="Salvo" class="button button-dc dark minha-conta disabled" disabled/>
                            </div>
                        </div>
                    </div>
                </div>
    </div>
</asp:Content>
