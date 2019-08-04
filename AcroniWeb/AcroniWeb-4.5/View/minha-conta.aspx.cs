using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcroniWeb_4._5
{
    public partial class editar_conta : System.Web.UI.Page
    {
        Utilitarios ut = new Utilitarios();
        MinhaConta m = new MinhaConta();
        Valida v = new Valida();
        SqlConnection conexao_SQL = new SqlConnection(Conexao.nome_conexao);

        protected void Page_Load(object sender, EventArgs e)
        {
            m.pageLoad(Nome, CPF, CEP, Email, Usuario, Senha, fotoPerfil);
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            m.btnSalva(Nome, CPF, CEP, Email, Usuario, Senha, FileUpload1, titleErro, msgErro, modal, modalback, overflow, lblNome, lblCPF, lblCEP, lblEmail, lblUsuario);
        }

        protected void btnValidaEmail_Click(object sender, EventArgs e)
        {
            m.btnValidaEmail(txtValidaEmail, Usuario);
        }

        //Alterar plano lol
        protected void btnAltera_Click(object sender, EventArgs e)
        {
            m.btnAlteraPlano(button, btnReload, titleErro, msgErro, modal, modalback, overflow);
        }

        protected void btnReload_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnExcluiConta_Click(object sender, EventArgs e)
        {
            m.btnExcluiConta();
        }

    }
}