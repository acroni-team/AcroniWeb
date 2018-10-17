<%@ Page Title="" Language="C#" MasterPageFile="~/logado.Master" AutoEventWireup="true" CodeBehind="pagamento-cc.aspx.cs" Inherits="AcroniWeb_4._5.pagamento_cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="right right-logado right-pagamento-cc" ng-app="">
            <div class="cabecalho cabecalho-cc">
                <div class="cabecalho-info">
                    <h1>Informe seus dados do seu cartão de crédito</h1>
                    <p>Cartões que suportam transições de débito e de crédito poderão ser processados de ambas as formas.<p>
                </div>
                <img alt="Cartões de credito" src="img/pagamento/cc.png" />
            </div>
            <div class="card-section">
                <div class="align align-cc">
                    <div class="card">
                        <p ng-bind="numero">5674 7564 7325 32</p>
                        <p ng-bind="nome"></p>
                        <p ng-bind="sobrenome"></p>
                        <p ng-bind="data">12/19</p>
                     </div>   
                </div>
                <div class="card-form">
                    <div class="align align-align">
                        <div class="align align-card-form">
                            <div class="textbox-overflow overflow-type3">
                                <asp:TextBox ID="Nome" runat="server" class="textbox textbox-type3 focus dark" aria-label="Nome" ng-model="nome" onblur="placehoderStay(0);"></asp:TextBox>
                                <asp:Label ID="lblNome" class="p" runat="server" Text="Nome"></asp:Label>
                            </div>
                            <div class="textbox-overflow overflow-type3">
                                <asp:TextBox ID="Sobrenome" runat="server" class="textbox textbox-type3 focus dark" aria-label="Sobrenome" ng-model="sobrenome" onblur="placehoderStay(1);"></asp:TextBox>
                                <asp:Label ID="lblSobrenome" class="p" runat="server" Text="Sobrenome"></asp:Label>
                            </div>
                            <div class="textbox-overflow overflow-type3">
                                <asp:TextBox ID="Numero" runat="server" class="textbox textbox-type3 focus dark" aria-label="Número do cartão" ng-model="numero" onblur="placehoderStay(2);"></asp:TextBox>
                                <asp:Label ID="lblNumero" class="p" runat="server" Text="Numero"></asp:Label>
                            </div>
                            <div class="textbox-overflow overflow-type3">
                                <asp:TextBox ID="DataValidade" runat="server" class="textbox textbox-type3 focus dark" aria-label="Data de validade" ng-model="data" onblur="placehoderStay(3);"></asp:TextBox>
                                <asp:Label ID="lblDataValidade" class="p" runat="server" Text="Data de validade"></asp:Label>
                            </div> 
                            <div class="textbox-overflow overflow-type3">
                                <asp:TextBox ID="CodigoSeguranca" runat="server" class="textbox textbox-type3 focus dark" aria-label="Código de segurança" onblur="placehoderStay(4);"></asp:TextBox>
                                <asp:Label ID="lblCodigo" class="p" runat="server" Text="Código de segurança"></asp:Label>
                            </div>
                            <div class="textbox-overflow overflow-type3 textbox-with-button">
                                <asp:Button ID="btnSalva" runat="server" Text="Salvo" class="button dark minha-conta disabled" disabled/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </div>





    <script>
        document.getElementById("pagamento").classList.add("active");
    </script>
</asp:Content>
