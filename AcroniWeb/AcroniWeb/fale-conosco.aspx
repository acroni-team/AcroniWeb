<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="fale-conosco.aspx.cs" Inherits="AcroniWeb.fale_conosco" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" type="text/css" href="css/default.css" />
    <link rel="stylesheet" type="text/css" href="css/fale-conosco.css" />


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     
    <section class="tela-inteira">
        <div class="texto">
            <h1 class="title">Converse conosco</h1><br/><br/>
            <p class="desc">Ajude-nos a deixar sua experiência melhor.</p>
        </div>
    </section>

    <section class="div-dark">
        <div class="texto-dark">
            <h2 class="title-dark">Ajude-nos a melhorar</h2><br/><br/><br/>
            <p class="desc-dark">Ficou perdido no site? Ou apenas queria enviar uma pergunta? Encontrou algo que não gostou? Ou algo que podia ser melhorado? Envie sua pergunta sugestão, crítica ou ideia.</p>
        </div>
    </section>

    <section class="tela-inteira form">
        <div id="formulario">
            <form action="">
                <h1>Envie-nos aqui</h1><br/><br/>
                <asp:TextBox class="campos-pergunta" runat="server" type="text" placeholder="Nome"></asp:TextBox>
                <asp:TextBox class="campos-pergunta" runat="server" type="text" placeholder="Sobrenome"></asp:TextBox><br/>
                <asp:TextBox class="campos-pergunta email" runat="server" type="text" placeholder="E-mail"></asp:TextBox>
                <textarea class="pergunta" id="" cols="62" rows="15" placeholder="Sua pergunta"></textarea>
                <asp:Button class="azul" type="button" Text="Enviar" runat="server"></asp:Button>
            </form>
        </div>
    </section>
          
    <script>
        document.getElementById("fale-conosco").classList.add("active");
    </script>

</asp:Content>
