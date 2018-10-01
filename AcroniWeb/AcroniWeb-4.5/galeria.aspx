<%@ Page Title="" Language="C#" MasterPageFile="~/logado.Master" AutoEventWireup="true" CodeBehind="galeria.aspx.cs" Inherits="AcroniWeb_4._5.galeria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="galeria-section">
        <div class="left left-galeria">
            <div class="perfil-cliente">
                <div>
                    <figure class="profile-wraper">
                        <div>
                            <asp:Image ID="profilePicture" class="profile-picture" runat="server"  ImageUrl='' />
                        </div>
                    </figure>
                    <figcaption class="profile-settings">
                        <asp:Label class="user-name" ID="lblUser" runat="server" Text='Fillers'></asp:Label><br/>
                        <asp:Label class="user-plan" ID="lblPlan" runat="server" Text='Plano Básico'></asp:Label>
                    </figcaption>
                    <div class="line"></div>
                    <figcaption class="profile-settings">
                       <asp:Label class="user-mb user-plan" ID="lblMbStart" runat="server" Text='0 MB' style="left:-125px;"></asp:Label>
                       <asp:Label class="user-mb user-plan" ID="lblMbEnd" runat="server" Text='50 MB' style="right:-125px;"></asp:Label>
                    </figcaption>
                </div>
            </div>
            <div class="menu-lateral">
               <li class="active"><a>Minha galeria</a></li>
               <li><a>Minha conta</a></li>
               <li><a>Customizar por código</a></li>
            </div>
        </div>    
        <div class="right right-galeria">
            <asp:Image ID="imgColecao" class="colecao-picture" runat="server" ImageUrl='' />
            <asp:Image ID="imgStatus" class="galeria-status" runat="server"  ImageUrl='img/galeria-vazia.png' />
        </div>
    </section>   
</asp:Content>
