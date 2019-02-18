using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace AcroniWeb_4._5
{
    public partial class GetImage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SQLChamadas sql = new BLL.SQLChamadas();
            Response.BinaryWrite(sql.GetImage("SELECT imagem_colecao FROM tblColecao AS colec INNER JOIN tblCliente AS cli ON cli.id_cliente = colec.id_cliente AND usuario ='" + Session["usuario"] + "' AND id_colecao = @id_colecao", "@id_colecao", Request.QueryString["id"]));
        }

    }
}