<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="cadastro.aspx.cs" Inherits="AcroniWeb.cadastro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" type="text/css" href="css/cadastro.css"/>

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
                <div>
                    <p class="identifica">Email</p>
                    <asp:Textbox id="txtEmail" class="caixxinha" type="text" spellcheck="false"  autofocus runat="server"></asp:Textbox> 
                </div>
                <div>
                    <p class="identifica">CPF</p>
                    <asp:Textbox id="txtCPF" class="caixxinha" type="text" spellcheck="false"  runat="server"></asp:Textbox>  
                </div> 
                <div>
                    <p class="identifica">CEP</p>
                    <asp:Textbox id="txtCEP" type="text" spellcheck="false" class="caixxinha" runat="server" ></asp:Textbox>
                </div>
            </div>
        </div>
        <hr class="divisor"/>
        <div class="right">
            <div class="centro" style="margin-left:100px">
                    <div>
                    <p class="identifica">Usuário</p>
                        <asp:Textbox id="txtUsu" class="caixxinha" type="text" spellcheck="false"  runat="server"></asp:Textbox>
                    </div>
                    <div>
                        <p class="identifica">Senha</p>
                        <asp:Textbox id="txtPass" class="caixxinha" type="password" spellcheck="false"  runat="server"></asp:Textbox>  
                    </div>  
                    <div>
                        <p class="identifica">Confirmar Senha</p>
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
                <asp:Label ID="lblErro" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
    </section>
    
</asp:Content>
