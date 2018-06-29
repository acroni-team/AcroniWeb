using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CadastroLogin
{
    public partial class Cadastro : System.Web.UI.Page
    {
        Valida v = new Valida();
        ClasseConexao xx = new ClasseConexao();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            bool val;
            if (txtNome.Text == "")
                val = false;
            else if (v.validarEmail(txtEmail.Text) == false)
                val = false;
            else if (v.validarCPF(txtCPF.Text) == false)
                val = false;
            else if (v.validarData(txtData.Text) == false)
                val = false;
            else if (txtRG.Text.Replace(" ", "") == "")
                val = false;
            else if (txtEndereco.Text.Replace(" ", "") == "")
                val = false;
            else if (txtCidade.Text.Replace(" ", "") == "")
                val = false;
            else if (txtCEP.Text.Replace(" ", "") == "")
                val = false;
            else if (txtUF.Text.Replace(" ", "") == "")
                val = false;
            else if (txtTelefone.Text.Replace(" ", "") == "")
                val = false;
            else if (txtUsu.Text.Replace(" ", "") == "")
                val = false;
            else if (txtPass.Text.Replace(" ", "") == "" || txtPass2.Text.Replace(" ", "") == "")
                val = false;
            else if (txtPass.Text != txtPass2.Text)
                val = false;
            else
                val = true;

            try
            {
                if (val)
                {
                    xx = new ClasseConexao();
                    ds = new DataSet();
                    xx.executa_sql("INSERT INTO tblCliente VALUES ('" + txtUsu.Text + "','" + txtPass.Text + "','" + txtNome.Text + "','" + txtEmail.Text + "','" + txtCPF.Text + "','" + txtData.Text + "','" + txtRG.Text + "','" + txtEndereco.Text + "','" + txtCidade.Text + "','" + txtCEP.Text + "','" + txtUF.Text + "','" + txtTelefone.Text + "')");
                    Response.Redirect("Login.aspx");
                }
                else
                    lblErro.Text = "Campo inválido";
            }
            catch { }
        }

        
    }
}