<%@ Page Title="" Language="C#" MasterPageFile="~/logado.Master" AutoEventWireup="true" CodeBehind="colecao.aspx.cs" Inherits="AcroniWeb_4._5.colecao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right right-logado right-galeria">
        <ul class="grid grid2">
            <asp:DataList ID="DataList2" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <li>
                        <figure id="<%# Eval("id_teclado_customizado") %>">
                            <asp:Image ID="imgFoto" class="img" runat="server" ImageUrl='' />
                            <figcaption>
                                <asp:Label class="descricao" ID="lblNome" runat="server" Text='<%# Bind("nome") %>'></asp:Label>
                                <asp:Label class="descricao" ID="lblMarca" runat="server" Text=' <%# Bind("marca") %>'></asp:Label>
                                <div style="margin-bottom: 20px;">
                                    <asp:Label class="preco" ID="Label1" runat="server" Text='R$'></asp:Label><asp:Label class="preco" ID="lblPreco" runat="server" Text='<%# Bind("preco") %>'></asp:Label></div>
                                <p>Clique para</p>
                                <p>ver mais detalhes</p>
                            </figcaption>
                        </figure>
                    </li>
                </ItemTemplate>
            </asp:DataList>
        </ul>
    </div>
    <script>
        document.getElementById("galeria").classList.add("active");
    </script>
</asp:Content>
