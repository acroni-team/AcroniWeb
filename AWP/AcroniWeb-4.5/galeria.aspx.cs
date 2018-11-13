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
                try {
                    if (!Page.IsPostBack)
                    {
                        if (conexao_SQL.State != ConnectionState.Open)
                            conexao_SQL.Open();
                        String select = "SELECT * FROM tblColecao";
                        using (SqlDataAdapter da = new SqlDataAdapter(select, conexao_SQL))
                        {
                            ds = new DataSet();
                            da.Fill(ds);
                            DataList1.DataSource = ds.Tables[0];
                            DataList1.DataBind();
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
                    String select = "SELECT imagem_colecao FROM tblColecao AS colec INNER JOIN tblCliente AS cli ON cli.id_cliente = colec.id_cliente AND usuario ='" + Session["usuario"] + "'";

                    using (SqlCommand comando_SQL = new SqlCommand(select, conexao_SQL))
                    {
                        using (SqlDataReader tabela = comando_SQL.ExecuteReader())
                        {
                            tabela.Read();
                            if (tabela.HasRows)
                            {
                                imgStatus.Attributes.Add("style", "display:none");
                                header.Attributes["class"] = "galeria-header is-showing";
                            }
                            else {
                                imgStatus.Attributes.Add("style", "display:block");
                                header.Attributes["class"] = "galeria-header";
                                ds.Tables[0].Rows[0].Delete();
                                DataList1.DataSource = ds;
                                DataList1.DataBind();
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