using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using DAL;

namespace BLL
{
    public class Utilitarios
    {

        public void enviarEmailConfirmacao(string codigo, string email, string titulo, string msg, string body)
        {
            string[] divide = email.Split('@');

            string corpo = body;
            string replaceCodigo = corpo.Replace("#Codigo#", codigo);
            string replaceNome = replaceCodigo.Replace("#NomedeUsuario#", divide[0]);
            string mensagem = replaceNome.Replace("#Mensagem#", msg);
            MailMessage mail = new MailMessage("acroni.acroni7@gmail.com", email, titulo, mensagem);
            mail.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("acroni.acroni7@gmail.com", "acroni77");
            client.Send(mail);
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
    }
}
