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
    public partial class galeria : System.Web.UI.Page
    {
        SqlConnection conexao_SQL = new SqlConnection(acroni.classes.Conexao.nome_conexao);
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["logado"].ToString() != "1")
                Response.Redirect("default.aspx");
            else
                lblUser.Text = Session["usuario"].ToString();

            try
            {
                if (conexao_SQL.State != ConnectionState.Open)
                    conexao_SQL.Open();
                String select = "SELECT * FROM tblColecao";
                SqlDataAdapter da = new SqlDataAdapter(select, conexao_SQL);
                ds = new DataSet();
                da.Fill(ds);
                DataList1.DataSource = ds.Tables[0];
                DataList1.DataBind();

                conexao_SQL.Close();
            }
            catch (Exception ex)
            {
                conexao_SQL.Close();
            }
        }
    }
}