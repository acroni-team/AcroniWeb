using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcroniWeb_4._5
{
    public partial class GetImageTeclado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection conexao_SQL = new SqlConnection(Conexao.nome_conexao))
            {
                try
                {
                    if (conexao_SQL.State != ConnectionState.Open)
                        conexao_SQL.Open();
                    string id = Request.QueryString["id"];
                    String select = "EXEC usp_GetImageTeclado '"+Session["usuario"].ToString()+"',"+id;

                    using (SqlCommand comando_SQL = new SqlCommand(select, conexao_SQL))
                    {
                        comando_SQL.Parameters.Add("@id_teclado_customizado", SqlDbType.Int).Value = Int32.Parse(id);
                        using (SqlDataReader tabela = comando_SQL.ExecuteReader())
                        {
                            tabela.Read();
                            if (tabela.HasRows)
                            {
                                byte[] imgData = (byte[])tabela["imagem_teclado"];
                                Response.BinaryWrite(imgData);
                                
                            }

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