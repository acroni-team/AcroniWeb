<%@ Page Title="" Language="C#" MasterPageFile="~/logado.Master" AutoEventWireup="true" CodeBehind="minha-conta.aspx.cs" Inherits="AcroniWeb_4._5.editar_conta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
                    <div class="textbox-overflow">
                        <asp:TextBox ID="Nome" runat="server" class="textbox focus dark"></asp:TextBox>
                        <p>Nome completo</p>
                    </div>
                    <div class="textbox-overflow">
                        <asp:TextBox ID="CPF" runat="server" class="textbox focus dark"></asp:TextBox>
                        <p>CPF</p>
                    </div>
                    <div class="textbox-overflow">
                        <asp:TextBox ID="CEP" runat="server" class="textbox focus dark"></asp:TextBox>
                        <p>CEP</p>
                    </div>
                </div>  
                <div id="credenciais">
                     <h1> Credenciais </h1>
                    <div class="textbox-overflow">
                        <asp:TextBox ID="Email" runat="server" class="textbox focus dark"></asp:TextBox>
                         <p>E-mail</p>
                    </div>
                     <div class="textbox-overflow">
                        <asp:TextBox ID="Usuario" runat="server" class="textbox focus dark"></asp:TextBox>
                         <p>Usuário</p>
                    </div>
                    <div class="textbox-overflow">
                        <asp:TextBox ID="Senha" runat="server" class="textbox focus dark"></asp:TextBox>
                         <p>Senha</p>
                    </div>
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
                            <asp:Image ID="fotoPerfil" runat="server" ImageUrl='img/imgperf.jpeg' ImageAlign="Middle"/>
                        </figure>
                     </div>
                    <div class="plano">
                        <p>Você está usando o seguinte plano:</p>
                        <h1>Básico</h1>
                        <div class="info-plano">
                            <ul>
                                <li>Coleções ilimitadas;</li>
                                <li>Teclados ilimitados;</li>
                                <li>Registro de 1 cartão de crédito;</li>
                                <li>Customização basica</li>
                           </ul>
                       </div>
                        <asp:Button ID="btnAlteraPlano" ng-class="enabled ? ''" runat="server" Text="Alterar Plano" class="button-alt dark minha-conta" OnClick="btnSalva_Click" />
                    </div>
                    
                </div>
            </div> 
            <asp:Button ID="btnSalva" runat="server" Text="Salvo" class="button dark minha-conta disabled" OnClick="btnSalva_Click" disabled/>
        </div>    
     </div>      
     <script>
        document.getElementById("minha-conta").classList.add("active");
    </script>
</asp:Content>
