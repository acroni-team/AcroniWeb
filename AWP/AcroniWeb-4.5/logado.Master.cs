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
            if (Session["usuarioNovo"] != null)
                Session["usuario"] = Session["usuarioNovo"];
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

                try
                {
                    if (conexao_SQL.State != ConnectionState.Open)
                        conexao_SQL.Open();
                    String select = "SELECT quantidade_teclados FROM tblCliente where usuario = '" + Session["usuario"] + "'";
                    using (SqlCommand comando_sql = new SqlCommand(select, conexao_SQL))
                    {
                        using (SqlDataReader tabela = comando_sql.ExecuteReader())
                        {
                            String qtde;
                            tabela.Read();
                            if (tabela.HasRows)
                            {
                                qtde = tabela[0].ToString();
                                if (qtde == "1")
                                {
                                    blueLine.Attributes.Add("style", "transform:translateX(-240px)");
                                }
                                else if (qtde == "2")
                                {
                                    blueLine.Attributes.Add("style", "transform:translateX(-180px)");
                                }
                                else if (qtde == "3")
                                {
                                    blueLine.Attributes.Add("style", "transform:translateX(-120px)");
                                }
                                else if (qtde == "4")
                                {
                                    blueLine.Attributes.Add("style", "transform:translateX(-60px)");
                                }
                                else if (qtde == "5")
                                {
                                    blueLine.Attributes.Add("style", "transform:translateX(0px)");
                                }

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    conexao_SQL.Close();
                }

                try
                {
                    if (conexao_SQL.State != ConnectionState.Open)
                        conexao_SQL.Open();
                    String select = "SELECT tipoConta FROM tblCliente where usuario = '" + Session["usuario"] + "'";
                    using (SqlCommand comando_sql = new SqlCommand(select, conexao_SQL))
                    {
                        using (SqlDataReader tabela = comando_sql.ExecuteReader())
                        {
                            String tipoConta;
                            tabela.Read();
                            if (tabela.HasRows) {
                                tipoConta = tabela[0].ToString();
                                if (tipoConta == "p") {
                                    blueLine.Attributes.Add("style", "transform:translateX(0px)");
                                    lblPlan.Text = "Plano Premium";
                                }

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

        protected void deslogar_Click(object sender, EventArgs e)
        {
            Session["logado"] = "0";
            if (Request.Cookies["credenciais"] != null)
                Response.Cookies["credenciais"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("default.aspx");
        }
    }
}