<%@ Page Title="" Language="C#" MasterPageFile="~/View/layout.Master" AutoEventWireup="true" CodeBehind="construct.aspx.cs" Inherits="AcroniWeb.
    .construct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        section{width:100%;height:100vh;background:#f2f2f2;display:flex}

        div {align-self:center;}

            div h1 {
                font-family: 'qanelas';
                color: #0093ff;
                font-weight: bold;
                font-size: 120px;
                transition: 0.3s;
                text-align: center;
                width: 100%;
            }

        div p{
            font-family: 'open';
            color: #333;
            font-weight: normal;
            font-size: 20px;
            transition: 0.3s;
            text-align:center;
        }

        .button {
            margin-top: 30px;
            padding-top:17px;
            padding-bottom:17px;
        }

        .textbox {
            width:500px;
            margin-top:30px;
            float:left;
        }

    </style>
    
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
        <div>
            <h1>Em Breve</h1>
            <p>Estamos trabalhando para construir essa página</p>
            <asp:TextBox id="txtEmail" class="textbox focus" type="text" placeholder="Entre com seu email e seja notificado" name="notifica" runat="server"></asp:TextBox>
            <asp:Button class="button dark" type="button" Text="Enviar" runat="server" OnClick="Unnamed1_Click"/>
        </div>
    </section>

</asp:Content>

