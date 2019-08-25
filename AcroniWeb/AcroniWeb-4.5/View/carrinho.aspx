<%@ Page Title="" Language="C#" MasterPageFile="~/View/layout.Master" AutoEventWireup="true" CodeBehind="carrinho.aspx.cs" Inherits="AcroniWeb_4._5.View.carrinho" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
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
                                <div class="btns-carrinho">
                                     <asp:Button ID="BtnDeleteItem"  OnClick="BtnDeleteItem_Click" runat="server" class="btn-delete material-icons" Text='<%# Bind("id_produto") %>'/>
                                     <i class="delete material-icons"></i>   
                                     <div class="qtde-carrinho">
                                         <i class="menos material-icons"></i> 
                                         <asp:Label class="lbl-qtde" ID="lblQtde" runat="server" Text='1'></asp:Label>
                                         <i class="mais material-icons"></i>
                                     </div>
                                </div>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:DataList>
            </ul>
            <asp:TextBox ID="txtFrete" class="textbox focus carrinho" runat="server" placeholder="Digite o CEP"></asp:TextBox>
            <input id="freteCarrinho" type="button" name="name" value="Calcular" />
        </div>
        <div class="right right-carrinho">
            <div class="resumo-compra">
                <h1 style="margin-bottom: 25px;">Resumo da compra</h1>
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
                    <asp:Button ID="btnEntra" class="button dark button-carrinho" type="button" Text="Continuar" OnClientClick="loader('.lds-login','.button-login');" runat="server"  />
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>
