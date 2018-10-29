<%@ Page Title="" Language="C#" MasterPageFile="~/logado.Master" AutoEventWireup="true" CodeBehind="galeria.aspx.cs" Inherits="AcroniWeb_4._5.galeria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  
    <div class="right right-logado right-galeria colecao">
        <div class="galeria-header">
            <h1>Seja bem-vindo, </h1><asp:Label ID="Nome" class="nome" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <a href="colecao.aspx"><asp:Image ID="imgColecao" class="img-colecao" runat="server" ImageUrl='' /></a>
            <asp:Image ID="imgStatus" class="galeria-status" runat="server"  ImageUrl='img/galeria-vazia.png' />
        </div>
    </div>
      <script>
        document.getElementById("galeria").classList.add("active");
    </script>
</asp:Content>
