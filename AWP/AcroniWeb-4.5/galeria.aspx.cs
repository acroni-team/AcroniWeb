using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcroniWeb_4._5
{
    public partial class galeria : System.Web.UI.Page
    {
        
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            Nome.Text = Session["usuario"].ToString(); 

            using (SqlConnection conexao_SQL = new SqlConnection(acroni.classes.Conexao.nome_conexao))
            {
                try
                {
                    if (conexao_SQL.State != ConnectionState.Open)
                        conexao_SQL.Open();
                    String select = "SELECT imagem_colecao FROM tblColecao AS colec INNER JOIN tblCliente AS cli ON cli.id_cliente = colec.id_cliente AND usuario ='" + Session["usuario"] + "'";

                    using (SqlCommand comando_SQL = new SqlCommand(select, conexao_SQL))
                    {
                        using (SqlDataReader tabela = comando_SQL.ExecuteReader())
                        {
                            tabela.Read();
                            if (tabela.HasRows)
                            {
                                byte[] imgBytes = (byte[])tabela[0];
                                string imgString = Convert.ToBase64String(imgBytes);
                                imgColecao.ImageUrl = "data:image/jpg;base64," + imgString;
                                imgStatus.Attributes.Add("style", "display:none");
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