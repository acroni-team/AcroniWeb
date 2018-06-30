using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace PrjASPX_v2._0
{
    public partial class AreaRestrita1 : System.Web.UI.Page
    {

        
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["logado"] != "1")
               Response.Redirect("Default.aspx");
        }

       

       

        
    }
}
