using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrjASPX_v2._0
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEntra_Click(object sender, EventArgs e)
        {
            if (txtUsu.Text == "1" && txtPass.Text == "1")
            {
                Session["logado"] = "1";
                Response.Redirect("AreaRestrita.aspx");
            }
            else
            {
                Session["logado"] = "0";
                lblMsg.Text = "Não consegue né Moises";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}