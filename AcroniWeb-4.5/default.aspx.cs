using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Threading;

namespace AcroniWeb
{
    public partial class _default1 : System.Web.UI.Page
    {
        Utilitarios ut = new Utilitarios();
        SQLMetodos sql = new SQLMetodos();
        public string stringConfirmacao;
        string email = "";
        public string Email { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["logado"] = "0";

            HttpCookie cookie = Request.Cookies["credenciais"];
            if (cookie != null)
            {
                string[] valores = cookie.Value.ToString().Split('&');

                if (sql.selectHasRows("*", "tblCliente", "usuario='" + valores[0].Replace("usuario=", "") + "' AND senha='" + valores[1].Replace("senha=", "") + "'"))
                {
                    Session["usuario"] = valores[0].Replace("usuario=", "");
                    Session["logado"] = "1";
                    Response.Redirect("galeria.aspx");
                }
            }
        }

        protected void btnIrCad_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadastro.aspx");
        }

        protected void btnEntra_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsu.Text) && !string.IsNullOrEmpty(txtPass.Text))
            {
                try
                {
                    if (sql.selectHasRows("*", "tblCliente", "usuario='" + txtUsu.Text + "'"))
                    {
                        txtUsu.Attributes.Add("style", "border-color:#0093ff");

                        if (sql.selectHasRows("usuario", "tblCliente", "senha='" + txtPass.Text + "' and usuario='" + txtUsu.Text + "'"))
                        {
                            Session["logado"] = "1";
                            Session["usuario"] = txtUsu.Text;
                            if (ckbLogin.Checked)
                            {
                                HttpCookie cookie = Request.Cookies["credenciais"];
                                if (cookie == null)
                                {
                                    cookie = new HttpCookie("credenciais");
                                    cookie.Values.Add("usuario", txtUsu.Text);
                                    cookie.Values.Add("senha", txtPass.Text);
                                    cookie.Expires = DateTime.Now.AddDays(365);
                                    cookie.HttpOnly = true;
                                    this.Page.Response.AppendCookie(cookie);
                                }
                            }
                            Response.Redirect("galeria.aspx");
                            txtPass.Attributes.Add("style", "border-color:#0093ff");
                        }
                        else
                        {
                            lblMsg.Text = "Senha incorreta";
                            lblMsg.ForeColor = System.Drawing.Color.Red;
                            txtPass.Attributes.Add("style", "border-color:red");
                            Session["logado"] = "0";
                        }
                    }
                    else
                    {
                        lblMsg.Text = "Usuário e senha incorretos";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        txtUsu.Attributes.Add("style", "border-color:red");
                        txtPass.Attributes.Add("style", "border-color:red");
                        Session["logado"] = "0";
                    }
                }
                catch { }
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
                Session["logado"] = "0";
            }
            SCPanel.Update();
        }


        Regex validacao_email = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            step1.Attributes["class"] = "modal-body modal-body-step1 is-showing";
            bool existe = true;

            if (sql.selectHasRows("usuario", "tblCliente", "email = '" + txtEmail.Text + "'"))
                existe = true;
            else
                existe = false;

            if (validacao_email.IsMatch(txtEmail.Text) && existe)
            {
                txtEmail.Attributes.Add("style", "border-color:#0093ff");
                lblErro1.Text = "";
                modal.Attributes["class"] = "modal-wrap is-showing";
                step1.Attributes["class"] = "modal-body modal-body-step1 is-showing animate-out";
                step2.Attributes["class"] = "modal-body modal-body-step2 is-showing animate-in";
                Session["email"] = txtEmail.Text;
                Session["codigo"] = ut.gerarStringConfirmacao();
                ut.enviarEmailConfirmacao(Session["codigo"].ToString(), Session["email"].ToString());
            }
            else
            {
                lblErro1.Text = "Acho que você tem que colocar o e-mail que registrou antes";
                lblErro1.ForeColor = System.Drawing.Color.Red;
                txtEmail.Attributes.Add("style", "border-color:red");
            }
            SCPanel2.Update();
        }

        protected void btnSendCode_Click(object sender, EventArgs e)
        {
            step2.Attributes["class"] = "modal-body modal-body-step2 is-showing";
            if (txtCodigo.Text.ToLower().Equals(Session["codigo"].ToString().ToLower()))
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
            SCPanel2.Update();
        }

        protected void btnTrocaSenha_Click(object sender, EventArgs e)
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
                sql.update("senha", "tblCliente", "email = '" + Session["email"] + "'", txtSenha.Text);
                Response.Redirect("default.aspx");
            }
            else
            {
                lblErro3.Text = "As senhas não estão iguais.";
                lblErro3.ForeColor = System.Drawing.Color.Red;
                txtSenha.Attributes.Add("style", "border-color:red");
                txtCSenha.Attributes.Add("style", "border-color:red");
            }
            SCPanel2.Update();
        }
    }
}
