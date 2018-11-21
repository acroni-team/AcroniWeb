<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="download.aspx.cs" Inherits="AcroniWeb_4._5.donwload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(window).on('load', function () {
            $("body").niceScroll().remove();
        });
    </script>

</asp:Content>
<asp:Content ID="menu" ContentPlaceHolderID="menu" runat="server">
    <div id="logotext">
       <a href="galeria.aspx" id="logoacr">Acroni</a>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section id="download">
         <img alt="imagem do software de customização" src="../../img/pczinho.png" style="width:50%"/>
        <div class="align-text">
            <div class="text">
                <h1>Baixe agora o software.</h1>
                <p>Através do nosso programa pra desktop, você consegue fazer as customizações que deseja no seu teclado. O que está esperando?
                </p>
                <a href="loja.aspx"><input type="button" value="Download" class="button dark button-eas" /></a>
            </div>
         </div>
    </section>
</asp:Content>
