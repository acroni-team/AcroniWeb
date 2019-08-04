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
    public void pageLoad(DataList DataList1)
    {
        string CurrentUrl = HttpContext.Current.Request.Url.AbsoluteUri;
        CurrentUrl = CurrentUrl.Substring(CurrentUrl.LastIndexOf("=") + 1);
        ds = sql.retornaDs("EXEC usp_retornaDs "+ CurrentUrl + ",loja1");
        DataList1.DataSource = ds.Tables[0];
        DataList1.DataBind();

    }

}
