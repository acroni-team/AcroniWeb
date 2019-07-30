<%@ Page Title="" Language="C#" MasterPageFile="~/View/layout.Master" AutoEventWireup="true" CodeBehind="carrinho.aspx.cs" Inherits="AcroniWeb_4._5.View.carrinho" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu" runat="server">
    <div id="logotext">
       <a href="default.aspx" id="logoacr" runat="server" style="color:#0093ff">Acroni</a>
    </div>
   <ul id="menu-items">
        <li><a id="sobre" href="cadastro.aspx" runat="server">Cadastrar</a></li>
        <%--<li><a id="cadastro" href="cadastro.aspx">Cadastrar</a></li>--%>
   </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="m-div carrinho">
        <div class="left left-carrinho">
            <h1>Meu carrinho</h1>
            <ul class="grid grid2 grid-carrinho">
                <asp:DataList ID="DataList1" runat="server" RepeatColumns="1" RepeatDirection="Horizontal">
                    <ItemTemplate>
                        <li>
                            <div class="produto-carrinho">
                                <figure class="figure-carrinho">
                                    <asp:Image ID="imgFoto" class="img" runat="server" ImageUrl='<%# Bind("id_produto","~/assets/img/produtos/Img ({0}).png") %>'  />      
                                </figure>
                                <div class="desc-carrinho">
                                    <asp:Label class="descricao nome carrinho" ID="lblNome" runat="server" Text='<%# Bind("nome") %>'></asp:Label>
                                    <asp:Label class="descricao" ID="lblMarca" runat="server" Text='<%# Bind("marca") %>'></asp:Label>
                                     <div style="margin-bottom: 20px;">
                                         <asp:Label class="preco" ID="Label1" runat="server" Text='R$'></asp:Label>
                                         <asp:Label class="preco" ID="lblPreco" runat="server" Text='<%# Bind("preco") %>'></asp:Label>
                                     </div>
                                </div>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:DataList>
            </ul>
        </div>
        <div class="right right-carrinho">
            <h1>Resumo da compra</h1>
        </div>
    </div>
</asp:Content>
