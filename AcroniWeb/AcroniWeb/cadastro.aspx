<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="cadastro.aspx.cs" Inherits="AcroniWeb.cadastro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script src="js/jquery.mask.min.js"></script>
    <script src="js/mascaras.js"></script>
    <link rel="stylesheet" type="text/css" href="css/cadastro.css"/>
    <meta name="viewport" content="initial-scale=1.0,user-scalable=no,maximum-scale=1"> 
    
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="cima">
        <div>
            <h1>Cadastro</h1>
            <p>sloganzinho</p>
        </div>
    </section>
    <section id="meio">
        <div class="left"> 
            <div class="centro" style="margin-right:100px">
                <div class="separa">
                    <asp:Label ID="lblEmail" class="identifica" runat="server" Text="Email"></asp:Label>    <!--E-mail nao pode ter autofocus, se tiver vai tirar a borda vermelha de erro // Roger That-->
                    <asp:Textbox id="txtEmail" class="caixxinha" type="text" spellcheck="false" runat="server"></asp:Textbox> 
                </div>
                <div class="separa">
                    <asp:Label ID="lblCPF" class="identifica" runat="server" Text="CPF"></asp:Label>
                    <asp:Textbox id="txtCPF" class="caixxinha" type="text" spellcheck="false" runat="server" data-mask="000.000.000-00"></asp:Textbox>  
                </div> 
                <div class="separa">
                    <asp:Label ID="lblCEP" class="identifica" runat="server" Text="CEP"></asp:Label>
                    <asp:Textbox id="txtCEP" type="text" spellcheck="false" class="caixxinha" runat="server" data-mask="00000-000"></asp:Textbox>
                </div>
            </div>
        </div>
        <hr class="divisor"/>
        <div class="right">
            <div class="centro" style="margin-left:100px">
                    <div class="separa">
                        <asp:Label ID="lblUsu" class="identifica" runat="server" Text="Usuário"></asp:Label>
                        <asp:Textbox id="txtUsu" class="caixxinha" type="text" spellcheck="false"  runat="server"></asp:Textbox>
                    </div>
                    <div class="separa">
                        <asp:Label ID="lblPass" class="identifica" runat="server" Text="Senha"></asp:Label>
                        <asp:Textbox id="txtPass" class="caixxinha" type="password" spellcheck="false"  runat="server"></asp:Textbox>  
                    </div>  
                    <div class="separa">
                        <asp:Label ID="lblCPass" class="identifica" runat="server" Text="Confirmar Senha"></asp:Label>
                        <asp:Textbox id="txtCPass" class="caixxinha" type="password" spellcheck="false"  runat="server"></asp:Textbox>  
                    </div>  
            </div>
        </div>

    </section>

    <section id="baixo">
        <div>
            <label class="container"> 
                <input type="checkbox" required/>
                <span class="checkmark"></span>
                <p style="margin-left:25px">Aceitar os termos de uso</p>
            </label>
            <div style="align-self:center;">
                <asp:Button CssClass="blue2" ID="btnCad" runat="server" Text="Criar conta" OnClick="btnCad_Click"/>
                <%--<asp:Label ID="lblErro" runat="server" Text="Label"></asp:Label>--%>
            </div>
        </div>
    </section>
    
</asp:Content>
