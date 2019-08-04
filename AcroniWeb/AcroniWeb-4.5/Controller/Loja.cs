using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class Loja
{
    SQLMetodos sql = new SQLMetodos();
    DataSet ds;
    public void pageLoad(DataList DataList1, DataList DataList2, HtmlAnchor sobre, HtmlAnchor logoacr)
    {
        if (HttpContext.Current.Session["logado"].ToString() == "1")
        {
            sobre.Attributes.Add("style", "display:none");
            logoacr.Attributes["href"] = "galeria.aspx";
        }

        ds = sql.retornaDs("EXEC usp_retornaDs 0,loja1");
        DataList1.DataSource = ds.Tables[0];
        DataList1.DataBind();

        ds = sql.retornaDs("EXEC usp_retornaDs 0,loja2");
        DataList2.DataSource = ds.Tables[0];
        DataList2.DataBind();
    }

}
