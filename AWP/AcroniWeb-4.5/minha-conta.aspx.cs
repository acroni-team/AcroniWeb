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
                if (!(imgObj == System.DBNull.Value))
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
                Session["novosValores"] = "";
            }
            else if (!(FileUpload1.PostedFile.ContentType == "image/jpg" ||
                       FileUpload1.PostedFile.ContentType == "image/png" ||
                       FileUpload1.PostedFile.ContentType == "image/bmp" ||
                       FileUpload1.PostedFile.ContentType == "image/tiff" ||
                       FileUpload1.PostedFile.ContentType == "image/gif" ||
                       FileUpload1.PostedFile.ContentType == "image/jpeg"))
            {
                ut.showErrorMessage("Não é imagem", "Esse arquivo que você jogou ai não é uma imagem, por favor insira um arquivo que seja uma imagem", titleErro, msgErro, modal, modalback, overflow);
            }
            else if (FileUpload1.PostedFile.ContentLength > 8388608)
            {
                ut.showErrorMessage("Imagem muito grande", "Essa imagem que você colocou aí tem um tamanho muito grande. Por favor insira uma imagem menor que 8MB", titleErro, msgErro, modal, modalback, overflow);
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
                    ut.showErrorMessageByLbl("Nome Completo - Inválido, deve estar completo", Nome, lblNome);
                    return;
                }
                else if (v.validarNome(nomeSemEspacos))
                {
                    first = true;
                    Session["novosValores"] += "nome = '" + Nome.Text + "'";
                }
                else
                {
                    ut.showErrorMessageByLbl("Nome Completo - Inválido, deve estar completo", Nome, lblNome);
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
                        {
                            Session["novosValores"] += ",cpf = '" + CPF.Text + "'";
                            return;
                        }
                        else
                        {
                            Session["novosValores"] += "cpf = '" + CPF.Text + "'";
                            first = true;
                            return;
                        }
                    }
                    else
                    {
                        ut.showErrorMessageByLbl("CPF - Em uso, já tem uma conta com esse CPF", CPF, lblCPF);
                        return;
                    }
                }
                else
                {
                    ut.showErrorMessageByLbl("CPF - Invalido, este cpf não é valido", CPF, lblCPF);
                    return;
                }
            }

            if (!string.IsNullOrEmpty(CEP.Text))
            {
                if (v.validarCep(CEP.Text))
                {
                    if (first)
                        Session["novosValores"] += ",cep = '" + CEP.Text + "'";
                    else
                    {
                        Session["novosValores"] += "cep = '" + CEP.Text + "'";
                        first = true;
                    }
                }
                else
                {
                    ut.showErrorMessageByLbl("CEP - Inválido, Relaxa, não vamos invadir sua casa.", CEP, lblCEP);
                    return;
                }
            }

            string emailSemEspacos = "";
            if (!string.IsNullOrEmpty(Email.Text))
            {
                emailSemEspacos = ut.retirarEspacos(Email.Text);
                if (v.validarEmail(emailSemEspacos))
                {
                    if (!sql.selectHasRows("*", "tblCliente", "email = '" + emailSemEspacos + "'"))
                    {
                        if (first)
                        {
                            Session["novosValores"] += ",email = '" + emailSemEspacos + "'";
                            
                        }
                        else
                        {
                            Session["novosValores"] += "email = '" + emailSemEspacos + "'";
                            first = true;
                            
                        }
                    }
                    else
                    {
                        ut.showErrorMessageByLbl("E-mail - Em uso, já tem uma conta com esse e-mail", Email, lblEmail);
                        return;
                    }
                }
                else
                {
                    ut.showErrorMessageByLbl("E-mail - Invalido, esse e-mail não é valido", Email, lblEmail);
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
                            Session["novosValores"] += ",usuario = '" + usuSemEspacos + "'";
                        else
                        {
                            Session["novosValores"] += "usuario = '" + usuSemEspacos + "'";
                            first = true;
                        }
                        Session["usuarioNovo"] = usuSemEspacos;
                        userChanged = true;
                    }
                    else
                    {
                        ut.showErrorMessageByLbl("Usuário - Em uso, já existe uma conta com esse usuário :/", Usuario, lblUsuario);
                        return;
                    }
                }
                else
                {
                    ut.showErrorMessageByLbl("Usuário - Deve ter apenas letras,numeros, _ e -", Usuario, lblUsuario);
                    return;
                }
            }

            if (!string.IsNullOrEmpty(Senha.Text))
            {
                if (first)
                    Session["novosValores"] += ",senha = '" + Senha.Text + "'";
                else
                {
                    Session["novosValores"] += "senha = '" + Senha.Text + "'";
                    first = true;
                }
                passChanged = true;
            }

            if (Request.Cookies["credenciais"] != null)
            {
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
            }
            if (first)
            {
                if (Session["novosValores"].ToString().Contains("email"))
                {
                    ut.showErrorMessage("Estamos quase lá.", "Um código foi enviado pro seu email. Agora é só colocar ele aqui.", titleErro, msgErro, modal, modalback, overflow);
                    Session["codigo-mudanca"] = ut.gerarStringConfirmacao();
                    ut.enviarEmailConfirmacao(Session["codigo-mudanca"].ToString(), emailSemEspacos, "Alterar email", "Seu email pode ser redefinido utilizando o código abaixo. Se você não pediu uma troca, finja que nunca nem viu esse email.");
                    modal.Attributes["class"] = "modal-wrap minha-conta is-showing codigo";
                    return;
                }
                else
                {
                    sql.update("tblCliente", "usuario = '" + Session["usuario"] + "'", Session["novosValores"].ToString());
                    Response.Redirect("minha-conta.aspx");
                }
            }
            else if (IsImageUpload)
            {
                Response.Redirect("minha-conta.aspx");
            }
        }

        protected void btnValidaEmail_Click(object sender, EventArgs e)
        {
            if (txtValidaEmail.Text.ToLower().Equals(Session["codigo-mudanca"].ToString().ToLower()))
            {
                sql.update("tblCliente", "usuario = '" + Session["usuario"] + "'", Session["novosValores"].ToString());
                Response.Redirect("minha-conta.aspx");
            }
        }

        //Alterar plano lol
        protected void btnAltera_Click(object sender, EventArgs e)
        {
            button.Attributes.Add("style", "display:none");
            btnReload.Attributes.Add("style", "display:block;float:initial;margin: auto;");
            sql.update("tblCliente", "usuario = '" + Session["usuario"] + "'", "tipoConta = 'p'");
            ut.showErrorMessage("Não era pra ser assim!", "Agora você é um usuário premium, usou de meios ilícitos mais é", titleErro, msgErro, modal, modalback, overflow);
        }

        protected void btnReload_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnExcluiConta_Click(object sender, EventArgs e)
        {
            List<string> id = sql.selectCampos("id_cliente", "tblCliente", "usuario = '" + Session["usuario"] + "'");
            sql.delete("tblColecao", "id_cliente = " + id[0]);
            sql.delete("tblCliente", "id_cliente = " + id[0]);
            Response.Redirect("default.aspx");
        }

    }
}