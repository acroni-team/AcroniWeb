<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="loja.aspx.cs" Inherits="AcroniWeb.loja" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/loja.css" rel="stylesheet" type="text/css"/>
		<script type="text/javascript">
            var _gaq = _gaq || [];
            _gaq.push(['_setAccount', 'UA-7243260-2']);
            _gaq.push(['_trackPageview']);
            (function() {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
            })();
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="head-container">
        <div class="header">
            <div>
                <h1>Onde seu sonho se torna realidade.</h1>
                <p>Fique à vontade para explorar o que temos de melhor*: Nossos teclados.</p>
                <p>*São também a</p> <p>única coisa que temos.</p> <p>Mas isso não vem ao caso.</p>
            </div>
        </div>
        <div class="curve">
            <div class="div">
                <h1>Os queridinhos do público.</h1>
                <p>Os teclados mais vendidos estão aqui. Aproveite.</p>
                         <ul class="grid">
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                <ItemTemplate>
                
                    <li>  
                        <figure id="click<%# Eval("id_produto") %>" name="<%# Eval("id_produto") %>">
                            <%--<a href="#Produto<%# Eval("id") %>">--%><asp:Image ID="imgFoto" class="img" runat="server"  ImageUrl='<%# Bind("id_produto","~/img/produtos/Img({0}).png") %>' /><%--</a>--%>
                            <figcaption>
                                    <asp:Label class="descricao" ID="lblNome" runat="server" Text='<%# Bind("nome") %>'></asp:Label>
                                    <asp:Label class="descricao" ID="lblMarca" runat="server" Text=' <%# Bind("marca") %>'></asp:Label>
                                    <div style="margin-bottom: 20px;"><asp:Label class="preco" ID="Label1" runat="server" Text='R$'></asp:Label><asp:Label class="preco" ID="lblPreco" runat="server" Text='<%# Bind("preco") %>'></asp:Label></div>
                                    <p>Clique para</p>
                                    <p>ver mais detalhes</p>
                            </figcaption>
                        </figure>
                    </li>

                    <div id="Produto<%# Eval("id_produto") %>" class="modal-wrap modal-wrap-loja">
                        <div class="modal-overflow overflow-loja">
                        <div class="modal-body modal-body-loja">
                            <a class="fecha-janela">x</a>
                            <div class="right-loja">
                                <asp:Image ID="Image1" class="img-grande" runat="server"  ImageUrl='<%# Bind("id_produto","~/img/produtos/Img({0}).png") %>' />
                            </div>
                            <div class="left-loja">
                            </div>
                         </div>
                       </div>
                       <div class="modal-background"></div>
                     </div>

                </ItemTemplate>
            </asp:DataList>
          </ul>

            </div>
        </div>     
    </div>
    <div class="classic">
        <div class="div">
            <h1>Os queridinhos do público.</h1>
             <p>Os teclados mais vendidos estão aqui. Aproveite.</p>
        </div>
         <ul class="grid">
            <asp:DataList ID="DataList2" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                <ItemTemplate>
                
                    <li>  
                        <figure id="click<%# Eval("id_produto") %>" name="<%# Eval("id_produto") %>">
                            <%--<a href="#Produto<%# Eval("id") %>">--%><asp:Image ID="imgFoto" class="img" runat="server"  ImageUrl='<%# Bind("id_produto","~/img/produtos/Img({0}).png") %>' /><%--</a>--%>
                            <figcaption>
                                    <asp:Label class="descricao" ID="lblNome" runat="server" Text='<%# Bind("nome") %>'></asp:Label>
                                    <asp:Label class="descricao" ID="lblMarca" runat="server" Text=' <%# Bind("marca") %>'></asp:Label>
                                    <div style="margin-bottom: 20px;"><asp:Label class="preco" ID="Label1" runat="server" Text='R$'></asp:Label><asp:Label class="preco" ID="lblPreco" runat="server" Text='<%# Bind("preco") %>'></asp:Label></div>
                                    <p>Clique para</p>
                                    <p>ver mais detalhes</p>
                            </figcaption>
                        </figure>
                    </li>

                    <div id="Produto<%# Eval("id_produto") %>" class="modal-wrap modal-wrap-loja">
                        <div class="modal-overflow overflow-loja">
                        <div class="modal-body modal-body-loja">
                            <a class="fecha-janela">x</a>
                            <div class="right-loja">
                                <asp:Image ID="Image1" class="img-grande" runat="server"  ImageUrl='<%# Bind("id_produto","~/img/produtos/Img({0}).png") %>' />
                            </div>
                            <div class="left-loja">
                            </div>
                         </div>
                       </div>
                       <div class="modal-background"></div>
                     </div>

                </ItemTemplate>
            </asp:DataList>
          </ul>
      </div>
       <!--<a href="Produto<%# Eval("id") %>.aspx"><div class="info">-->
       <!--<a href="Produto<%# Eval("id") %>.aspx">Produto <%# Eval("id") %></a>-->
    <script>
        $('figure').click(function () {
            var id = $(this).attr("name"); 
            $('.modal-overflow').removeClass('hidden');
            $("#Produto"+id).removeClass("animate-out").addClass("is-showing animate-in");
             $("body").niceScroll().remove();
        
        $('.modal-background, .fecha-janela').click(function () {
            $("body").niceScroll({ cursorcolor: "#0093ff", cursorwidth: "10px", cursorborder: "none" });
            $("#Produto"+id).removeClass("is-showing animate-in").addClass("animate-out");
        });
        });
     
    </script>
</asp:Content>

