using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace AcroniWeb.img
{
    public partial class construct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {


            String titulo = "Oi, eu sou um Assunto :D";
            String mensagem = "Oi, eu sou um Corpo :D ";

            MailMessage mail = new MailMessage("acroni.acroni7@gmail.com", txtEmail.Text, titulo, mensagem);
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("acroni.acroni7@gmail.com", "acroni77");
            client.Send(mail);


        }
    }

}