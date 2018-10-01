﻿using System;
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
            lblErro.Text = "{{mensagem}}";
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
                        break;
                    }
                    else
                    {
                        IsValid("nome", txtNome, txtUsu, 1, nome);
                        break;
                    }
                    
                case 1:


                    if (string.IsNullOrEmpty(txtUsu.Text) || string.IsNullOrWhiteSpace(txtUsu.Text))
                    {
                        IsNotValid(txtNome, "Usuário deve ser preenchido.", 1, txtUsu);
                        break;
                    }

                    string usuario = ut.retirarEspacos(txtUsu.Text);
                    existe = ut.verificarCampoExistenteBanco("usuario", usuario);
                    
                    if (!v.validarUsu(usuario))
                    {
                        IsNotValid(txtNome, "O nome de usuário deve ter no mínimo 4 letras <br /> Caracteres especiais, exceto _ e - não são permitidos", 1, txtUsu);
                        break;
                    }
                    else if (existe)
                    {
                        IsNotValid(txtNome, "Usuário já em uso", 1, txtUsu);
                        break;
                    }
                    else if (usuario.Contains(" "))
                    {
                        IsNotValid(txtNome, "O usuário não pode conter espaços", 1, txtUsu);
                        break;
                    }
                    else
                    {
                        IsValid("usu", txtUsu, txtEmail, 2, usuario);
                        //btnValida.Attributes["class"] = "buttonv2 extended";
                        break;
                    }
                    
                case 2:
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
                        Session["email"] = email;
                        Session["codigo"] = ut.gerarStringConfirmacao();
                        ut.enviarEmailConfirmacao(Session["codigo"].ToString(), Session["email"].ToString());
                        modal.Attributes["class"] = "modal-wrap is-showing";
                        modalback.Attributes.Add("style", "pointer-events:auto");
                        break;
                    }

                case 3:
                    
                    if (!txtCodigo.Text.Equals(Session["codigo"]))
                    {
                        IsNotValid(txtEmail, "Os códigos não coincidem", 3, txtCodigo);
                        break;
                    }
                    else
                    {
                        IsValid("codigo", txtCodigo, txtCpf, 4);
                        break;
                    }

                case 4:
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
                        lblDica.Text = "Dica: use uma senha que contenha mais de 8 dígitos, letras maiúsculas e minúsculas, números e símbolos.";
                        break;
                    }

                case 5:
                    if (txtSenha.Text == "" || string.IsNullOrWhiteSpace(txtSenha.Text))
                    {
                        IsNotValid(txtEmail, "Campo de senha vazio :/", 5, txtSenha);
                        break;
                    }
                    else
                    {
                        IsValid("senha", txtSenha, txtCSenha, 6);
                        break;
                    }

                case 6:
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
        }

        public void IsNotValid (TextBox txtCampoAnterior, string erro, int aux, TextBox txtCampoErrado)
        {
            txtCampoAnterior.Attributes["class"] = "textbox textbox-type2 textbox-cad";
            txtCampoErrado.Attributes["class"] = "textbox textbox-type2 textbox-cad aparece";
            txtCampoErrado.Text = "";
            
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

        

    }
}