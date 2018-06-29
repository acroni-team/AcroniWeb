using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CadastroLogin
{
    public partial class Login : System.Web.UI.Page
    {
        ClasseConexao xx = new ClasseConexao();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                xx = new ClasseConexao();
                ds = new DataSet();
                ds = xx.executa_sql("SELECT * FROM tblCliente WHERE usuario='" + txtUser.Text + "' AND senha='" + txtPass.Text + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Response.Redirect("Restrito.aspx");
                }
                else
                {
                    lblErro.Text = "Credenciais incorretas";
                }
            }
            catch { }
        }

        protected void btnRedirect_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cadastro.aspx");
        }
    }
}