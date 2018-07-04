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
            
            bool[] verify = new bool[9];

            if (v.validarEmail(txtEmail.Text) == false)
            {
                verify[0] = false;
                txtEmail.Attributes.Add("style", "border-color: red");
            }
            else if (verificaRegistro("email", txtEmail))
            {
                verify[7] = false;
                txtEmail.Attributes.Add("style", "border-color: red");
                Response.Write("<script>alert('E-mail em uso');</script>");
            }
            else
            {
                verify[0] = true;
                verify[7] = true;
                txtEmail.Attributes.Add("style", "border-color: #fff");
            }

            if (v.validarCPF(txtCPF.Text) == false)
            {
                verify[1] = false;
                txtCPF.Attributes.Add("style", "border-color: red");
            }
            else if (verificaRegistro("cpf", txtCPF))
            {
                verify[8] = false;
                txtCPF.Attributes.Add("style", "border-color: red");
                Response.Write("<script>alert('CPF em uso');</script>");
            }
            else
            {
                verify[1] = true;
                verify[8] = true;
                txtCPF.Attributes.Add("style", "border-color: #fff");
            }

            if (txtCEP.Text.Replace(" ", "").Length < 3)
            {
                verify[2] = false;
                txtCEP.Attributes.Add("style", "border-color: red");
            }
            else
            {
                verify[2] = true;
                txtCEP.Attributes.Add("style", "border-color: #fff");
            }

            if (txtUsu.Text.Replace(" ", "").Length < 3)
            {
                verify[3] = false;
                txtUsu.Attributes.Add("style", "border-color: red");
            }
            else if (verificaRegistro("usuario", txtUsu))
            {
                verify[6] = false;
                txtUsu.Attributes.Add("style", "border-color: red");
                Response.Write("<script>alert('Usuário em uso');</script>");
            }
            else
            {
                verify[3] = true;
                verify[6] = true;
                txtUsu.Attributes.Add("style", "border-color: #fff");
            }

            if (txtPass.Text.Replace(" ", "").Length < 3)
            {
                verify[4] = false;
                txtPass.Attributes.Add("style", "border-color: red");
            }
            else
            {
                verify[4] = true;
                txtPass.Attributes.Add("style", "border-color: #fff");
            }

            if (txtPass.Text != txtCPass.Text)
            {
                verify[5] = false;
                Response.Write("<script>alert('As senhas não coincidem');</script>");
                txtCPass.Attributes.Add("style", "border-color: red");
            }
            else
            {
                verify[5] = true;
                txtCPass.Attributes.Add("style", "border-color: #fff");
            }

            try
            {
                if (Array.IndexOf(verify, false) == -1)
                {
                    xx = new ClasseConexao();
                    ds = new DataSet();
                    xx.executa_sql("INSERT INTO tblCliente (usuario,senha,email,cpf,cep) VALUES ('" + txtUsu.Text + "','" + txtPass.Text + "','" + txtEmail.Text + "','" + txtCPF.Text + "','" + txtCEP.Text + "')");
                    Response.Redirect("login.aspx");
                }
                else
                    lblErro.Text = "Campo inválido";
            }
            catch { }
        }
        
       
        
    }
}