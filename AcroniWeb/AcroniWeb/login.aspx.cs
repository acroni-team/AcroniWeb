using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcroniWeb
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        ClasseConexao xx = new ClasseConexao();
        DataSet ds = new DataSet();


        protected void btnIrCad_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("cadastro.aspx");
        }



        protected void btnEntra_Click(object sender, EventArgs e)
        {
            try
            {
                xx = new ClasseConexao();
                ds = new DataSet();
                ds = xx.executa_sql("SELECT * FROM tblCliente WHERE usuario='" + txtUsu.Text + "' AND senha='" + txtPass.Text + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Response.Redirect("area-restrita.aspx");
                }
                else
                {
                    lblMsg.Text = "Credenciais incorretas";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch { }
           

        }
    }
}