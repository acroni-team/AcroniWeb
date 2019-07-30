using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcroniWeb_4._5.View
{
    public partial class carrinho : System.Web.UI.Page
    {
        static SQLMetodos sql = new SQLMetodos();
        Carrinho c = new Carrinho();
        protected void Page_Load(object sender, EventArgs e)
        {
            c.pageLoad(DataList1);
        }
    }
}