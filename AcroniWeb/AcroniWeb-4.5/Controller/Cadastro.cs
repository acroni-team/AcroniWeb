using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
public class Cadastro
{
    Utilitarios ut = new Utilitarios();
    Valida v = new Valida();

    public void pageLoad(bool IsPostBack, Label lblErro)
    {
        if (!IsPostBack)
        {
            HttpContext.Current.Session["usu"] = "";
            HttpContext.Current.Session["email"] = "";
            HttpContext.Current.Session["nome"] = "";
            HttpContext.Current.Session["cpf"] = "";
            HttpContext.Current.Session["senha"] = "";
            HttpContext.Current.Session["csenha"] = "";
            HttpContext.Current.Session["aux"] = 0;
            HttpContext.Current.Session["codigo"] = "";
        }
        lblErro.Text = "";
    }

    public void btnValida(TextBox txtNome, HtmlGenericControl border, TextBox txtUsu, HtmlGenericControl step, Label lblH1Dica, Label lblDica, TextBox txtEmail, TextBox txtCodigo, Button ReenviarEmail, TextBox txtCpf, TextBox txtSenha, TextBox txtCSenha, Label lblErro)
    {
        bool existe = true;
        //Switch case para cada caso do AUX
        //Se a validacão der erro, o AUX será o mesmo e assim caindo no mesmo caso até o usuário acertar
        switch (Convert.ToInt32(HttpContext.Current.Session["aux"]))
        {
            case 0:
                if (string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrWhiteSpace(txtNome.Text))
                {
                    IsNotValid(txtNome, "Nome completo inválido", 0, txtNome, lblErro, border);
                    break;
                }

                string nome = ut.retirarEspacos(txtNome.Text);

                if (!v.validarNome(nome) || !nome.Contains(" "))
                {
                    IsNotValid(txtNome, "Nome completo inválido", 0, txtNome, lblErro, border);
                    border.Attributes["class"] = "textbox-type2-overflow overflow-cad not-valid";
                    break;
                }
                else
                {
                    IsValid("nome", txtNome, txtUsu, 1, nome, lblErro, border);
                    step.Attributes["class"] = "step step1";
                    lblH1Dica.Text = "Hey, " + HttpContext.Current.Session["nome"] + "!";
                    lblDica.Text = "Defina um apelido pra você. <br/> Ele deve ter no mínimo 4 letras e caracteres especiais, exceto _ e - não são permitidos.";
                    break;
                }

            case 1:
                txtNome.Attributes["class"] = "textbox textbox-type2 textbox-cad";

                if (string.IsNullOrEmpty(txtUsu.Text) || string.IsNullOrWhiteSpace(txtUsu.Text))
                {
                    IsNotValid(txtNome, "Usuário deve ser preenchido.", 1, txtUsu, lblErro, border);
                    break;
                }

                string usuario = ut.retirarEspacos(txtUsu.Text);
                existe = ut.verificarCampoExistenteBanco("usuario", usuario);

                if (!v.validarUsu(usuario))
                {
                    IsNotValid(txtNome, "Esse apelido é inválido.", 1, txtUsu, lblErro, border);
                    break;
                }
                else if (existe)
                {
                    IsNotValid(txtNome, "Usuário já em uso.", 1, txtUsu, lblErro, border);
                    break;
                }
                else if (usuario.Contains(" "))
                {
                    IsNotValid(txtNome, "O usuário não pode conter espaços.", 1, txtUsu, lblErro, border);
                    break;
                }
                else
                {
                    IsValid("usu", txtUsu, txtEmail, 2, usuario, lblErro, border);
                    step.Attributes["class"] = "step step2";
                    lblH1Dica.Text = "Agora vamos te chamar de " + HttpContext.Current.Session["usu"] + ".";
                    lblDica.Text = "Agora insira seu melhor e-mail.";
                    break;
                }

            case 2:
                txtUsu.Attributes["class"] = "textbox textbox-type2 textbox-cad";

                if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    IsNotValid(txtUsu, "Email inválido.", 2, txtEmail, lblErro, border);
                    break;
                }

                string email = ut.retirarEspacos(txtEmail.Text);
                existe = ut.verificarCampoExistenteBanco("email", email);

                if (!v.validarEmail(email))
                {
                    IsNotValid(txtUsu, "Email inválido.", 2, txtEmail, lblErro, border);
                    break;
                }
                else if (existe)
                {
                    IsNotValid(txtUsu, "Email já em uso.", 2, txtEmail, lblErro, border);
                    break;
                }
                else
                {
                    IsValid("email", txtEmail, txtCodigo, 3, email, lblErro, border);
                    step.Attributes["class"] = "step step3";
                    HttpContext.Current.Session["email"] = email;
                    HttpContext.Current.Session["codigo"] = ut.gerarStringConfirmacao();
                    ut.enviarEmailConfirmacao(HttpContext.Current.Session["codigo"].ToString(), HttpContext.Current.Session["email"].ToString(), "Confirmar E-mail", "Utilize o código abaixo para corfimar seu email. Se você não está criando uma conta na Acroni, finja que nunca nem viu esse email.");
                    ReenviarEmail.Attributes.Add("style", "display: block");
                    lblH1Dica.Text = "Legal! Agora você só precisa confirmar que é você.";
                    lblDica.Text = "Confira o código no seu e-mail.";
                    break;
                }

            case 3:
                txtEmail.Attributes["class"] = "textbox textbox-type2 textbox-cad";
                ReenviarEmail.Attributes.Add("style", "display: block");

                if (!txtCodigo.Text.ToLower().Equals(HttpContext.Current.Session["codigo"].ToString().ToLower()))
                {
                    IsNotValid(txtEmail, "Os códigos não coincidem", 3, txtCodigo, lblErro, border);

                    break;
                }
                else if (!(txtCodigo.Text.ToLower().Equals(HttpContext.Current.Session["codigo"].ToString().ToLower())))
                {
                    IsNotValid(txtEmail, "Os códigos não coincidem", 3, txtCodigo, lblErro, border);
                    break;
                }
                else
                {
                    IsValid("codigo", txtCodigo, txtCpf, 4, lblErro, border);
                    step.Attributes["class"] = "step step4";
                    ReenviarEmail.Attributes.Add("style", "display: none");
                    lblH1Dica.Text = "Uma pessoa sempre tem um CPF.";
                    lblDica.Text = "Digita ele aí pra nós.";
                    break;
                }

            case 4:
                txtUsu.Attributes["class"] = "textbox textbox-type2 textbox-cad";
                txtCodigo.Attributes["class"] = "textbox textbox-type2 textbox-cad";
                ReenviarEmail.Attributes.Add("style", "display: none");

                if (!v.validarCPF(txtCpf.Text))
                {
                    IsNotValid(txtEmail, "CPF inválido", 4, txtCpf, lblErro, border);
                    break;
                }
                else if (ut.verificarCampoExistenteBanco("cpf", txtCpf.Text))
                {
                    IsNotValid(txtEmail, "CPF já cadastrado", 4, txtCpf, lblErro, border);
                    break;
                }
                else
                {
                    IsValid("cpf", txtCpf, txtSenha, 5, lblErro, border);
                    step.Attributes["class"] = "step step5";
                    lblH1Dica.Text = "E por fim, sua senha.";
                    lblDica.Text = "As senhas dos melhores tem mais de 8 dígitos, com letras maiúsculas e minúsculas, números e símbolos.";
                    break;
                }

            case 5:
                txtCpf.Attributes["class"] = "textbox textbox-type2 textbox-cad";

                if (txtSenha.Text == "" || string.IsNullOrWhiteSpace(txtSenha.Text))
                {
                    IsNotValid(txtEmail, "Campo de senha vazio :/", 5, txtSenha, lblErro, border);
                    break;
                }
                else
                {
                    IsValid("senha", txtSenha, txtCSenha, 6, lblErro, border);
                    lblH1Dica.Text = "Confirme sua senha.";
                    lblDica.Text = "Nunca se sabe as loucuras que a gente digita lá atrás.";
                    break;
                }

            case 6:
                txtSenha.Attributes["class"] = "textbox textbox-type2 textbox-cad";
                if (txtCSenha.Text != HttpContext.Current.Session["senha"].ToString())
                {
                    IsNotValid(txtCSenha, "As senhas não coincidem", 6, txtCSenha, lblErro, border);
                    break;
                }
                else
                {
                    ut.inserirUsuario(HttpContext.Current.Session["nome"].ToString(), HttpContext.Current.Session["usu"].ToString(), HttpContext.Current.Session["email"].ToString(), HttpContext.Current.Session["cpf"].ToString(), HttpContext.Current.Session["senha"].ToString());
                    HttpContext.Current.Response.Redirect("~/View/default.aspx");
                    break;
                }
        }
    }

    //Métodos para evitar a repeticão e enxutar o côdigo
    public void IsValid(string campoCadastrado, TextBox txtCampoCadastrado, TextBox txtProxCampo, int aux, Label lblErro, HtmlGenericControl border)
    {
        if (!campoCadastrado.Equals("codigo"))
            HttpContext.Current.Session[campoCadastrado] = txtCampoCadastrado.Text;

        txtCampoCadastrado.Text = "";
        lblErro.Text = "";
        txtCampoCadastrado.Attributes["class"] = "textbox textbox-type2 textbox-cad some";
        txtProxCampo.Attributes["class"] = "textbox textbox-type2 textbox-cad aparece animate-in";
        HttpContext.Current.Session["aux"] = aux;
        border.Attributes["class"] = "textbox-type2-overflow overflow-cad";
        txtCampoCadastrado.Attributes["active"] = "0";
        txtProxCampo.Attributes["active"] = "1";
    }

    //Overload para os campos que tem os espacos retirados (sistema retira espacos desnecessários)
    public void IsValid(string campoCadastrado, TextBox txtCampoCadastrado, TextBox txtProxCampo, int aux, string valCampoCadastrado, Label lblErro, HtmlGenericControl border)
    {
        HttpContext.Current.Session[campoCadastrado] = valCampoCadastrado;
        txtCampoCadastrado.Text = "";
        lblErro.Text = "";
        txtCampoCadastrado.Attributes["class"] = "textbox textbox-type2 textbox-cad some";
        txtProxCampo.Attributes["class"] = "textbox textbox-type2 textbox-cad aparece animate-in";
        HttpContext.Current.Session["aux"] = aux;
        border.Attributes["class"] = "textbox-type2-overflow overflow-cad";
        txtCampoCadastrado.Attributes["active"] = "0";
        txtProxCampo.Attributes["active"] = "1";
    }

    public void IsNotValid(TextBox txtCampoAnterior, string erro, int aux, TextBox txtCampoErrado, Label lblErro, HtmlGenericControl border)
    {
        txtCampoAnterior.Attributes["class"] = "textbox textbox-type2 textbox-cad";
        txtCampoErrado.Attributes["class"] = "textbox textbox-type2 textbox-cad aparece";
        txtCampoErrado.Text = "";
        border.Attributes["class"] = "textbox-type2-overflow overflow-cad not-valid";
        if (aux == 0)
        {
            lblErro.Text = erro;
            HttpContext.Current.Session["aux"] = aux;
        }
        else
        {
            txtCampoAnterior.Text = "";
            lblErro.Text = erro;
            HttpContext.Current.Session["aux"] = aux;
        }
    }

    public void ReenviarEmail(Label lblH1Dica, Label lblDica)
    {
        lblH1Dica.Text = "Esse tipo de coisa acontece.";
        lblDica.Text = "Relaxa,apenas confira o código no seu e-mail novamente.";
        HttpContext.Current.Session["codigo"] = ut.gerarStringConfirmacao();
        ut.enviarEmailConfirmacao(HttpContext.Current.Session["codigo"].ToString(), HttpContext.Current.Session["email"].ToString(), "Confirmar E-mail", "Utilize o código abaixo para corfimar seu email. Se você não está criando uma conta na Acroni, finja que nunca nem viu esse email.");
    }

    public void ReenviarImai()
    {
        HttpContext.Current.Session["codigo"] = ut.gerarStringConfirmacao();
        ut.enviarEmailConfirmacao(HttpContext.Current.Session["codigo"].ToString(), HttpContext.Current.Session["email"].ToString(), "Confirmar E-mail", "Utilize o código abaixo para corfimar seu email. Se você não está criando uma conta na Acroni, finja que nunca nem viu esse email.");
    }

    public void btnVoltar(TextBox txtNome, TextBox txtUsu, TextBox txtEmail, TextBox txtCpf, TextBox txtCodigo, TextBox txtSenha, TextBox txtCSenha, HtmlGenericControl step, Label lblH1Dica, Label lblDica)
    {
        if (txtNome.Attributes["class"].ToString() != "textbox textbox-type2 textbox-cad aparece")
        {
            HttpContext.Current.Session["aux"] = Convert.ToInt32(HttpContext.Current.Session["aux"]) - 1;
            if (txtUsu.Attributes["active"].ToString() == "1")
            {
                voltar(txtUsu, txtNome, "step", "Hey!", "Você está prestes a entrar pra família Acroni!", step, lblH1Dica, lblDica);
            }
            else if (txtEmail.Attributes["active"].ToString() == "1")
            {
                voltar(txtEmail, txtUsu, "step step1", "Hey, " + HttpContext.Current.Session["nome"] + "!", "Defina um apelido pra você. <br/> Ele deve ter no mínimo 4 letras e caracteres especiais, exceto _ e - não são permitidos.", step, lblH1Dica, lblDica);
            }
            else if (txtCodigo.Attributes["active"].ToString() == "1")
            {
                voltar(txtCodigo, txtEmail, "step step1 step2", "Agora vamos te chamar de " + HttpContext.Current.Session["usu"] + ".", "Agora insira seu melhor e-mail.", step, lblH1Dica, lblDica);
            }
            else if (txtCpf.Attributes["active"].ToString() == "1")
            {
                voltar(txtCpf, txtCodigo, "step step1 step2 step3", "Legal! Agora você só precisa confirmar que é você.", "Confira o código no seu e-mail.", step, lblH1Dica, lblDica);
            }
            else if (txtSenha.Attributes["active"].ToString() == "1")
            {
                voltar(txtSenha, txtCpf, "step step1 step2 step3 step4", "Uma pessoa sempre tem um CPF.", "Digita ele aí pra nós.", step, lblH1Dica, lblDica);
            }
            else if (txtCSenha.Attributes["active"].ToString() == "1")
            {
                voltar(txtCSenha, txtSenha, "step step1 step2 step3 step4 step5", "E por fim, sua senha.", "As senhas dos melhores tem mais de 8 dígitos, com letras maiúsculas e minúsculas, números e símbolos.", step, lblH1Dica, lblDica);
            }
        }
    }
    public void voltar(TextBox txtAtual, TextBox txtAnterior, string classesStep, string textH1, string textDica, HtmlGenericControl step, Label lblH1Dica, Label lblDica)
    {
        txtAtual.Attributes["class"] = "textbox textbox-type2 textbox-cad";
        txtAnterior.Attributes["class"] = "textbox textbox-type2 textbox-cad aparece";
        txtAtual.Attributes["active"] = "0";
        txtAnterior.Attributes["active"] = "1";
        step.Attributes["class"] = classesStep;
        lblH1Dica.Text = textH1;
        lblDica.Text = textDica;
    }

}
