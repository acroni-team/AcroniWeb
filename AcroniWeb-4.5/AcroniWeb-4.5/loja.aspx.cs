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
    public partial class loja : System.Web.UI.Page
    {
        SqlConnection conexao_sql = new SqlConnection("Data Source = " + Environment.MachineName + "\\SQLEXPRESS" + ";Initial Catalog = Acroni_SQL; User ID = Acroni; Password = acroni7");
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (conexao_sql.State != ConnectionState.Open)
                    conexao_sql.Open();
                String select = "SELECT * FROM tblProdutos";
                SqlDataAdapter da = new SqlDataAdapter(select, conexao_sql);
                ds = new DataSet();
                da.Fill(ds);
                DataList1.DataSource = ds.Tables[0];
                DataList1.DataBind();

                conexao_sql.Close();
            }
            catch (Exception ex)
            {
                conexao_sql.Close();
            }
        }
    }  
}