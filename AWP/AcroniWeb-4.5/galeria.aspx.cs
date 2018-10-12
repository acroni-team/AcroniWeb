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

        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection conexao_SQL = new SqlConnection(acroni.classes.Conexao.nome_conexao))
            {
                try
                {
                    if (conexao_SQL.State != ConnectionState.Open)
                        conexao_SQL.Open();
                    String select = "SELECT imagem_coleção FROM tblColecao WHERE usuario ='" + Session["usuario"] + "'";

                    using (SqlCommand comando_SQL = new SqlCommand(select, conexao_SQL))
                    {
                        using (SqlDataReader tabela = comando_SQL.ExecuteReader())
                        {
                            tabela.Read();
                            byte[] imgBytes = (byte[])tabela[0];
                            string imgString = Convert.ToBase64String(imgBytes);
                            imgColecao.ImageUrl = "data:image/jpg;base64," + imgString;
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