using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class Carrinho
{
    SQLMetodos sql = new SQLMetodos();
    DataSet ds;
    public void pageLoad(DataList DataList1, Label preco)
    {
        string CurrentUrl = HttpContext.Current.Request.Url.AbsoluteUri;
        CurrentUrl = CurrentUrl.Substring(CurrentUrl.LastIndexOf("=") + 1);

        if (CurrentUrl != "0")
        {
            if (HttpContext.Current.Session["teclados"] != null)
            {
                List<String> t = (List<String>)HttpContext.Current.Session["teclados"];
                if (t.Count < 3 && !t.Contains(CurrentUrl))
                    t.Add(CurrentUrl);
            }
            else
            {
                List<String> t = new List<String>();
                t.Add(CurrentUrl);
                HttpContext.Current.Session["teclados"] = t;
            }
        }
            List<String> teclados = (List<String>)HttpContext.Current.Session["teclados"];
        if (teclados == null || teclados.Count == 0)
            HttpContext.Current.Response.Redirect("loja.aspx");

        if (teclados.Count > 0)
        {
            if (teclados.Count == 3)
            {
                ds = sql.retornaDs("EXEC usp_retornaDs " + teclados[0] + "," + teclados[1] + "," + teclados[2] + ",carrinho");
                preco.Text = "R$" + (Convert.ToDouble(ds.Tables[0].Rows[0]["preco"]) + Convert.ToDouble(ds.Tables[0].Rows[1]["preco"]) + Convert.ToDouble(ds.Tables[0].Rows[2]["preco"]));
            }
            else if (teclados.Count == 2)
            {
                ds = sql.retornaDs("EXEC usp_retornaDs " + teclados[0] + "," + teclados[1] + ",0,carrinho");
                preco.Text = "R$" + (Convert.ToDouble(ds.Tables[0].Rows[0]["preco"]) + Convert.ToDouble(ds.Tables[0].Rows[1]["preco"]));
            }
            else if (teclados.Count == 1)
            {
                ds = sql.retornaDs("EXEC usp_retornaDs " + teclados[0] + ",0,0,carrinho");
                preco.Text = "R$" + Convert.ToDouble(ds.Tables[0].Rows[0]["preco"]);
            }
            DataList1.DataSource = ds.Tables[0];
            DataList1.DataBind();
        }
    }

}
