using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcroniWeb_4._5
{
    public partial class editar_conta : System.Web.UI.Page
    {
        Utilitarios ut = new Utilitarios();
        SQLMetodos sql = new SQLMetodos();
        Valida v = new Valida();
        SqlConnection conexao_SQL = new SqlConnection(acroni.classes.Conexao.nome_conexao);

        protected void Page_Load(object sender, EventArgs e)
        {
            string urlFotoPerfil = "";
            List<string> campos = new List<string>();
            if (Session["usuarioNovo"] != null)
            {
                campos = sql.selectCampos("nome, cpf, cep, email, usuario, senha", "tblCliente", "usuario = '" + Session["usuarioNovo"] + "'");
                object imgObj = sql.selectImagem("imagem_cliente", "tblCliente", "usuario = '" + Session["usuarioNovo"] + "'");
                if(!(imgObj == System.DBNull.Value))
                    urlFotoPerfil = Convert.ToBase64String((byte[])imgObj);
            }
            else
            {
                campos = sql.selectCampos("nome, cpf, cep, email, usuario, senha", "tblCliente", "usuario = '" + Session["usuario"] + "'");
                object imgObj = sql.selectImagem("imagem_cliente", "tblCliente", "usuario = '" + Session["usuario"] + "'");
                if (!(imgObj == System.DBNull.Value))
                    urlFotoPerfil = Convert.ToBase64String((byte[])imgObj);
            }

            Nome.Attributes["placeholder"] = campos[0];
            CPF.Attributes["placeholder"] = campos[1];
            CEP.Attributes["placeholder"] = campos[2];
            Email.Attributes["placeholder"] = campos[3];
            Usuario.Attributes["placeholder"] = campos[4];
            Senha.Attributes["placeholder"] = campos[5];
            if (urlFotoPerfil == "")
                fotoPerfil.ImageUrl = "img/imgperf.jpeg";
            else
                fotoPerfil.ImageUrl = "data:image/jpg;base64," + urlFotoPerfil;
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            string novosValores = "";
            bool first = false, IsImageUpload = false, userChanged = false, passChanged = false;

            if (!FileUpload1.HasFile)
            {
                novosValores = "";
            }
            else if (!(FileUpload1.PostedFile.ContentType == "image/jpeg" ||
                       FileUpload1.PostedFile.ContentType == "image/png" ||
                       FileUpload1.PostedFile.ContentType == "image/bmp" ||
                       FileUpload1.PostedFile.ContentType == "image/tiff" ||
                       FileUpload1.PostedFile.ContentType == "image/gif"))
            {
                //Mensagem de erro porque não é imagem K
            }
            else if (FileUpload1.PostedFile.ContentLength > 8388608)
            {
                //Criar uma mensagem de erro pois a imagem é muito grande
            }
            else
            {
                try
                {
                    HttpFileCollection hfc = Request.Files;
                    System.Drawing.Image image = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);
                    HttpPostedFile hpf = hfc[0];
                    if (hpf.ContentLength > 0)
                    {
                        byte[] imgBytes = null;

                        if (Path.GetExtension(hpf.FileName) == ".jpeg")
                            imgBytes = ut.ConvertImageToByteArray(image, System.Drawing.Imaging.ImageFormat.Jpeg);
                        else if (Path.GetExtension(hpf.FileName) == ".png")
                            imgBytes = ut.ConvertImageToByteArray(image, System.Drawing.Imaging.ImageFormat.Png);
                        else if (Path.GetExtension(hpf.FileName) == ".bmp")
                            imgBytes = ut.ConvertImageToByteArray(image, System.Drawing.Imaging.ImageFormat.Bmp);
                        else if (Path.GetExtension(hpf.FileName) == ".tiff")
                            imgBytes = ut.ConvertImageToByteArray(image, System.Drawing.Imaging.ImageFormat.Tiff);
                        else if (Path.GetExtension(hpf.FileName) == ".gif")
                            imgBytes = ut.ConvertImageToByteArray(image, System.Drawing.Imaging.ImageFormat.Gif);

                        sql.updateImagem(imgBytes, "tblCliente", "usuario = '" + Session["usuario"] + "'");
                        IsImageUpload = true;
                    }
                }
                catch { }
            }



            if (!string.IsNullOrEmpty(Nome.Text))
            {
                string nomeSemEspacos = ut.retirarEspacos(Nome.Text);
                if (!nomeSemEspacos.Contains(' '))
                    Nome.Text = "Nome completo inválido";
                else if (v.validarNome(nomeSemEspacos))
                {
                    first = true;
                    novosValores += "nome = '" + Nome.Text + "'";
                }
                else
                    Nome.Text = "Nome completo inválido"; //Mensagem de erro: nome inválido
            }

            if (!string.IsNullOrEmpty(CEP.Text))
            {
                if (v.validarCep(CEP.Text))
                {
                    if (first)
                        novosValores += ",cep = '" + CEP.Text + "'";
                    else
                    {
                        novosValores += "cep = '" + CEP.Text + "'";
                        first = true;
                    }
                }
                else
                    Nome.Text = "CEP inválido"; //Mensagem de erro: CEP inválido
            }

            if (!string.IsNullOrEmpty(CPF.Text))
            {
                if (v.validarCPF(CPF.Text))
                {
                    if (!sql.selectHasRows("*", "tblCliente", "cpf = '" + CPF.Text + "'"))
                    {
                        if (first)
                            novosValores += ",cpf = '" + CPF.Text + "'";
                        else
                        {
                            novosValores += "cpf = '" + CPF.Text + "'";
                            first = true;
                        }
                    }
                    else
                        Nome.Text = "CPF já cadastrado"; //Mensagem de erro: CEP em uso
                }
                else
                    Nome.Text = "CPF inválido"; //Mensagem de erro: CEP inválido
            }

            if (!string.IsNullOrEmpty(Email.Text))
            {
                string emailSemEspacos = ut.retirarEspacos(Email.Text);
                if (v.validarEmail(emailSemEspacos))
                {
                    if (!sql.selectHasRows("*", "tblCliente", "email = '" + emailSemEspacos + "'"))
                    {
                        if (first)
                            novosValores += ",email = '" + emailSemEspacos + "'";
                        else
                        {
                            novosValores += "email = '" + emailSemEspacos + "'";
                            first = true;
                        }
                    }
                    else
                        Email.Text = "Email já cadastrado"; //Mensagem de erro: email em uso
                }
                else
                    Email.Text = "Email inválido"; //Mensagem de erro: email inválido
            }

            if (!string.IsNullOrEmpty(Usuario.Text))
            {
                string usuSemEspacos = ut.retirarEspacos(Usuario.Text);
                if (v.validarUsu(usuSemEspacos))
                {
                    if (!sql.selectHasRows("*", "tblCliente", "usuario = '" + usuSemEspacos + "'"))
                    {
                        if (first)
                            novosValores += ",usuario = '" + usuSemEspacos + "'";
                        else
                        {
                            novosValores += "usuario = '" + usuSemEspacos + "'";
                            first = true;
                        }
                        Session["usuarioNovo"] = usuSemEspacos;
                        userChanged = true;
                    }
                    else
                        Usuario.Text = "Usu já cadastrado"; //Mensagem de erro: usu em uso
                }
                else
                    Usuario.Text = "Usu inválido"; //Mensagem de erro: usu inválido
            }

            if (!string.IsNullOrEmpty(Senha.Text))
            {
                if (first)
                    novosValores += ",senha = '" + Senha.Text + "'";
                else
                {
                    novosValores += "senha = '" + Senha.Text + "'";
                    first = true;
                }
                passChanged = true;
            }

            if (userChanged && passChanged)
            {
                HttpCookie cookie = new HttpCookie("credenciais");
                cookie.Values["usuario"] = Session["usuarioNovo"].ToString();
                cookie.Values["senha"] = Senha.Text;
                cookie.Expires = DateTime.Now.AddDays(365);
                Response.Cookies.Add(cookie);
                userChanged = true;
            }
            else if (userChanged == true && passChanged == false)
            {
                string senha = Request.Cookies["credenciais"]["senha"];
                HttpCookie cookie = new HttpCookie("credenciais");
                cookie.Values["usuario"] = Session["usuarioNovo"].ToString();
                cookie.Values["senha"] = senha;
                cookie.Expires = DateTime.Now.AddDays(365);
                Response.Cookies.Add(cookie);
                userChanged = true;
            }
            else if (userChanged == false && passChanged == true)
            {
                string usuario = Request.Cookies["credenciais"]["usuario"];
                HttpCookie cookie = new HttpCookie("credenciais");
                cookie.Values["usuario"] = usuario;
                cookie.Values["senha"] = Senha.Text;
                cookie.Expires = DateTime.Now.AddDays(365);
                Response.Cookies.Add(cookie);
                userChanged = true;
            }

            if (first)
            {
                sql.update("tblCliente", "usuario = '" + Session["usuario"] + "'", novosValores);
                Response.Redirect("minha-conta.aspx");
            }
            else if (IsImageUpload)
            {
                Response.Redirect("minha-conta.aspx");
            }
        }


    }
}