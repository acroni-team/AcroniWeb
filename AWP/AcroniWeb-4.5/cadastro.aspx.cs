using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcroniWeb_4._5
{
    public partial class cadastro : System.Web.UI.Page
    {
        Valida v = new Valida();
        Utilitarios ut = new Utilitarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Se a página estiver loadando pela primeira vez, inicializar as 'variáveis' e o AUX
            if (!IsPostBack)
            {
                Session["usu"] = "";
                Session["email"] = "";
                Session["nome"] = "";
                Session["cpf"] = "";
                Session["senha"] = "";
                Session["csenha"] = "";
                Session["aux"] = 0;
                Session["codigo"] = "";
            }
            lblErro.Text = "";
            
     
        }
               
        protected void btnValida_Click(object sender, EventArgs e)
        {
            bool existe = true;
            //Switch case para cada caso do AUX
            //Se a validacão der erro, o AUX será o mesmo e assim caindo no mesmo caso até o usuário acertar
            switch (Convert.ToInt32(Session["aux"]))
            {
                case 0:
                    if (string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrWhiteSpace(txtNome.Text))
                    {
                        IsNotValid(txtNome, "Nome completo inválido", 0, txtNome);
                        break;
                    }

                    string nome = ut.retirarEspacos(txtNome.Text);

                    if (!v.validarNome(nome) || !nome.Contains(" "))
                    {
                        IsNotValid(txtNome, "Nome completo inválido", 0, txtNome);
                        border.Attributes["class"] = "textbox-type2-overflow overflow-cad not-valid";
                        break;
                    }
                    else
                    {
                        IsValid("nome", txtNome, txtUsu, 1, nome);
                        step.Attributes["class"] = "step step1";
                        lblH1Dica.Text = "Hey, " + Session["nome"] + "!";
                        lblDica.Text = "Defina um apelido pra você. <br/> Ele deve ter no mínimo 4 letras e caracteres especiais, exceto _ e - não são permitidos.";
                        break;
                    }
                    
                case 1:
                    txtNome.Attributes["class"] = "textbox textbox-type2 textbox-cad";

                    if (string.IsNullOrEmpty(txtUsu.Text) || string.IsNullOrWhiteSpace(txtUsu.Text))
                    {
                        IsNotValid(txtNome, "Usuário deve ser preenchido.", 1, txtUsu);
                        break;
                    }

                    string usuario = ut.retirarEspacos(txtUsu.Text);
                    existe = ut.verificarCampoExistenteBanco("usuario", usuario);
                    
                    if (!v.validarUsu(usuario))
                    {
                        IsNotValid(txtNome, "Esse apelido é inválido.", 1, txtUsu);
                        break;
                    }
                    else if (existe)
                    {
                        IsNotValid(txtNome, "Usuário já em uso.", 1, txtUsu);
                        break;
                    }
                    else if (usuario.Contains(" "))
                    {
                        IsNotValid(txtNome, "O usuário não pode conter espaços.", 1, txtUsu);
                        break;
                    }
                    else
                    {
                        IsValid("usu", txtUsu, txtEmail, 2, usuario);
                        step.Attributes["class"] = "step step2";
                        lblH1Dica.Text = "Agora vamos te chamar de " + Session["usu"] + ".";
                        lblDica.Text = "Agora insira seu melhor e-mail.";
                        break;
                    }
                    
                case 2:
                    txtUsu.Attributes["class"] = "textbox textbox-type2 textbox-cad";

                    if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
                    {
                        IsNotValid(txtUsu, "Email inválido.", 2, txtEmail);
                        break;
                    }

                    string email = ut.retirarEspacos(txtEmail.Text);
                    existe = ut.verificarCampoExistenteBanco("email", email);

                    if (!v.validarEmail(email))
                    {
                        IsNotValid(txtUsu, "Email inválido.", 2, txtEmail);
                        break;
                    }
                    else if (existe)
                    {
                        IsNotValid(txtUsu, "Email já em uso.", 2, txtEmail);
                        break;
                    }
                    else
                    {
                        IsValid("email", txtEmail, txtCodigo, 3, email);
                        step.Attributes["class"] = "step step3";
                        Session["email"] = email;
                        Session["codigo"] = ut.gerarStringConfirmacao();
                        ut.enviarEmailConfirmacao(Session["codigo"].ToString(), Session["email"].ToString(), "Confirmar E-mail", "Utilize o código abaixo para corfimar seu email. Se você não está criando uma conta na Acroni, finja que nunca nem viu esse email.");
                        ReenviarEmail.Attributes.Add("style", "display: block");
                        lblH1Dica.Text = "Legal! Agora você só precisa confirmar que é você.";
                        lblDica.Text = "Confira o código no seu e-mail.";
                        break;
                    }

                case 3:
                    txtEmail.Attributes["class"] = "textbox textbox-type2 textbox-cad";
                    ReenviarEmail.Attributes.Add("style", "display: block");

                    if (!txtCodigo.Text.ToLower().Equals(Session["codigo"].ToString().ToLower()))
                    {
                        IsNotValid(txtEmail, "Os códigos não coincidem", 3, txtCodigo);
                        
                        break;
                    }
                    else if (!(txtCodigo.Text.ToLower().Equals(Session["codigo"].ToString().ToLower())))
                    {
                        IsNotValid(txtEmail, "Os códigos não coincidem", 3, txtCodigo);
                        break;
                    }
                    else
                    {
                        IsValid("codigo", txtCodigo, txtCpf, 4);
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
                        IsNotValid(txtEmail, "CPF inválido", 4, txtCpf);
                        break;
                    }
                    else if (ut.verificarCampoExistenteBanco("cpf", txtCpf.Text))
                    {
                        IsNotValid(txtEmail, "CPF já cadastrado", 4, txtCpf);
                        break;
                    }
                    else
                    {
                        IsValid("cpf", txtCpf, txtSenha, 5);
                        step.Attributes["class"] = "step step5";
                        lblH1Dica.Text = "E por fim, sua senha.";
                        lblDica.Text = "As senhas dos melhores tem mais de 8 dígitos, com letras maiúsculas e minúsculas, números e símbolos.";
                        break;
                    }

                case 5:
                    txtCpf.Attributes["class"] = "textbox textbox-type2 textbox-cad";
                    
                    if (txtSenha.Text == "" || string.IsNullOrWhiteSpace(txtSenha.Text))
                    {
                        IsNotValid(txtEmail, "Campo de senha vazio :/", 5, txtSenha);
                        break;
                    }
                    else
                    {
                        IsValid("senha", txtSenha, txtCSenha, 6);
                        lblH1Dica.Text = "Confirme sua senha.";
                        lblDica.Text = "Nunca se sabe as loucuras que a gente digita lá atrás.";
                        break;
                    }

                case 6:
                    txtSenha.Attributes["class"] = "textbox textbox-type2 textbox-cad";
                    if (txtCSenha.Text != Session["senha"].ToString())
                    {
                        IsNotValid(txtCSenha, "As senhas não coincidem", 6, txtCSenha);
                        break;
                    }
                    else
                    {
                        ut.inserirUsuario(Session["nome"].ToString(), Session["usu"].ToString(), Session["email"].ToString(), Session["cpf"].ToString(), Session["senha"].ToString());
                        Response.Redirect("default.aspx");
                        break;
                    }
            }
        }
        
        //Métodos para evitar a repeticão e enxutar o côdigo
        public void IsValid (string campoCadastrado, TextBox txtCampoCadastrado, TextBox txtProxCampo, int aux)
        {
            if (!campoCadastrado.Equals("codigo")) 
                Session[campoCadastrado] = txtCampoCadastrado.Text;

            txtCampoCadastrado.Text = "";
            lblErro.Text = "";
            txtCampoCadastrado.Attributes["class"] = "textbox textbox-type2 textbox-cad some";
            txtProxCampo.Attributes["class"] = "textbox textbox-type2 textbox-cad aparece animate-in";
            Session["aux"] = aux;
            border.Attributes["class"] = "textbox-type2-overflow overflow-cad";
            txtCampoCadastrado.Attributes["active"] = "0";
            txtProxCampo.Attributes["active"] = "1";
        }

        //Overload para os campos que tem os espacos retirados (sistema retira espacos desnecessários)
        public void IsValid(string campoCadastrado, TextBox txtCampoCadastrado, TextBox txtProxCampo, int aux, string valCampoCadastrado)
        {
            Session[campoCadastrado] = valCampoCadastrado;
            txtCampoCadastrado.Text = "";
            lblErro.Text = "";
            txtCampoCadastrado.Attributes["class"] = "textbox textbox-type2 textbox-cad some";
            txtProxCampo.Attributes["class"] = "textbox textbox-type2 textbox-cad aparece animate-in";
            Session["aux"] = aux;
            border.Attributes["class"] = "textbox-type2-overflow overflow-cad";
            txtCampoCadastrado.Attributes["active"] = "0";
            txtProxCampo.Attributes["active"] = "1";
        }

        public void IsNotValid (TextBox txtCampoAnterior, string erro, int aux, TextBox txtCampoErrado)
        {
            txtCampoAnterior.Attributes["class"] = "textbox textbox-type2 textbox-cad";
            txtCampoErrado.Attributes["class"] = "textbox textbox-type2 textbox-cad aparece";
            txtCampoErrado.Text = "";
            border.Attributes["class"] = "textbox-type2-overflow overflow-cad not-valid";
            if (aux == 0)
            {
                lblErro.Text = erro;
                Session["aux"] = aux;
            }
            else
            {
                txtCampoAnterior.Text = "";
                lblErro.Text = erro;
                Session["aux"] = aux;
            }
        }

        protected void ReenviarEmail_Click(object sender, EventArgs e)
        {
            lblH1Dica.Text = "Esse tipo de coisa acontece.";
            lblDica.Text = "Relaxa,apenas confira o código no seu e-mail novamente.";
            Session["codigo"] = ut.gerarStringConfirmacao();
            ut.enviarEmailConfirmacao(Session["codigo"].ToString(), Session["email"].ToString(), "Confirmar E-mail", "Utilize o código abaixo para corfimar seu email. Se você não está criando uma conta na Acroni, finja que nunca nem viu esse email.");

        }

        protected void ReenviaImai_Click(object sender, EventArgs e)
        {
            Session["codigo"] = ut.gerarStringConfirmacao();
            ut.enviarEmailConfirmacao(Session["codigo"].ToString(), Session["email"].ToString(), "Confirmar E-mail", "Utilize o código abaixo para corfimar seu email. Se você não está criando uma conta na Acroni, finja que nunca nem viu esse email.");
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            if (txtNome.Attributes["class"].ToString() != "textbox textbox-type2 textbox-cad aparece")
            {
                Session["aux"] = Convert.ToInt32(Session["aux"]) - 1;
                if (txtUsu.Attributes["active"].ToString() == "1")
                {
                    voltar(txtUsu, txtNome, "step", "Hey!", "Você está prestes a entrar pra família Acroni!");
                }
                else if (txtEmail.Attributes["active"].ToString() == "1")
                {
                    voltar(txtEmail, txtUsu, "step step1", "Hey, " + Session["nome"] + "!", "Defina um apelido pra você. <br/> Ele deve ter no mínimo 4 letras e caracteres especiais, exceto _ e - não são permitidos.");
                }
                else if (txtCodigo.Attributes["active"].ToString() == "1")
                {
                    voltar(txtCodigo, txtEmail, "step step1 step2", "Agora vamos te chamar de " + Session["usu"] + ".", "Agora insira seu melhor e-mail.");
                }
                else if (txtCpf.Attributes["active"].ToString() == "1")
                {
                    voltar(txtCpf, txtCodigo, "step step1 step2 step3", "Legal! Agora você só precisa confirmar que é você.", "Confira o código no seu e-mail.");
                }
                else if (txtSenha.Attributes["active"].ToString() == "1")
                {
                    voltar(txtSenha, txtCpf, "step step1 step2 step3 step4", "Uma pessoa sempre tem um CPF.", "Digita ele aí pra nós.");
                }
                else if (txtCSenha.Attributes["active"].ToString() == "1")
                {
                    voltar(txtCSenha, txtSenha, "step step1 step2 step3 step4 step5", "E por fim, sua senha.", "As senhas dos melhores tem mais de 8 dígitos, com letras maiúsculas e minúsculas, números e símbolos.");
                }
            }
        }
        
        public void voltar(TextBox txtAtual, TextBox txtAnterior, string classesStep, string textH1, string textDica)
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
}
