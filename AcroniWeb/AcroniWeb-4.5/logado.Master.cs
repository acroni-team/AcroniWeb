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
using BLL;

namespace AcroniWeb_4._5
{
    public partial class logado : System.Web.UI.MasterPage
    {
        BLL.SQLChamadas sql = new BLL.SQLChamadas();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuarioNovo"] != null)
                Session["usuario"] = Session["usuarioNovo"];
            if (Session["logado"].ToString() != "1")
                Response.Redirect("default.aspx");
            else
                lblUser.Text = Session["usuario"].ToString();

            profilePicture.ImageUrl = "data:image/png;base64," + Convert.ToBase64String((byte[])sql.selectImagem("imagem_cliente", "tblCliente", "usuario = '" + Session["usuario"] + "'"));
            if (sql.selectHasRows("quantidade_teclados", "tblCliente", "usuario = '" + Session["usuario"] + "'"))
            {
                string qtde = sql.selectCampos("quantidade_teclados", "tblCliente", "usuario = '" + Session["usuario"] + "'")[0];
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

            if (sql.selectHasRows("tipoConta", "tblCliente", "usuario = '" + Session["usuario"] + "'"))
            {
                if (sql.selectCampos("tipoConta", "tblCliente", "usuario = '" + Session["usuario"] + "'")[0] == "p")
                {
                    blueLine.Attributes.Add("style", "transform:translateX(0px)");
                    lblPlan.Text = "Plano Premium";
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