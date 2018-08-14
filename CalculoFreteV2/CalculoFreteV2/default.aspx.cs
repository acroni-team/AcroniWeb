using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CalculoFreteV2
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtCep_TextChanged(object sender, EventArgs e)
        {
            if (txtCep.Text.Length == 8)
            {
                var correios = new WSCorreiosFrete.CalcPrecoPrazoWSSoapClient();
                var resposta = correios.CalcPrecoPrazo(string.Empty, string.Empty, "40010", "01101010", txtCep.Text, "6", 1, 20, 10, 26, 0, "N", 200, "N");
                var respostaReal = resposta.Servicos.FirstOrDefault();
                if (Convert.ToInt16(respostaReal.PrazoEntrega) > 1)
                    lblPreco.Text = respostaReal.Valor + " em " + respostaReal.PrazoEntrega + " dias";
                else
                    lblPreco.Text = respostaReal.Valor + " em " + respostaReal.PrazoEntrega + " dia";
            }
        }
    }
}