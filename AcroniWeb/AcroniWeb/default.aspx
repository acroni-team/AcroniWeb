<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="AcroniWeb._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" type="text/css" href="css/default.css" />
        <script type="text/javascript" src="js/tema.js"></script>
        
        <script>
            // loadando o codigo do IFrame Player API.
            var tag = document.createElement('script');

            tag.src = "https://www.youtube.com/iframe_api";
            var firstScriptTag = document.getElementsByTagName('script')[0];
            firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);

            // Creando um Iframe apartir do div com id = var.
            var player;
            function onYouTubeIframeAPIReady() {
                player = new YT.Player('player', {
                    height: '100%',
                    width: '100%',
                    videoId: 'DEpBYVFCw_U',
                    playerVars: { 'autoplay': 1},
                    events: {
                        'onReady': onPlayerReady
                    }
                });
            }

            // API chama a função assim que o player termina de ser carregado.
            function onPlayerReady(event) {
                player.setPlaybackRate(2);
              
            }

        </script>

</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="preload">
            <div class="anima">
                <div class="item"></div>
                <div class="item"></div>
                <div class="item"></div>
                <div class="item"></div>
                <div class="item"></div>
                <div class="item"></div>
            </div>
        </div>
        <a href="#background">       
        <section id="lsection" ">
		<div>
			<h1> Acroni </h1><br/>
			<p> Mais que um teclado. O seu.</p>
			<div id="buttons">
                <asp:Button class="blue" runat="server" Text="Fale conosco" OnClick="Unnamed1_Click"/>   
                <!-- <asp:Button id="muda" class="blue" runat="server"  Text="Teclados mecânicos" ClientIDMode="Static" OnClientClick="return false"/>  <!-- OnClientClick="return false;">   ClientIDMode="Static" OnClientClick="return false;--> 
                <div id="muda" class="blue">
                 <h3 id="fold_p" >Teclados mecânicos</h3>
                </div>
           </div>
            
         <div id="player"></div>
		</div>
            
	    </section>
	    <section id="rsection">
		    <div>
			    <img src="img/apple.png" id="img" />
		    </div>
	    </section>
        </a>
     
        <script>
            document.getElementById("home").classList.add("active");
        </script>

</asp:Content>
