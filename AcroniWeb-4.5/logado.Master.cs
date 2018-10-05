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
    public partial class logado : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["logado"].ToString() != "1")
                Response.Redirect("default.aspx");
            else
                lblUser.Text = Session["usuario"].ToString();
            using (SqlConnection conexao_SQL = new SqlConnection(acroni.classes.Conexao.nome_conexao))
            {
                try
                {
                    if (conexao_SQL.State != ConnectionState.Open)
                        conexao_SQL.Open();
                    String select = "SELECT imagem FROM tblCliente where usuario = '" + Session["usuario"] + "'";
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

        protected void deslogar_Click(object sender, EventArgs e)
        {
            Session["logado"] = "0";
            if (Request.Cookies["credenciais"] != null)
                Response.Cookies["credenciais"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("default.aspx");
        }
    }
}