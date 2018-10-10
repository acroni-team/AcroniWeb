<%@ Page Title="" Language="C#" MasterPageFile="~/logado.Master" AutoEventWireup="true" CodeBehind="minha-conta.aspx.cs" Inherits="AcroniWeb_4._5.editar_conta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/uploadImagem.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right right-logado right-minha-conta">
        <div id="cabecalho">
            <h1>Editar os meus dados pessoais</h1>
        </div>
        <div style="margin-top:30px;">
            <div class="minha-conta-forms">
                <div id="informacoes-basicas">
                    <h1> Informações básicas </h1>
                    <asp:TextBox ID="Nome" runat="server" class="textbox focus dark"></asp:TextBox>
                    <asp:TextBox ID="CPF" runat="server" class="textbox focus dark"></asp:TextBox>
                    <asp:TextBox ID="CEP" runat="server" class="textbox focus dark"></asp:TextBox>
                </div>  
                <div id="credenciais">
                     <h1> Credenciais </h1>
                    <asp:TextBox ID="Email" runat="server" class="textbox focus dark"></asp:TextBox>
                    <asp:TextBox ID="Usuario" runat="server" class="textbox focus dark"></asp:TextBox>
                    <asp:TextBox ID="Senha" runat="server" class="textbox focus dark"></asp:TextBox>
                </div> 
            </div>
            <div class="separa"></div>
            <div id="foto-pricing">
                 <h1> Foto e Pricing </h1>
                <div id="foto-pricing-conteudo">
                    <div class="foto">
                        <figure>
                            <figcaption class="uploadaimg">
                                <asp:FileUpload ID="FileUpload1" CssClass="upload-imagem" onchange="loadFile(event);" runat="server" accept="image/*"/>
                                <label class="alteraimg" "ContentPlaceHolder1_FileUpload1">ALTERAR</label>

                            </figcaption>
                            <asp:Image ID="fotoPerfil" runat="server" ImageUrl='img/imgperf.jpeg'/>
                        </figure>
                     </div>
                    <div class="plano">
                        <div class="nome-plano">
                            <p>Você está usando o seguinte plano:</p>
                            <h1>Básico</h1>
                        </div>
                        <div class="info-plano">
                            <ul>
                                <li>Coleções ilimitadas;</li>
                                <li>Teclados ilimitados;</li>
                                <li>Registro de 1 cartão de crédito;</li>
                                <li>Customização basica</li>
                           </ul>
                       </div>
                        
                    </div>
                    
                </div>
            </div> 
            <asp:Button ID="btnSalva" runat="server" Text="Salvo" class="button dark" OnClick="btnSalva_Click" />
        </div>    
     </div>      
     <script>
        document.getElementById("minha-conta").classList.add("active");
    </script>
</asp:Content>
