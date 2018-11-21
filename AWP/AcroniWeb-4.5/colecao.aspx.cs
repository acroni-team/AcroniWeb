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
    public partial class colecao : System.Web.UI.Page
    {
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            //using (SqlConnection conexao_SQL = new SqlConnection(acroni.classes.Conexao.nome_conexao))
            //{
            //    try
            //    {
            //        if (conexao_SQL.State != ConnectionState.Open)
            //            conexao_SQL.Open();
            //        String select = "SELECT imagem_teclado FROM tblTecladoCustomizado t INNER JOIN tblCliente c ON c.id_cliente = t.id_cliente AND usuario = '" + Session["usuario"] + "'";
            //        using (SqlCommand comando_sql = new SqlCommand(select, conexao_SQL))
            //        {
            //            using (SqlDataReader tabela = comando_sql.ExecuteReader())
            //            {
            //                tabela.Read();
            //                byte[] imgBytes = (byte[])tabela[0];

            //                string imgString = Convert.ToBase64String(imgBytes);
            //                imgFoto.ImageUrl = "data:image/png;base64," + imgString;

            //                conexao_SQL.Close();
            //            }
            //        }
            //        String select2 = "SELECT nickname FROM tblTecladoCustomizado t INNER JOIN tblCliente c ON c.id_cliente = t.id_cliente AND usuario = '" + Session["usuario"] + "'";
            //        if (conexao_SQL.State != ConnectionState.Open)
            //            conexao_SQL.Open();
            //        using (SqlCommand comando_sql = new SqlCommand(select2, conexao_SQL))
            //        {
            //            using (SqlDataReader tabela2 = comando_sql.ExecuteReader())
            //            {
            //                tabela2.Read();
            //                //byte[] nomeBytes = (byte[])tabela2[0];

            //                //string nomeString = Convert.ToBase64String(nomeBytes);
            //                lblNome.Text = tabela2[0].ToString();

            //                conexao_SQL.Close();
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        conexao_SQL.Close();
            //    }
            //}

            using (SqlConnection conexao_SQL = new SqlConnection(acroni.classes.Conexao.nome_conexao))
            {
                try
                {
                    if (!Page.IsPostBack)
                    {
                        if (conexao_SQL.State != ConnectionState.Open)
                            conexao_SQL.Open();
                        //string id = Request.QueryString["id"];
                        //String select = "SELECT * FROM tblTecladoCustomizado t INNER JOIN tblCliente c ON c.id_cliente = t.id_cliente AND usuario='" + Session["usuario"] + "' AND id_colecao = @id_colecao";
                        //String select2 = "SELECT * FROM tblTecladoCustomizado t INNER JOIN tblCliente c ON c.id_cliente = t.id_cliente AND usuario = '" + Session["usuario"] + "'";
                        //using (SqlCommand comando_SQL = new SqlCommand(select, conexao_SQL))
                        //{
                        //    comando_SQL.Parameters.Add("@id_colecao", SqlDbType.Int).Value = Int32.Parse(id);
                        //    using (SqlDataReader tabela = comando_SQL.ExecuteReader())
                        //    {
                        //        tabela.Read();
                        //        if (tabela.HasRows)
                        //        {
                        //            using (SqlDataAdapter da = new SqlDataAdapter(select2, conexao_SQL))
                        //            {
                        //                ds = new DataSet();
                        //                da.Fill(ds);
                        //                DataList1.DataSource = ds.Tables[0];
                        //                DataList1.DataBind();
                        //            }

                        //        }

                        //    }
                        //}
                        string CurrentUrl = HttpContext.Current.Request.Url.AbsoluteUri;
                        CurrentUrl = CurrentUrl.Substring(CurrentUrl.LastIndexOf("=") + 1);
                        //string id = Request.QueryString["id"];
                        String select = "SELECT * FROM tblTecladoCustomizado t INNER JOIN tblCliente c ON c.id_cliente = t.id_cliente AND usuario='" + Session["usuario"] + "' AND id_colecao =" + CurrentUrl;

                        using (SqlDataAdapter da = new SqlDataAdapter(select, conexao_SQL))
                        {
                            //da.SelectCommand.Parameters.AddWithValue("@id_colecao", "%" + id + "%");

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


                //string s = Page.Request.Url.AbsolutePath;
                //s = s.Substring(s.LastIndexOf("/") + 1);
                //string CurrentUrl = HttpContext.Current.Request.Url.AbsoluteUri;
                //CurrentUrl = CurrentUrl.Substring(CurrentUrl.LastIndexOf("=") + 1);
                ////s = Form.Attributes["action"].ToString();
                //lblhue.Text = CurrentUrl;
               
            }
        }
    }
}