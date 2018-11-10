using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcroniWeb_4._5
{
    public partial class pagamento_cc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string type = Request.QueryString["type"];
            if(type != "cc")
            {
                informe.Text += "débito";
                imgCards.ImageUrl = "img/pagamento/cd.png";
            }
            else
            {
                informe.Text += "crédito";
                imgCards.ImageUrl = "img/pagamento/cc.png";
            }
        }
    }
}