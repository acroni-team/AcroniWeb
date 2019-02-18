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
    public partial class GetImageTeclado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SQLChamadas sql = new BLL.SQLChamadas();
            Response.BinaryWrite(sql.GetImage("SELECT imagem_teclado FROM tblTecladoCustomizado AS tec INNER JOIN tblCliente AS cli ON cli.id_cliente = tec.id_cliente AND usuario ='" + Session["usuario"] + "' AND id_teclado_customizado = @id_teclado_customizado", "@id_teclado_customizado", Request.QueryString["id"]));
        }
    }
}