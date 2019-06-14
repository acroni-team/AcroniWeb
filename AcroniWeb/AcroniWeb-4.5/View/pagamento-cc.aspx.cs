using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Boleto2Net;

namespace AcroniWeb_4._5
{
    public partial class pagamento_cc : System.Web.UI.Page
    {
        PagamentoCC p = new PagamentoCC();
        protected void Page_Load(object sender, EventArgs e)
        {
            p.pageLoad(imgCards, informe);
            btnSalva.Enabled = true;
        }
       
        protected void btnSalva_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}