using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;


public class Utilitarios
{
    SqlConnection conexao_SQL = new SqlConnection(acroni.classes.Conexao.nome_conexao);
    SqlCommand comando_SQL;
    SqlDataReader resposta;
    string select = "";
    public bool verificarCampoExistenteBanco(string atributo, string campo)
    {
        bool retorno = false;
        if (conexao_SQL.State == ConnectionState.Closed)
            conexao_SQL.Open();

        if (atributo.Equals("usuario"))
            select = "SELECT * FROM tblCliente WHERE usuario = '" + campo + "'";
        else if (atributo.Equals("email"))
            select = "SELECT * FROM tblCliente WHERE email = '" + campo + "'";
        else if (atributo.Equals("cpf"))
            select = "SELECT * FROM tblCliente WHERE cpf = '" + campo + "'";

        comando_SQL = new SqlCommand(select, conexao_SQL);
        resposta = comando_SQL.ExecuteReader();
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

    public void enviarEmailConfirmacao(string codigo, string email)
    {
        string titulo = "Alterar senha";
        string mensagem = "Oi, eu sou o código " + codigo + " :D ";
        MailMessage mail = new MailMessage("acroni.acroni7@gmail.com", email, titulo, mensagem);
        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
        client.EnableSsl = true;
        client.Credentials = new System.Net.NetworkCredential("acroni.acroni7@gmail.com", "acroni77");
        client.Send(mail);
    }

}
