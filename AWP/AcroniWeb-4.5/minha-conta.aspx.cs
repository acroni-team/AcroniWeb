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
            else if (!(FileUpload1.PostedFile.ContentType == "image/jpg" ||
                       FileUpload1.PostedFile.ContentType == "image/png" ||
                       FileUpload1.PostedFile.ContentType == "image/bmp" ||
                       FileUpload1.PostedFile.ContentType == "image/tiff" ||
                       FileUpload1.PostedFile.ContentType == "image/gif" ||
                       FileUpload1.PostedFile.ContentType == "image/jpeg"))
            {
                showErrorMessage("Não é imagem", "Esse arquivo que você jogou ai não é uma imagem, por favor insira um arquivo que seja uma imagem");
            }
            else if (FileUpload1.PostedFile.ContentLength > 8388608)
            {
                showErrorMessage("Imagem muito grande", "Essa imagem que você colocou aí tem um tamanho muito grande. Por favor insira uma imagem menor que 8MB");
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

                        if (Path.GetExtension(hpf.FileName) == ".jpeg" || Path.GetExtension(hpf.FileName) == ".jpg")
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
                {
                    showErrorMessage("Nome inválido", "Não se esqueça que deve ser seu nome completo!");
                    return;
                }
                else if (v.validarNome(nomeSemEspacos))
                {
                    first = true;
                    novosValores += "nome = '" + Nome.Text + "'";
                }
                else
                {
                    showErrorMessage("Nome inválido", "Não se esqueça que deve ser seu nome completo!");
                    return;
                }
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
                    {
                        showErrorMessage("CPF em uso", "Provavelmente você já tem uma conta com esse CPF!");
                        return;
                    }
                }
                else
                {
                    showErrorMessage("CPF inválido", "Infelizmente esse CPF não é válido!");
                    return;
                }
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
                {
                    showErrorMessage("CEP inválido", "Relaxa, não vamos invadir sua casa.");
                    return;
                }
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
                    {
                        showErrorMessage("Email em uso", "Provavelmente você já tem uma conta com esse email!");
                        return;
                    }
                }
                else
                {
                    showErrorMessage("Email inválido", "Infelizmente esse email não é válido!");
                    return;
                }
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
                    {
                        showErrorMessage("Usuário em uso", "Outra pessoa também gosta desse nome de usuário :/");
                        return;
                    }
                }
                else
                {
                    showErrorMessage("Usuário inválido", "Apenas caracteres alfanuméricos, _ e - são permitidos aqui!");
                    return;
                }
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

        public void showErrorMessage(string title, string msg)
        {
            titleErro.Text = title;
            msgErro.Text = msg;
            modal.Attributes["class"] = "modal-wrap is-showing";
            modalback.Attributes.Add("style", "pointer-events:auto");
        }

    }
}