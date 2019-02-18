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
    public partial class galeria : System.Web.UI.Page
    {
        BLL.SQLChamadas sql = new SQLChamadas();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Nome.Text = Session["usuario"].ToString();
            //DataSet ds = sql.primeiroGaleria(Session["usuario"].ToString());
            //if (!Page.IsPostBack)
            //{
            //    DataList1.DataSource = ds.Tables[0];
            //    DataList1.DataBind();
            //}

            //if (sql.segundoGaleria(Session["usuario"].ToString()))
            //{
            //    imgStatus.Attributes.Add("style", "display:none");
            //    header.Attributes["class"] = "galeria-header is-showing";
            //}
            //else
            //{
            //    imgStatus.Attributes.Add("style", "display:block");
            //    header.Attributes["class"] = "galeria-header";
            //    ds.Tables[0].Rows[0].Delete();
            //    DataList1.DataSource = ds;
            //    DataList1.DataBind();
            //}
                
        }
    }
}