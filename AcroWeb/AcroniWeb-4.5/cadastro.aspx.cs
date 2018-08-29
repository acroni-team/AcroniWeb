using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcroniWeb_4._5
{
    public partial class cadastro : System.Web.UI.Page
    {
        string usu, email, senha, cpf, nome;
        int aux = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void btnValida_Click(object sender, EventArgs e)
        {
            if(txtNome.Text.Length < 5)
            {
                lblErro.Text = "Você errou um nome kkk q lisho";
            }
            else
            {
                lblNome.Attributes["class"] = "identifica some";
                txtNome.Attributes["class"] = "caixa some";
                lblUsu.Attributes["class"] = "identifica aparece";
                txtUsu.Attributes["class"] = "caixa aparece";
                lblErro.Text = "";
                if (txtUsu.Text.Length < 3)
                {
                    lblErro.Text = "Você errou um nome de usuário kkk q palhactualitico";
                }
                else
                {
                    lblUsu.Attributes["class"] = "identifica some";
                    txtUsu.Attributes["class"] = "caixa some";
                    lblEmail.Attributes["class"] = "identifica aparece";
                    txtEmail.Attributes["class"] = "caixa aparece";
                    lblErro.Text = "";

                }
            }
        }
    }
}