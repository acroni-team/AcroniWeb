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
    public partial class colecao : System.Web.UI.Page
    {
        BLL.SQLChamadas sql = new BLL.SQLChamadas();
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                string CurrentUrl = HttpContext.Current.Request.Url.AbsoluteUri;
                CurrentUrl = CurrentUrl.Substring(CurrentUrl.LastIndexOf("=") + 1);
                ds = sql.retornaDs("SELECT * FROM tblTecladoCustomizado t INNER JOIN tblCliente c ON c.id_cliente = t.id_cliente AND usuario='" + Session["usuario"] + "' AND id_colecao =" + CurrentUrl);
                DataList1.DataSource = ds.Tables[0];
                DataList1.DataBind();
            }
                                            
        }
    }
}