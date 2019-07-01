using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public class Default
{
    SQLMetodos sql = new SQLMetodos();
    Utilitarios ut = new Utilitarios();
    public void pageLoad()
    {
        sql.update("tblVisita", "1=1", "cont = cont + 1");
        if (Environment.MachineName.Equals("PALMA-PC"))
        {
            Conexao.param = "Data Source = " + Environment.MachineName + "; Initial Catalog = ACRONI_SQL; User ID = Acroni; Password = acroni7";
            Conexao.nome_conexao = "Data Source = " + Environment.MachineName + "; Initial Catalog = ACRONI_SQL; User ID = Acroni; Password = acroni7";
        }
        System.Web.HttpContext.Current.Session["logado"] = "0";

        if (System.Web.HttpContext.Current.Request.Cookies["credenciais"] != null)
        {
            if (sql.selectHasRows("*", "tblCliente", "usuario='" + System.Web.HttpContext.Current.Request.Cookies["credenciais"]["usuario"] + "' AND senha='" + HttpContext.Current.Request.Cookies["credenciais"]["senha"] + "'"))
            {
                HttpContext.Current.Session["usuario"] = System.Web.HttpContext.Current.Request.Cookies["credenciais"]["usuario"];
                HttpContext.Current.Session["logado"] = "1";
                HttpContext.Current.Response.Redirect("~/View/galeria.aspx");
            }
        }
    }
    public void btnEntra(TextBox txtUsu, TextBox txtPass, CheckBox ckbLogin, Label lblMsg)
    {
        if (!string.IsNullOrEmpty(txtUsu.Text) && !string.IsNullOrEmpty(txtPass.Text))
        {
            if (!txtUsu.Text.Contains("@"))
            {
                try
                {
                    if (sql.selectHasRows("*", "tblCliente", "usuario='" + txtUsu.Text + "'"))
                    {
                        txtUsu.Attributes.Add("style", "border-color:#0093ff");

                        if (sql.selectHasRows("usuario", "tblCliente", "senha='" + txtPass.Text + "' and usuario='" + txtUsu.Text + "'"))
                        {
                            HttpContext.Current.Session["logado"] = "1";
                            HttpContext.Current.Session["usuario"] = txtUsu.Text;
                            if (ckbLogin.Checked)
                            {
                                HttpCookie cookie = new HttpCookie("credenciais");
                                cookie.Values["usuario"] = txtUsu.Text;
                                cookie.Values["senha"] = txtPass.Text;
                                cookie.Expires = DateTime.Now.AddDays(365);
                                HttpContext.Current.Response.Cookies.Add(cookie);
                            }
                            HttpContext.Current.Response.Redirect("~/View/galeria.aspx");
                            txtPass.Attributes.Add("style", "border-color:#0093ff");
                        }
                        else
                        {
                            lblMsg.Text = "Senha incorreta";
                            lblMsg.ForeColor = System.Drawing.Color.Red;
                            txtPass.Attributes.Add("style", "border-color:red");
                            HttpContext.Current.Session["logado"] = "0";
                        }
                    }
                    else
                    {
                        lblMsg.Text = "Usuário e senha incorretos";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        txtUsu.Attributes.Add("style", "border-color:red");
                        txtPass.Attributes.Add("style", "border-color:red");
                        HttpContext.Current.Session["logado"] = "0";
                    }
                }
                catch { }
            }
            else
            {
                try
                {
                    if (sql.selectHasRows("*", "tblCliente", "email='" + txtUsu.Text + "'"))
                    {
                        txtUsu.Attributes.Add("style", "border-color:#0093ff");

                        if (sql.selectHasRows("usuario", "tblCliente", "senha='" + txtPass.Text + "' and email='" + txtUsu.Text + "'"))
                        {
                            HttpContext.Current.Session["logado"] = "1";

                            HttpContext.Current.Session["usuario"] = sql.selectCampos("usuario", "tblCliente", "email= '" + txtUsu.Text + "'")[0];
                            if (ckbLogin.Checked)
                            {
                                HttpCookie cookie = new HttpCookie("credenciais");
                                cookie.Values["usuario"] = HttpContext.Current.Session["usuario"].ToString();
                                cookie.Values["senha"] = txtPass.Text;
                                cookie.Expires = DateTime.Now.AddDays(365);
                                HttpContext.Current.Response.Cookies.Add(cookie);
                            }
                            HttpContext.Current.Response.Redirect("~/View/galeria.aspx");
                            txtPass.Attributes.Add("style", "border-color:#0093ff");
                        }
                        else
                        {
                            lblMsg.Text = "Senha incorreta";
                            lblMsg.ForeColor = System.Drawing.Color.Red;
                            txtPass.Attributes.Add("style", "border-color:red");
                            HttpContext.Current.Session["logado"] = "0";
                        }
                    }
                    else
                    {
                        lblMsg.Text = "Usuário e senha incorretos";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        txtUsu.Attributes.Add("style", "border-color:red");
                        txtPass.Attributes.Add("style", "border-color:red");
                        HttpContext.Current.Session["logado"] = "0";
                    }
                }
                catch { }
            }
        }
        else
        {
            lblMsg.Text = "Campo vazio";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            if (string.IsNullOrEmpty(txtUsu.Text))
                txtUsu.Attributes.Add("style", "border-color:red");
            else
                txtUsu.Attributes.Remove("style");
            if (string.IsNullOrEmpty(txtPass.Text))
                txtPass.Attributes.Add("style", "border-color:red");
            else
                txtPass.Attributes.Remove("style");
            HttpContext.Current.Session["logado"] = "0";
        }
    }

    public void btnSendEmail(HtmlGenericControl step1, TextBox txtEmail, Label lblErro1, HtmlGenericControl step2, HtmlGenericControl modal)
    {
        step1.Attributes["class"] = "modal-body modal-body-step1 is-showing";
        bool existe = true;

        if (sql.selectHasRows("usuario", "tblCliente", "email = '" + txtEmail.Text + "'"))
            existe = true;
        else
            existe = false;
        Regex validacao_email = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        if (validacao_email.IsMatch(txtEmail.Text) && existe)
        {
            txtEmail.Attributes.Add("style", "border-color:#0093ff");
            lblErro1.Text = "";
            modal.Attributes["class"] = "modal-wrap is-showing";
            step1.Attributes["class"] = "modal-body modal-body-step1 is-showing animate-out";
            step2.Attributes["class"] = "modal-body modal-body-step2 is-showing animate-in";
            HttpContext.Current.Session["email"] = txtEmail.Text;
            HttpContext.Current.Session["codigo"] = ut.gerarStringConfirmacao();
            ut.enviarEmailConfirmacao(HttpContext.Current.Session["codigo"].ToString(), HttpContext.Current.Session["email"].ToString(), "Alterar senha", "Sua senha pode ser redefinida utilizando o código abaixo. Se você não pediu uma troca, finja que nunca nem viu esse email.");
        }
        else
        {
            lblErro1.Text = "Acho que você tem que colocar o e-mail que registrou antes";
            lblErro1.ForeColor = System.Drawing.Color.Red;
            txtEmail.Attributes.Add("style", "border-color:red");
        }
    }

    public void btnSendCode(HtmlGenericControl step2, TextBox txtCodigo, Label lblErro1, HtmlGenericControl modal, HtmlGenericControl step3, HtmlGenericControl overflow, Button btnSendCode, Label lblErro2)
    {
        step2.Attributes["class"] = "modal-body modal-body-step2 is-showing";
        if (txtCodigo.Text.ToLower().Equals(HttpContext.Current.Session["codigo"].ToString().ToLower()))
        {
            txtCodigo.Attributes.Add("style", "border-color:#0093ff");
            lblErro1.Text = "";
            modal.Attributes["class"] = "modal-wrap is-showing";
            step2.Attributes["class"] = "modal-body modal-body-step2 is-showing animate-out";
            step3.Attributes["class"] = "modal-body modal-body-step3 is-showing animate-in";
            overflow.Attributes.Add("style", "height: 350px");
            btnSendCode.Attributes.Add("style", "display:none");
            txtCodigo.Attributes.Add("style", "display:none");
        }
        else
        {
            lblErro2.Text = "Eu tenho a impressão de que esse não é o código";
            lblErro2.ForeColor = System.Drawing.Color.Red;
            txtCodigo.Attributes.Add("style", "border-color:red");
        }
    }

    public void btnTrocaSenha(HtmlGenericControl step2, HtmlGenericControl step3, TextBox txtSenha, Label lblErro3, TextBox txtCSenha)
    {
        step2.Attributes["class"] = "modal-body modal-body-step2";
        step3.Attributes["class"] = "modal-body modal-body-step3 is-showing";

        if (string.IsNullOrEmpty(txtSenha.Text) || string.IsNullOrWhiteSpace(txtSenha.Text))
        {
            lblErro3.Text = "Você tem que digitar uma senha";
            lblErro3.ForeColor = System.Drawing.Color.Red;
            txtSenha.Attributes.Add("style", "border-color:red");
            txtCSenha.Attributes.Add("style", "border-color:red");
        }
        else if (txtSenha.Text.Equals(txtCSenha.Text))
        {
            sql.update("tblCliente", "email = '" + HttpContext.Current.Session["email"] + "'", "senha = '" + txtSenha.Text + "'");
            HttpContext.Current.Response.Redirect("~/View/default.aspx");
        }
        else
        {
            lblErro3.Text = "As senhas não estão iguais.";
            lblErro3.ForeColor = System.Drawing.Color.Red;
            txtSenha.Attributes.Add("style", "border-color:red");
            txtCSenha.Attributes.Add("style", "border-color:red");
        }
    }

    

}



