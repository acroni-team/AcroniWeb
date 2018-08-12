using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        SqlConnection conexao_SQL = new SqlConnection(acroni.classes.Conexao.nome_conexao);
        SqlCommand comando_SQL;
        SqlDataReader tabela;
        

        protected void btnIrCad_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadastro.aspx");
        }


        protected void btnEntra_Click(object sender, EventArgs e)
        {
                //if (conexao_SQL.State == ConnectionState.Closed)
                //    conexao_SQL.Open();
                
                //String select = "SELECT * FROM tblCliente WHERE usuario='" + txtUsu.Text + "'";
                //comando_SQL = new SqlCommand(select, conexao_SQL);
                //tabela = comando_SQL.ExecuteReader();
                //tabela.Read();
                //if (tabela.HasRows)
                //{
                //    tabela.Close();
                //    String select2 = "SELECT * FROM tblCliente WHERE senha='" + txtPass.Text + "'";
                //    comando_SQL = new SqlCommand(select2, conexao_SQL);
                //    SqlDataReader tabela2 = comando_SQL.ExecuteReader();
                //    tabela2.Read();
                //    if (tabela2.HasRows)
                //    { 
                //        Session["logado"] = "1";
                //        Response.Redirect("area-restrita.aspx");
                //    }
                //    else
                //    {
                //        lblMsg.Text = "Senha incorreta";
                //        lblMsg.ForeColor = System.Drawing.Color.Red;
                //        txtPass.Attributes.Add("style", "border-color:red");
                //    }
                //    tabela2.Close();
                //    conexao_SQL.Close();
                    
                //}                 
                //else
                //{
                //    lblMsg.Text = "Usuário incorreto";
                //    lblMsg.ForeColor = System.Drawing.Color.Red;
                //    txtUsu.Attributes.Add("style", "border-color:red");
                //}

                //tabela.Close();
                //conexao_SQL.Close();
        }
    }
}