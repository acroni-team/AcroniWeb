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
        Valida v = new Valida();
        Utilitarios ut = new Utilitarios();
        Cadastro c = new Cadastro();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Se a página estiver loadando pela primeira vez, inicializar as 'variáveis' e o AUX
            c.pageLoad(IsPostBack, lblErro);
        }
               
        protected void btnValida_Click(object sender, EventArgs e)
        {
            c.btnValida(txtNome,border, txtUsu, step, lblH1Dica, lblDica, txtEmail, txtCodigo, ReenviarEmail, txtCpf, txtSenha, txtCSenha, lblErro);
        }
        protected void ReenviarEmail_Click(object sender, EventArgs e)
        {
            c.ReenviarEmail(lblH1Dica, lblDica);
        }

        protected void ReenviaImai_Click(object sender, EventArgs e)
        {
            c.ReenviarImai();
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            c.btnVoltar(txtNome, txtUsu, txtEmail, txtCpf, txtCodigo, txtSenha, txtCSenha, step, lblH1Dica, lblDica);
        }
        
        


    }
}
