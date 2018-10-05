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
    public partial class loja : System.Web.UI.Page
    {
        SqlConnection conexao_SQL = new SqlConnection(acroni.classes.Conexao.nome_conexao);
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection conexao_SQL = new SqlConnection(acroni.classes.Conexao.nome_conexao))
            {
                try
                {
                    if (conexao_SQL.State != ConnectionState.Open)
                        conexao_SQL.Open();

                    String select = "SELECT * FROM tblProdutosDaLoja";
                    using (SqlCommand comando_SQL = new SqlCommand(select, conexao_SQL))
                    {
                        using (SqlDataReader resposta = comando_SQL.ExecuteReader())
                        {
                            DataList1.DataSource = resposta[0];
                            DataList1.DataBind();
                            conexao_SQL.Close();
                        }

                    }    
                }
                catch (Exception ex)
                {
                    conexao_SQL.Close();
                }
            }
        }
    }  
}