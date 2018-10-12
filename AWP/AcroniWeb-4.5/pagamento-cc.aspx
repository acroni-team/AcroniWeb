<%@ Page Title="" Language="C#" MasterPageFile="~/logado.Master" AutoEventWireup="true" CodeBehind="pagamento-cc.aspx.cs" Inherits="AcroniWeb_4._5.pagamento_cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        function placehoderStay(index) {
            var Nome = document.getElementById('<%=Nome.ClientID%>').value;
            var Sobrenome = document.getElementById('<%=Sobrenome.ClientID%>').value;
            if (Nome != "" || Sobrenome != "") {
                $('.overflow-type3').eq(index).children('p').addClass('stay');
            }
            if (Nome == "") {
                $('.overflow-type3').eq(0).children('p').removeClass('stay');
            }
            if (Sobrenome == "") {
                $('.overflow-type3').eq(1).children('p').removeClass('stay');
            }
        }

    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="right right-logado right-pagamento-cc">
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
                    
                     </div>   
                </div>
                <div class="card-form">
                    <div class="textbox-overflow overflow-type3">
                        <asp:TextBox ID="Nome" runat="server" class="textbox textbox-type3 focus dark" aria-label="Nome" onblur="placehoderStay(0);"></asp:TextBox>
                        <p>Nome</p>
                    </div>
                    <div class="textbox-overflow overflow-type3">
                        <asp:TextBox ID="Sobrenome" runat="server" class="textbox textbox-type3 focus dark" aria-label="Sobrenome" onblur="placehoderStay(1);"></asp:TextBox>
                        <p>Sobrenome</p>
                    </div>
                </div>
            </div>
    </div>





    <script>
        document.getElementById("pagamento").classList.add("active");
    </script>
</asp:Content>
