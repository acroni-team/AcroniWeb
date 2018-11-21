<%@ Page Title="" Language="C#" MasterPageFile="~/logado.Master" AutoEventWireup="true" CodeBehind="pagamento-dc.aspx.cs" Inherits="AcroniWeb_4._5.pagamento_dc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript"> 
        function abremodal() {
            $('.modal-overflow').removeClass('hidden');
            $('.modal-wrap').addClass('is-showing');
            $("body").niceScroll().remove();
        }
    </script>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="modal-wrap" id="modal" runat="server">
        <div class="modal-overflow modal-overflow-alt overflow-dc hidden" id="overflow" runat="server">
            <div class="modal-body modal-body-step1 modal-body-alt modal-dc is-showing animate-first-in" id="modaldc" runat="server">
                <div class="textbox-overflow overflow-type3 dc">
                    <asp:TextBox ID="NumeroAgencia" runat="server" class="textbox textbox-type3 focus dark" onblur="placehoderStay(0);"></asp:TextBox>
                    <asp:Label ID="lblNumeroAgencia" class="p" runat="server" Text="Número da agência"></asp:Label>
                </div>
                <div class="textbox-overflow overflow-type3 dc">
                    <asp:TextBox ID="Conta" runat="server" class="textbox textbox-type3 focus dark" onblur="placehoderStay(1);"></asp:TextBox>
                    <asp:Label ID="lblConta" class="p" runat="server" Text="Conta"></asp:Label>
                </div>
                <div class="textbox-overflow overflow-type3 dc">
                    <asp:TextBox ID="Digito" runat="server" class="textbox textbox-type3 focus dark" onblur="placehoderStay(2);"></asp:TextBox>
                    <asp:Label ID="lblDigito" class="p" runat="server" Text="Dígito"></asp:Label>
                </div>
                <div class="textbox-overflow overflow-typeB textbox-with-button dc">
                    <input type="button" value="Confirmar" class="button button-dc dark minha-conta modal-button-dc disabled" />
                </div>
            </div>
        </div>
        <div class="modal-background fadeIn" runat="server" id="modalback"></div>
    </div>
    <div class="right right-logado right-pagamento-cc" ng-app="">
        <div class="cabecalho cabecalho-cc">
            <div class="cabecalho-info">
                <h1>Informe seus dados do débito em conta</h1>
                <p>
                    Não se preocupe. A Acroni só irá te cobrar pelas coisas que você quiser pagar<p>
            </div>
            <img alt="Cartões de credito" src="img/pagamento/dc.png" />
        </div>
        <div class="card-form dc-form">
            <div class="align align-align">
                <div class="align align-card-form align-dc">
                    <div class="textbox-overflow overflow-type3 dc">
                        <asp:TextBox ID="Nome" runat="server" class="textbox textbox-type3 focus dark" ng-model="nome" onblur="placehoderStay(3);"></asp:TextBox>
                        <asp:Label ID="lblNome" class="p" runat="server" Text="Nome"></asp:Label>
                    </div>
                    <div class="textbox-overflow overflow-type3 dc">
                        <asp:TextBox ID="Sobrenome" runat="server" class="textbox textbox-type3 focus dark" ng-model="sobrenome" onblur="placehoderStay(4);"></asp:TextBox>
                        <asp:Label ID="lblSobrenome" class="p" runat="server" Text="Sobrenome"></asp:Label>
                    </div>
                    <div class="textbox-overflow overflow-type3 dc">
                        <asp:TextBox ID="CPF" runat="server" class="textbox textbox-type3 focus dark" aria-label="CPF" onblur="placehoderStay(5);"></asp:TextBox>
                        <asp:Label ID="lblCPF" class="p" runat="server" Text="CPF"></asp:Label>
                    </div>
                    <div class="textbox-overflow overflow-type3 dc  with-select">
                        <select onchange="abremodal()">
                            <option value="default">Banco</option>
                            <option value="bradesco">Bradesco</option>
                            <option value="santander">Santander</option>
                            <option value="caixa">Caixa</option>
                        </select>
                    </div>

                    <div class="textbox-overflow overflow-typeB  textbox-with-button dc">
                        <asp:Button ID="btnSalva" runat="server" Text="Salvo" class="button button-dc dark minha-conta disabled" disabled />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
