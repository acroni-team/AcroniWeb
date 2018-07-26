using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Vamo ver se a disgraca do ammend vai funfar

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

        public bool verificaRegistro(String campo, TextBox txtBox)
        {
            bool val = false;
            xx = new ClasseConexao();
            ds = new DataSet();
            ds = xx.executa_sql("SELECT " + campo + " FROM tblCliente WHERE " + campo + " = '" + txtBox.Text + "'");
            if (ds.Tables[0].Rows.Count > 0)
                val = true;

            return val;
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
            else if (txtEndereco.Text.Replace(" ", "").Length < 3)
                val = false;
            else if (txtCidade.Text.Replace(" ", "").Length < 3)
                val = false;
            else if (txtCEP.Text.Replace(" ", "") == "")
                val = false;
            else if (txtUF.Text.Replace(" ", "").Length < 1)
                val = false;
            else if (txtTelefone.Text.Replace(" ", "").Length < 8)
                val = false;
            else if (txtUsu.Text.Replace(" ", "").Length < 3)
                val = false;
            else if (txtPass.Text.Replace(" ", "").Length < 3 || txtPass2.Text.Replace(" ", "").Length < 3)
                val = false;
            else if (txtPass.Text != txtPass2.Text)
                val = false;
            else if (verificaRegistro("usuario", txtUsu))
                val = false;
            else if (verificaRegistro("email", txtEmail))
                val = false;
            else if (verificaRegistro("cpf", txtCPF))
                val = false;
            else if (verificaRegistro("rg", txtRG))
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

        protected void txtCEP_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var ws = new WSCorreios.AtendeClienteClient();
                var resposta = ws.consultaCEP(txtCEP.Text);
                txtEndereco.Text = resposta.end;
                txtCidade.Text = resposta.cidade;
                txtUF.Text = resposta.uf;
            }
            catch { }
        }
    }
}