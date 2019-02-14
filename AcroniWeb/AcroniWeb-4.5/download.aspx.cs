using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcroniWeb_4._5
{
    public partial class donwload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void BtnDownload_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://github.com/acroni-team/AcroniDesktop/raw/testes-instalador/AcroniInstaller/Debug/AcroniInstaller.msi");
        }
    }
}