using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class Utilitarios
{
    SqlCommand comando_SQL;
    string select = "";
    public bool verificarCampoExistenteBanco(string atributo, string campo)
    {
        using (SqlConnection conexao_SQL = new SqlConnection(acroni.classes.Conexao.nome_conexao))
        {
            bool retorno = false;
            try
            {
                if (conexao_SQL.State == ConnectionState.Closed)
                    conexao_SQL.Open();

                if (atributo.Equals("usuario"))
                    select = "SELECT * FROM tblCliente WHERE usuario = '" + campo + "'";
                else if (atributo.Equals("email"))
                    select = "SELECT * FROM tblCliente WHERE email = '" + campo + "'";
                else if (atributo.Equals("cpf"))
                    select = "SELECT * FROM tblCliente WHERE cpf = '" + campo + "'";

                using (SqlCommand comando_SQL = new SqlCommand(select, conexao_SQL))
                {
                    using (SqlDataReader resposta = comando_SQL.ExecuteReader())
                    {
                        resposta.Read();
                        if (resposta.HasRows)
                        {
                            resposta.Close();
                            conexao_SQL.Close();
                            return retorno = true;
                        }
                        else
                        {
                            resposta.Close();
                            conexao_SQL.Close();
                            return retorno = false;
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                conexao_SQL.Close();

            }
            return retorno;
        }
    }


    public string retirarEspacos(string campo)
    {
        if (!string.IsNullOrEmpty(campo) || !string.IsNullOrWhiteSpace(campo))
        {
            while (campo[0].Equals(' '))
                campo = campo.Remove(0, 1);

            while (campo[campo.Length - 1].Equals(' '))
                campo = campo.Remove(campo.Length - 1, 1);
        }
        return campo;
    }

    public string gerarStringConfirmacao()
    {
        string stringConfirmacao = "";
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

        return stringConfirmacao;
    }

    public void enviarEmailConfirmacao(string codigo, string email, string titulo, string msg)
    {
        string[] divide = email.Split('@');

        string corpo = File.ReadAllText(HttpContext.Current.Server.MapPath("email.html"));
        string replaceCodigo = corpo.Replace("#Codigo#", codigo);
        string replaceNome = replaceCodigo.Replace("#NomedeUsuario#", divide[0]);
        string mensagem = replaceNome.Replace("#Mensagem#", msg);

        //string mensagem = "<div> Oi, "+divide[0]+"! </br>, eu sou o código " + codigo + " :D ";
        MailMessage mail = new MailMessage("acroni.acroni7@gmail.com", email, titulo, mensagem);
        mail.IsBodyHtml = true;
        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
        client.EnableSsl = true;
        client.Credentials = new System.Net.NetworkCredential("acroni.acroni7@gmail.com", "acroni77");
        client.Send(mail);
    }

    public void inserirUsuario(string nome, string usu, string email, string cpf, string senha)
    {
        using (SqlConnection conexao_SQL = new SqlConnection(acroni.classes.Conexao.nome_conexao))
        {
            try
            {
                if (conexao_SQL.State == ConnectionState.Closed)
                    conexao_SQL.Open();

                string insert = $"INSERT INTO tblCliente (nome, usuario, senha, email, cpf) VALUES ('{nome}', '{usu}', '{senha}', '{email}', '{cpf}')";
                using (comando_SQL = new SqlCommand(insert, conexao_SQL))
                {
                    comando_SQL.ExecuteNonQuery();
                    conexao_SQL.Close();
                }
            }
            catch
            {
                conexao_SQL.Close();
            }
        }
    }

    public byte[] ConvertImageToByteArray(System.Drawing.Image imageToConvert, System.Drawing.Imaging.ImageFormat formatOfImage)
    {
        byte[] Ret;
        try
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageToConvert.Save(ms, formatOfImage);
                Ret = ms.ToArray();
            }
        }
        catch (Exception) { throw; }
        return Ret;
    }
    
    // Mensagens de erro

    public void showErrorMessage(string title, string msg, Label titleErro, Label msgErro,  HtmlGenericControl modal, HtmlGenericControl modalback, HtmlGenericControl overflow)
    {
        titleErro.Text = title;
        msgErro.Text = msg;
        modal.Attributes["class"] = "modal-wrap minha-conta is-showing";
        modalback.Attributes.Add("style", "pointer-events:auto");
        overflow.Attributes["class"] = "modal-overflow modal-overflow-alt";
    }

    public void showErrorMessageByLbl(string msg, TextBox txtCampoErrado, Label lblCampoErrado)
    {

        txtCampoErrado.BorderColor = System.Drawing.Color.Red;
        txtCampoErrado.Text = "";
        lblCampoErrado.Text = msg;
        lblCampoErrado.ForeColor = System.Drawing.Color.Red;

    }

}
