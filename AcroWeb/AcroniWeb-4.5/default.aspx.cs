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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        SqlConnection conexao_SQL = new SqlConnection(acroni.classes.Conexao.nome_conexao);
        SqlCommand comando_SQL;
        SqlDataReader tabela;
        String select;
        public string stringConfirmacao;
        string email = "";

        public string Email {get; set;}

        protected void btnIrCad_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadastro.aspx");
        }


        protected void btnEntra_Click(object sender, EventArgs e)
        {
            try
            {
                if (conexao_SQL.State == ConnectionState.Closed)
                    conexao_SQL.Open();

                select = "SELECT * FROM tblCliente WHERE usuario='" + txtUsu.Text + "'";
                comando_SQL = new SqlCommand(select, conexao_SQL);
                tabela = comando_SQL.ExecuteReader();
                tabela.Read();
                if (tabela.HasRows)
                {
                    txtUsu.Attributes.Add("style", "border-color:#0093ff");
                    tabela.Close();
                    select = "";
                    select = "SELECT usuario FROM tblCliente WHERE senha='" + txtPass.Text + "' and usuario='" + txtUsu.Text + "'";
                    comando_SQL = new SqlCommand(select, conexao_SQL);
                    tabela = comando_SQL.ExecuteReader();
                    tabela.Read();
                    if (tabela.HasRows)
                    {
                        Session["logado"] = "1";
                        Response.Redirect("construct.aspx");
                        txtPass.Attributes.Add("style", "border-color:#0093ff");
                    }
                    else
                    {
                        lblMsg.Text = "Senha incorreta";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        txtPass.Attributes.Add("style", "border-color:red");
                    }

                }
                else
                {
                    lblMsg.Text = "Usuário e senha incorretos";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    txtUsu.Attributes.Add("style", "border-color:red");
                    txtPass.Attributes.Add("style", "border-color:red");
                }

                tabela.Close();
                select = "";
                conexao_SQL.Close();
            }
            catch
            {
                tabela.Close();
                conexao_SQL.Close();
            }
            SCPanel.Update();
        }


        Regex validacao_email = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            bool existe = true;

            if (conexao_SQL.State == ConnectionState.Closed)
                conexao_SQL.Open();

            select = "SELECT usuario FROM tblCliente WHERE email = '" + txtEmail.Text + "'";
            comando_SQL = new SqlCommand(select, conexao_SQL);
            SqlDataReader resposta = comando_SQL.ExecuteReader();
            resposta.Read();

            if (resposta.HasRows)
                existe = true;
            else
                existe = false;

            resposta.Close();
            conexao_SQL.Close();
            if (validacao_email.IsMatch(txtEmail.Text) && existe)
            {
                //ISSO AQUI É SE TIVER CERTO
                txtEmail.Attributes.Add("style", "border-color:#0093ff");
                lblErro1.Text = "Boa! Agora da uma checadinha no seu email que enviamos um código";
                lblErro1.ForeColor = System.Drawing.Color.Green;

                modal.Attributes["class"] = "modal-wrap  is-showing";
                step1.Attributes["class"] = "modal-body modal-body-step1 animate-out";
                step2.Attributes["class"] = "modal-body modal-body-step2 is-showing animate-in";

                envia_email();

                //ATÉ AQUI
            }

            else
            {
                modal.Attributes["class"] = "modal-wrap  is-showing";
                lblErro1.Text = "Acho que você tem que colocar o e-mail que registrou antes";
                lblErro1.ForeColor = System.Drawing.Color.Red;
                txtEmail.Attributes.Add("style", "border-color:red");
                //KK ESSA MERDA ATUALIZA A PAGINA
            }
            conexao_SQL.Close();
            SCPanel2.Update();
           
        }

        protected void btnSendCode_Click(object sender, EventArgs e) {
            if (txtCodigo.Text.Equals(Session["codigo"]))
            {
                //ELE VAI MANDAR PRA OUTRA PAGE SE O CODIGO CORRESPONDER COM O MANDADO NO IMAI PADRAO
                modal.Attributes["class"] = "modal-wrap  is-showing";
                step2.Attributes["class"] = "modal-body modal-body-step2 animate-out";
                step3.Attributes["class"] = "modal-body modal-body-step3 is-showing animate-in";
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
            //AQUI É A MERDA, VAI TER QUE DAR UNS UPDATE* :D boa 06
            //ai é gg, fax
            if (txtSenha.Text.Equals(txtCSenha.Text))
            {
                updateSenha();
                Response.Redirect("default.aspx");
            }
            else
            {
                lblErro3.Text = "As senhas não estão iguais.";
                lblErro3.ForeColor = System.Drawing.Color.Red;
                txtSenha.Attributes.Add("style", "border-color:red");
                txtCSenha.Attributes.Add("style", "border-color:red");
                //MSG DE ERRO
            }
            SCPanel2.Update();
        }


            public void gerar_string_confirmacao()
        {
            stringConfirmacao = "";
            char[] alfabeto = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            Random r = new Random();
            for (int i = 0; i < 7; i++)
            {
                if (r.Next(2) == 0)
                {
                    //alfabeto
                    stringConfirmacao += alfabeto[r.Next(26)];
                }
                else
                {
                    //numero
                    stringConfirmacao += r.Next(10);
                }
            }
        }

        public  void envia_email()
        {
            email = txtEmail.Text;
            gerar_string_confirmacao();
            String titulo = "Alterar senha";
            String mensagem = "Oi, eu sou o código " + stringConfirmacao + " :D ";
            MailMessage mail = new MailMessage("acroni.acroni7@gmail.com", txtEmail.Text, titulo, mensagem);
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("acroni.acroni7@gmail.com", "acroni77");
            client.Send(mail);
            Session["codigo"] = stringConfirmacao;
            Session["email"] = txtEmail.Text;
            txtEmail.Text = "";

        }

        private void updateSenha()
        {
            try
            {
                //--Abrindo a conexão
                if (conexao_SQL.State != ConnectionState.Open)
                    conexao_SQL.Open();

                //--Inicializando um comando UPDATE e execuntando
                String update = "UPDATE tblCliente SET senha = '" + txtSenha.Text + "' WHERE email = '" + Session["email"] + "'";
                comando_SQL = new SqlCommand(update, conexao_SQL);
                //--Para executar, utilizo ExecuteNonQuery(), pois ele retorna apenas o numero de linhas afetadas
                int n_linhas_afetadas = comando_SQL.ExecuteNonQuery();

                //--Fechando a conexão (NÃO ESQUECER!)
                conexao_SQL.Close();
            }
            catch (Exception ex)
            {
                conexao_SQL.Close();
            }

        }
    }
}
     