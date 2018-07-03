using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcroniWeb
{
    public partial class cadastro : System.Web.UI.Page
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

        protected void btnCad_Click(object sender, EventArgs e)
        {
            bool val;
            if (v.validarEmail(txtEmail.Text) == false)
                val = false;
            else if (v.validarCPF(txtCPF.Text) == false)
                val = false;
            else if (txtCEP.Text.Replace(" ", "") == "")
                val = false;
            else if (txtUsu.Text.Replace(" ", "").Length < 3)
                val = false;
            else if (txtPass.Text.Replace(" ", "").Length < 3 || txtCPass.Text.Replace(" ", "").Length < 3)
                val = false;
            else if (txtPass.Text != txtCPass.Text)
                val = false;
            else if (verificaRegistro("usuario", txtUsu))
                val = false;
            else if (verificaRegistro("email", txtEmail))
                val = false;
            else if (verificaRegistro("cpf", txtCPF))
                val = false;
            else if (verificaRegistro("cep", txtCEP))
                val = false;
            else
                val = true;

            try
            {
                if (val == true)
                {
                    xx = new ClasseConexao();
                    ds = new DataSet();
                    xx.executa_sql("INSERT INTO tblCliente VALUES ('" + txtUsu.Text + "','" + txtPass.Text + "','" + txtEmail.Text + "','" + txtCPF.Text + "','" + txtCPF.Text + "')");
                    Response.Redirect("login.aspx");
                }
                else
                    lblErro.Text = "Campo inválido";
            }
            catch { }
        }
        
       
        
    }
}