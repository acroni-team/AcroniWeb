using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcroniWeb
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //static String usu;
        //static String pass;
        //String cpass;


        protected void btnCad_Click(object sender, EventArgs e)
        {
            //if (txtCpass.Text == txtPass.Text)
            //{
            //    lblMsg.Text = "Cadastrado com sucesso! Agora efetue o login";
            //    lblMsg.ForeColor = System.Drawing.Color.Green;
            //    usu = txtUsu.Text + "";
            //    pass = txtPass.Text + "";
            //}
            //else
            //{

            //    lblMsg.Text = "Senhas não batem";
            //    lblMsg.ForeColor = System.Drawing.Color.Red;
            //}

            Response.Redirect("cadastro.aspx");
        }



        protected void btnEntra_Click(object sender, EventArgs e)
        {
            //if (txtUsu.Text == usu && txtPass.Text == pass)
            //{
            //    Session["logado"] = "1";
            //    Response.Redirect("area-restrita.aspx");
            //}
            //else
            //{
            //    Session["logado"] = "0";
            //    lblMsg.Text = "Email ou senha incorretos";
            //    lblMsg.ForeColor = System.Drawing.Color.Red;
            //}
        }
    }
}