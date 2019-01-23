<%@ Page Title="" Language="C#" MasterPageFile="~/logado.Master" AutoEventWireup="true" CodeBehind="colecao.aspx.cs" Inherits="AcroniWeb_4._5.colecao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right right-logado right-galeria">
        <ul class="grid grid2">
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <li>
                        <figure class="teclado" id="teclado">
                            <asp:Image ID="imgFoto" class="img" runat="server" ImageUrl='<%# "GetImageTeclado.aspx?id=" + Eval("id_teclado_customizado") %>' />
                            <asp:Label class="descricao nome" ID="lblNome" runat="server" Text='<%# Bind("nickname") %>'></asp:Label>
                        </figure>
                    </li>
                </ItemTemplate>
            </asp:DataList>
        </ul>
        <asp:Label class="descricao nome" ID="lblhue" runat="server"></asp:Label>
    </div>
    <script>
        document.getElementById("galeria").classList.add("active");
    </script>
</asp:Content>
