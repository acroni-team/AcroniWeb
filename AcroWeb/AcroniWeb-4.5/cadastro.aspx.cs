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
        
        Regex validacao_email = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Valida v = new Valida();
        SqlConnection conexao_SQL = new SqlConnection(acroni.classes.Conexao.nome_conexao);
        SqlCommand comando_SQL;
        SqlDataReader resposta;
        String select;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Se a página estiver loadando pela primeira vez, inicializar as 'variáveis' e o AUX
            if (!IsPostBack)
            {
                ViewState["usu"] = "";
                ViewState["email"] = "";
                ViewState["nome"] = "";
                ViewState["cpf"] = "";
                ViewState["senha"] = "";
                ViewState["csenha"] = "";
                ViewState["aux"] = 0;
            }
            lblErro.Text = "{{mensagem}}";
        }
               
        protected void btnValida_Click(object sender, EventArgs e)
        {
            //Switch case para cada caso do AUX
            //Se a validacão der erro, o AUX será o mesmo e assim caindo no mesmo caso até o usuário acertar
            switch (ViewState["aux"])
            {
                case 0:
                    if (string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrWhiteSpace(txtNome.Text))
                    {
                        IsNotValid(txtNome, "Nome completo inválido", 0, txtNome);
                        break;
                    }

                    string nome = retirarEspacos(txtNome.Text);

                    if (!v.ValidaNome(nome) || !nome.Contains(" "))
                    {
                        IsNotValid(txtNome, "Nome completo inválido", 0, txtNome);
                        break;
                    }
                    else
                    {
                        IsValid("nome", txtNome, lblNome, txtUsu, lblUsu, 1, nome);
                        break;
                    }
                    
                case 1:
                    string usuario = retirarEspacos(txtUsu.Text);

                    if (conexao_SQL.State == ConnectionState.Closed)
                        conexao_SQL.Open();

                    select = "SELECT * FROM tblCliente WHERE usuario = '" + usuario + "'";
                    comando_SQL = new SqlCommand(select, conexao_SQL);
                    resposta = comando_SQL.ExecuteReader();
                    resposta.Read();
                    if (!v.ValidaUsu(usuario))
                    {
                        IsNotValid(txtNome, "O nome de usuário deve ter no mínimo 4 letras <br /> Caracteres especiais, exceto _ e - não são permitidos", 1, txtUsu);
                        break;
                    }
                    else if (resposta.HasRows)
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
                        IsValid("usu", txtUsu, lblUsu, txtEmail, lblEmail, 2, usuario);
                        break;
                    }
                    
                case 2:
                    if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
                    {
                        IsNotValid(txtUsu, "Email inválido.", 2, txtEmail);
                        break;
                    }

                    string email = retirarEspacos(txtEmail.Text);
                    if (conexao_SQL.State == ConnectionState.Closed)
                        conexao_SQL.Open();

                    select = "SELECT * FROM tblCliente WHERE email = '" + email + "'";
                    comando_SQL = new SqlCommand(select, conexao_SQL);
                    resposta = comando_SQL.ExecuteReader();
                    resposta.Read();

                    if (!validacao_email.IsMatch(email))
                    {
                        IsNotValid(txtUsu, "Email inválido.", 2, txtEmail);
                        select = "";
                        conexao_SQL.Close();
                        break;
                    }
                    else if (resposta.HasRows)
                    {
                        IsNotValid(txtUsu, "Email já em uso.", 2, txtEmail);
                        select = "";
                        conexao_SQL.Close();
                        break;
                    }
                    else
                    {
                        IsValid("email", txtEmail, lblEmail, txtCpf, lblCpf, 3, email);
                        select = "";
                        conexao_SQL.Close();
                        ViewState["email"] = email;
                        break;
                    }

                case 3:
                    if (!v.validarCPF(txtCpf.Text))
                    {
                        IsNotValid(txtEmail, "CPF inválido", 3, txtCpf);
                        break;
                    }
                    else
                    {
                        IsValid("cpf", txtCpf, lblCpf, txtSenha, lblSenha, 4);
                        lblDica.Text = "Dica: use uma senha que contenha mais de 8 dígitos, letras maiúsculas e minúsculas, números e símbolos.";
                        break;
                    }

                case 4:
                    if (txtSenha.Text == "" || string.IsNullOrWhiteSpace(txtSenha.Text))
                    {
                        IsNotValid(txtEmail, "Campo de senha vazio :/", 4, txtSenha);
                        break;
                    }
                    else
                    {
                        IsValid("senha", txtSenha, lblSenha, txtCSenha, lblCSenha, 5);
                        break;
                    }

                case 5:
                    if (txtCSenha.Text != ViewState["csenha"].ToString())
                    {
                        IsNotValid(txtCSenha, "As senhas não coincidem", 5, txtCSenha);
                        break;
                    }
                    else
                    {
                        //Exibir a revisão dos dados para finalizar o cadastro
                        break;
                    }



            }
        }
        
        //Métodos para evitar a repeticão e enxutar o côdigo
        public void IsValid (string campoCadastrado, TextBox txtCampoCadastrado, Label lblCampoCadastrado, TextBox txtProxCampo, Label lblProxCampo, int aux)
        {
            ViewState[campoCadastrado] = txtCampoCadastrado.Text;
            txtCampoCadastrado.Text = "";
            lblErro.Text = "";
            lblCampoCadastrado.Attributes["class"] = "identifica some";
            txtCampoCadastrado.Attributes["class"] = "caixa some";
            lblProxCampo.Attributes["class"] = "identifica aparece";
            txtProxCampo.Attributes["class"] = "caixa aparece";
            ViewState["aux"] = aux;
        }

        //Overload para os campos que tem os espacos retirados
        public void IsValid(string campoCadastrado, TextBox txtCampoCadastrado, Label lblCampoCadastrado, TextBox txtProxCampo, Label lblProxCampo, int aux, string valCampoCadastrado)
        {
            ViewState[campoCadastrado] = valCampoCadastrado;
            txtCampoCadastrado.Text = "";
            lblErro.Text = "";
            lblCampoCadastrado.Attributes["class"] = "identifica some";
            txtCampoCadastrado.Attributes["class"] = "caixa some";
            lblProxCampo.Attributes["class"] = "identifica aparece";
            txtProxCampo.Attributes["class"] = "caixa aparece";
            ViewState["aux"] = aux;
        }

        public void IsNotValid (TextBox txtCampoAnterior, string erro, int aux, TextBox txtCampoErrado)
        {
            txtCampoErrado.Text = "";
            if (aux == 0)
            {
                lblErro.Text = erro;
                ViewState["aux"] = aux;
            }
            else
            {
                txtCampoAnterior.Text = "";
                lblErro.Text = erro;
                ViewState["aux"] = aux;
            }
        }

        public string retirarEspacos (string campo)
        {
            while(campo[0].Equals(' '))
                campo = campo.Remove(0, 1);
            
            while(campo[campo.Length - 1].Equals(' '))
                campo = campo.Remove(campo.Length - 1, 1);
           
            return campo;
        }

    }
}