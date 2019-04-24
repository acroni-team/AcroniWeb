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
                    String select = "SELECT imagem_teclado FROM tblTecladoCustomizado AS tec INNER JOIN tblCliente AS cli ON cli.id_cliente = tec.id_cliente AND usuario ='" + Session["usuario"] + "' AND id_teclado_customizado = @id_teclado_customizado";

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
                                //byte[] imgBytes = (byte[])tabela[0];
                                //string imgString = Convert.ToBase64String(imgBytes);
                                //imgStatus.Attributes.Add("style", "display:none");
                                //header.Attributes["class"] = "galeria-header is-showing";
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