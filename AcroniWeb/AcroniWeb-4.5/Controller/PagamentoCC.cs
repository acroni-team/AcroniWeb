using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

public class PagamentoCC
{

    public void pageLoad(Image imgCards, Label informe)
    {
        string type = HttpContext.Current.Request.QueryString["type"];
        if (type != "cc")
        {
            informe.Text += "débito";
            imgCards.ImageUrl = "assets/img/pagamento/cd.png";
        }
        else
        {
            informe.Text += "crédito";
            imgCards.ImageUrl = "assets/img/pagamento/cc.png";
        }
    }

}
