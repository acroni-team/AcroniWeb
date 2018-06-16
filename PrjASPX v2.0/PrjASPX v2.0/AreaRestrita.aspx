<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="AreaRestrita.aspx.cs" Inherits="PrjASPX_v2._0.AreaRestrita1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/area-restrita.css" />
    <link rel="stylesheet" type="text/css" href="css/login.css" />
    <link rel="stylesheet" type="text/css" href="css/index.css" />
    <script type="text/javascript" src="js/login.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section>
        <div>
            <h1>Em Breve</h1>
            <p>Estamos trabalhando para construir essa página</p>
            
            <input style="width:500px;margin-top:30px;" class="caixxinha" type="text" placeholder="Entre com seu email e seja notificado" name="notifica" />
            <asp:Button class="button" type="button" Text="Entrar" runat="server" OnClick="Unnamed1_Click" />
            
            
        </div>
    </section>
</asp:Content>
