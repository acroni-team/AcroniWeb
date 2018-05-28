using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrjASPX_v2._0
{
    

    public partial class Login : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        static String usu ;
        static String pass ;
        String cpass;


        protected void btnCad_Click(object sender, EventArgs e)
        {
            if (txtCpass.Text == txtPass.Text)
            {
                lblMsg.Text = "Cadastrado com sucesso! Agora efetue o login";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                usu = txtUsu.Text + "";
                pass = txtPass.Text + "";
                cpass = txtCpass.Text + "";
            }
            else
            {

                lblMsg.Text = "Senhas não batem";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }


        protected void btnEntra_Click(object sender, EventArgs e)
        {
            if (txtUsu.Text == "1" && txtPass.Text == "1")
            {
                Session["logado"] = "1";
                Response.Redirect("AreaRestrita.aspx");
            }
            else
            {
                Session["logado"] = "0";
                lblMsg.Text = "Email ou senha incorretos";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        
    }
}