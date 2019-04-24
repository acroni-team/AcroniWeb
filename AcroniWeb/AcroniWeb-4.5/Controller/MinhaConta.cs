using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class MinhaConta
{
    SQLMetodos sql = new SQLMetodos();
    Utilitarios ut = new Utilitarios();
    Valida v = new Valida();
    public void pageLoad(TextBox Nome, TextBox CPF, TextBox CEP, TextBox Email, TextBox Usuario, TextBox Senha, Image fotoPerfil)
    {
        string urlFotoPerfil = "";
        List<string> campos = new List<string>();
        if (HttpContext.Current.Session["usuarioNovo"] != null)
        {
            campos = sql.selectCampos("nome, cpf, cep, email, usuario, senha", "tblCliente", "usuario = '" + HttpContext.Current.Session["usuarioNovo"] + "'");
            object imgObj = sql.selectImagem("imagem_cliente", "tblCliente", "usuario = '" + HttpContext.Current.Session["usuarioNovo"] + "'");
            if (!(imgObj == System.DBNull.Value))
                urlFotoPerfil = Convert.ToBase64String((byte[])imgObj);
        }
        else
        {
            campos = sql.selectCampos("nome, cpf, cep, email, usuario, senha", "tblCliente", "usuario = '" + HttpContext.Current.Session["usuario"] + "'");
            object imgObj = sql.selectImagem("imagem_cliente", "tblCliente", "usuario = '" + HttpContext.Current.Session["usuario"] + "'");
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
            fotoPerfil.ImageUrl = "assets/img/imgperf.jpeg";
        else
            fotoPerfil.ImageUrl = "data:image/jpg;base64," + urlFotoPerfil;
    }

    public void btnSalva(TextBox Nome, TextBox CPF, TextBox CEP, TextBox Email, TextBox Usuario, TextBox Senha, FileUpload FileUpload1, Label titleErro, Label msgErro, HtmlGenericControl modal, HtmlGenericControl modalback, HtmlGenericControl overflow, Label lblNome, Label lblCPF, Label lblCEP, Label lblEmail, Label lblUsuario)
    {
        string novosValores = "";
        bool first = false, IsImageUpload = false, userChanged = false, passChanged = false;

        if (!FileUpload1.HasFile)
        {
            HttpContext.Current.Session["novosValores"] = "";
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
                HttpFileCollection hfc = HttpContext.Current.Request.Files;
                System.Drawing.Image image = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);
                HttpPostedFile hpf = hfc[0];
                if (hpf.ContentLength > 0)
                {
                    byte[] imgBytes = null;
                    string ext = Path.GetExtension(hpf.FileName).ToLower();
                    if (ext == ".jpeg" || ext == ".jpg")
                        imgBytes = ut.ConvertImageToByteArray(image, System.Drawing.Imaging.ImageFormat.Jpeg);
                    else if (ext == ".png")
                        imgBytes = ut.ConvertImageToByteArray(image, System.Drawing.Imaging.ImageFormat.Png);
                    else if (ext == ".bmp")
                        imgBytes = ut.ConvertImageToByteArray(image, System.Drawing.Imaging.ImageFormat.Bmp);
                    else if (ext == ".tiff")
                        imgBytes = ut.ConvertImageToByteArray(image, System.Drawing.Imaging.ImageFormat.Tiff);
                    else if (ext == ".gif")
                        imgBytes = ut.ConvertImageToByteArray(image, System.Drawing.Imaging.ImageFormat.Gif);


                    sql.updateImagem(imgBytes, "tblCliente", "usuario = '" + HttpContext.Current.Session["usuario"] + "'");
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
                HttpContext.Current.Session["novosValores"] += "nome = '" + Nome.Text + "'";
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
                        HttpContext.Current.Session["novosValores"] += ",cpf = '" + CPF.Text + "'";

                    }
                    else
                    {
                        HttpContext.Current.Session["novosValores"] += "cpf = '" + CPF.Text + "'";
                        first = true;

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
                    HttpContext.Current.Session["novosValores"] += ",cep = '" + CEP.Text + "'";
                else
                {
                    HttpContext.Current.Session["novosValores"] += "cep = '" + CEP.Text + "'";
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
                        HttpContext.Current.Session["novosValores"] += ",email = '" + emailSemEspacos + "'";

                    }
                    else
                    {
                        HttpContext.Current.Session["novosValores"] += "email = '" + emailSemEspacos + "'";
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
                        HttpContext.Current.Session["novosValores"] += ",usuario = '" + usuSemEspacos + "'";
                    else
                    {
                        HttpContext.Current.Session["novosValores"] += "usuario = '" + usuSemEspacos + "'";
                        first = true;
                    }
                    HttpContext.Current.Session["usuarioNovo"] = usuSemEspacos;
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
                HttpContext.Current.Session["novosValores"] += ",senha = '" + Senha.Text + "'";
            else
            {
                HttpContext.Current.Session["novosValores"] += "senha = '" + Senha.Text + "'";
                first = true;
            }
            passChanged = true;
        }

        if (HttpContext.Current.Request.Cookies["credenciais"] != null)
        {
            if (userChanged && passChanged)
            {
                HttpCookie cookie = new HttpCookie("credenciais");
                cookie.Values["usuario"] = HttpContext.Current.Session["usuarioNovo"].ToString();
                cookie.Values["senha"] = Senha.Text;
                cookie.Expires = DateTime.Now.AddDays(365);
                HttpContext.Current.Response.Cookies.Add(cookie);
                userChanged = true;
            }
            else if (userChanged == true && passChanged == false)
            {
                string senha = HttpContext.Current.Request.Cookies["credenciais"]["senha"];
                HttpCookie cookie = new HttpCookie("credenciais");
                cookie.Values["usuario"] = HttpContext.Current.Session["usuarioNovo"].ToString();
                cookie.Values["senha"] = senha;
                cookie.Expires = DateTime.Now.AddDays(365);
                HttpContext.Current.Response.Cookies.Add(cookie);
                userChanged = true;
            }
            else if (userChanged == false && passChanged == true)
            {
                string usuario = HttpContext.Current.Request.Cookies["credenciais"]["usuario"];
                HttpCookie cookie = new HttpCookie("credenciais");
                cookie.Values["usuario"] = usuario;
                cookie.Values["senha"] = Senha.Text;
                cookie.Expires = DateTime.Now.AddDays(365);
                HttpContext.Current.Response.Cookies.Add(cookie);
                userChanged = true;
            }
        }
        if (first)
        {
            if (HttpContext.Current.Session["novosValores"].ToString().Contains("email"))
            {
                ut.showErrorMessage("Estamos quase lá.", "Um código foi enviado pro seu email. Agora é só colocar ele aqui.", titleErro, msgErro, modal, modalback, overflow);
                HttpContext.Current.Session["codigo-mudanca"] = ut.gerarStringConfirmacao();
                ut.enviarEmailConfirmacao(HttpContext.Current.Session["codigo-mudanca"].ToString(), emailSemEspacos, "Alterar email", "Seu email pode ser redefinido utilizando o código abaixo. Se você não pediu uma troca, finja que nunca nem viu esse email.");
                modal.Attributes["class"] = "modal-wrap minha-conta is-showing codigo";
                return;
            }
            else
            {
                sql.update("tblCliente", "usuario = '" + HttpContext.Current.Session["usuario"] + "'", HttpContext.Current.Session["novosValores"].ToString());
                HttpContext.Current.Response.Redirect("minha-conta.aspx");
            }
        }
        else if (IsImageUpload)
        {
            HttpContext.Current.Response.Redirect("minha-conta.aspx");
        }
    }

    public void btnValidaEmail(TextBox txtValidaEmail)
    {
        if (txtValidaEmail.Text.ToLower().Equals(HttpContext.Current.Session["codigo-mudanca"].ToString().ToLower()))
        {
            sql.update("tblCliente", "usuario = '" + HttpContext.Current.Session["usuario"] + "'", HttpContext.Current.Session["novosValores"].ToString());
            HttpContext.Current.Response.Redirect("minha-conta.aspx");
        }
    }

    public void btnAlteraPlano(HtmlInputButton button, Button btnReload, Label titleErro, Label msgErro, HtmlGenericControl modal, HtmlGenericControl modalback, HtmlGenericControl overflow)
    {
        button.Attributes.Add("style", "display:none");
        btnReload.Attributes.Add("style", "display:block;float:initial;margin: auto;");
        sql.update("tblCliente", "usuario = '" + HttpContext.Current.Session["usuario"] + "'", "tipoConta = 'p'");
        ut.showErrorMessage("Não era pra ser assim!", "Agora você é um usuário premium, usou de meios ilícitos mais é", titleErro, msgErro, modal, modalback, overflow);
    }

    public void btnExcluiConta()
    {
        List<string> id = sql.selectCampos("id_cliente", "tblCliente", "usuario = '" + HttpContext.Current.Session["usuario"] + "'");
        sql.delete("tblColecao", "id_cliente = " + id[0]);
        sql.delete("tblCliente", "id_cliente = " + id[0]);
        HttpContext.Current.Response.Redirect("default.aspx");
    }

}
