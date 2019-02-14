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
    public partial class layout : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (Session["usuarioNovo"] != null)
                Session["usuario"] = Session["usuarioNovo"];
            if (Session["logado"].ToString() == "1")
            {
                lblUser.Text = Session["usuario"].ToString();
                user.Attributes.Add("style", "display:block");
                
            }
            using (SqlConnection conexao_SQL = new SqlConnection(acroni.classes.Conexao.nome_conexao))
            {
                try
                {
                    if (conexao_SQL.State != ConnectionState.Open)
                        conexao_SQL.Open();
                    String select = "SELECT imagem_cliente FROM tblCliente where usuario = '" + Session["usuario"] + "'";
                    using (SqlCommand comando_sql = new SqlCommand(select, conexao_SQL))
                    {
                        using (SqlDataReader tabela = comando_sql.ExecuteReader())
                        {
                            tabela.Read();
                            byte[] imgBytes = (byte[])tabela[0];

                            string imgString = Convert.ToBase64String(imgBytes);
                            profilePicture.ImageUrl = "data:image/png;base64," + imgString;
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