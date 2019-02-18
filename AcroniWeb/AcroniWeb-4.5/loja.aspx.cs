using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace AcroniWeb
{
    public partial class loja : System.Web.UI.Page
    {


        static BLL.SQLChamadas sql = new BLL.SQLChamadas();

        [System.Web.Services.WebMethod]
        public static double  calcularFrete(string cep, string id)
        {
            List<string> teclado = sql.selectCampos("*", "tblProdutoDaLoja", "id_produto = "+id+"");
            var correios = new AcroniWeb_4._5.WSCorreiosFrete.CalcPrecoPrazoWSSoapClient();
            var resposta = correios.CalcPrecoPrazo(string.Empty, string.Empty, "40010", "01101010", cep, teclado[3].ToString(), 1, decimal.Parse(teclado[6]), decimal.Parse(teclado[4]), decimal.Parse(teclado[5]), 0, "N", decimal.Parse(teclado[7]), "N");
            var respostaReal = resposta.Servicos.FirstOrDefault();
            return double.Parse(respostaReal.Valor);
        }
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["logado"].ToString() == "1")
            {
                sobre.Attributes.Add("style", "display:none");
                logoacr.Attributes["href"] = "galeria.aspx";
            }

            ds = sql.retornaDs("SELECT TOP 3 * FROM tblProdutoDaLoja");
            DataList1.DataSource = ds.Tables[0];
            DataList1.DataBind();

            ds = sql.retornaDs("SELECT * FROM tblProdutoDaloja WHERE id_produto > 3");
            DataList2.DataSource = ds.Tables[0];
            DataList2.DataBind();

        }


    }
}