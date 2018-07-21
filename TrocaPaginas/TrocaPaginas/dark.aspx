<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dark.aspx.cs" Inherits="TrocaPaginas.dark" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <meta charset="utf-8"/>
        <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
        <meta name="viewport" content="width=device-width, initial-scale=1"/>
        <title> ALO </title>  
        <link rel="stylesheet" type="text/css" href="index.css"/>
        <link rel="stylesheet" type="text/css" href="keyframes.css"/>
        <link rel="stylesheet" type="text/css" href="transicao.css"/>  
    </head>
    <body>
        <form id="form1" runat="server">
            <div id="main" class="m-div">
                <div class="light light--topedaum" id="alo">
                    <a class="link" href="index.aspx">alo</a>
                </div>    
                <div class="dark" id="alo2"></div>
            
          
                <script src="https://code.jquery.com/jquery-2.2.1.min.js"></script> <!-- jquery da net, se n tiver net no momento em que estiver testando isso troque por um offline -->
                <script src="jquery.smoothState.js"></script> <!-- eh como se fosse uma classe que possui os metodos onStart onReady, render etc que foram usados na função do main.js (que ativa uma classe no momento em que o usuario sai da pagina) -->
                <script src="main.js"></script>
            </div>
        </form>
    </body>
</html>
