using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcroniWeb_4._5
{
    public partial class galeria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["logado"].ToString() != "1")
                Response.Redirect("default.aspx");
            else
                lblUser.Text = Session["usuario"].ToString();

        }
    }
}