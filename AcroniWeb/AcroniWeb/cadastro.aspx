<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="cadastro.aspx.cs" Inherits="AcroniWeb.cadastro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" type="text/css" href="css/cadastro.css"/>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="cima">
        <div style="text-align:center">
            <h1>Cadastro</h1>
            <p>sloganzinho</p>
        </div>
    </section>
    <section id="meio">
        <div class="left"> 
            <div class="centro" style="margin-right:100px">
                <div>
                    <p class="identifica">Nome</p>
                    <asp:Textbox id="txtNome" class="caixxinha" type="text" spellcheck="false"  runat="server"></asp:Textbox>
                </div>
                <div>
                    <p class="identifica">Email</p>
                    <asp:Textbox id="txtEmail" class="caixxinha" type="text" spellcheck="false"  runat="server"></asp:Textbox> 
                </div>
                <div>
                    <p class="identifica">CPF</p>
                    <asp:Textbox id="txtCPF" class="caixxinha" type="text" spellcheck="false"  runat="server"></asp:Textbox>  
                </div>   
                
            </div>
        </div>
        <hr class="divisor"/>
        <div class="right">
            <div class="centro" style="margin-left:100px">
                    <div>
                        <p class="identifica">CEP</p>
                        <asp:Textbox id="txtCEP" type="text" spellcheck="false" class="caixxinha" runat="server"></asp:Textbox>
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
                <input type="checkbox"/>
                <span class="checkmark"></span>
                <p style="margin-left:25px">Aceitar os termos de uso</p>
            </label>
            <div style="align-self:center;">
            <asp:Button CssClass="blue2" ID="Button1" runat="server" Text="Criar conta"/>
            </div>
        </div>
    </section>
    
</asp:Content>
