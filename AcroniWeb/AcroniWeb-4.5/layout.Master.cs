using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace AcroniWeb
{
    public partial class layout : System.Web.UI.MasterPage
    {
        BLL.SQLChamadas sql = new BLL.SQLChamadas();

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session["usuarioNovo"] != null)
                Session["usuario"] = Session["usuarioNovo"];
            if (Session["logado"].ToString() == "1")
            {
                lblUser.Text = Session["usuario"].ToString();
                user.Attributes.Add("style", "display:block");
                profilePicture.ImageUrl = "data:image/png;base64," + Convert.ToBase64String((byte[])sql.selectImagem("imagem_cliente", "tblCliente", "usuario = '" + Session["usuario"] + "'"));
            }
                   
            
            
        }
    }
}