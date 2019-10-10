using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Boleto2Net;

namespace AcroniWeb_4._5
{
    public partial class pagamento_cc : System.Web.UI.Page
    {
        PagamentoCC p = new PagamentoCC();
        SQLMetodos sql = new SQLMetodos();
        Utilitarios ut = new Utilitarios();
        Valida v = new Valida();
        protected void Page_Load(object sender, EventArgs e)
        {
            p.pageLoad(imgCards, informe);
            btnSalva.Enabled = true;
        }
       
        protected void btnSalva_Click(object sender, EventArgs e)
        {
            bool[] a = new bool[5];
            if (!v.validarNome(Nome.Text) || string.IsNullOrEmpty(Nome.Text))
            {
                ut.showErrorMessageByLbl("Digite corretamente o nome", Nome, lblNome);
                a[0] = false;
            }
            else
            {
                ut.removeErrorMessageByLbl("Nome", Nome, lblNome);
                a[0] = true;
            }
            if (!v.validarNome(Sobrenome.Text) || string.IsNullOrEmpty(Sobrenome.Text))
            {
                ut.showErrorMessageByLbl("Digite corretamente o sobrenome", Sobrenome, lblSobrenome);
                a[1] = false;
            }
            else
            {
                ut.removeErrorMessageByLbl("Sobrenome", Sobrenome, lblSobrenome);
                a[1] = true;
            }

            if (!v.validarData(DataValidade.Text) || string.IsNullOrEmpty(DataValidade.Text))
            {
                ut.showErrorMessageByLbl("Digite corretamente data", DataValidade, lblDataValidade);
                a[2] = false;
            }
            else
            {
                ut.removeErrorMessageByLbl("Data", DataValidade, lblDataValidade);
                a[2] = true;
            }
            if (!v.Luhn(Numero.Text.Replace(" ", "")) || string.IsNullOrEmpty(Numero.Text))
            {
                ut.showErrorMessageByLbl("Digite corretamente o no. do cartão", Numero, lblNumero);
                a[3] = false;
            }
            else
            {
                ut.removeErrorMessageByLbl("Número", Numero, lblNumero);
                a[3] = true;
            }
            if (!(CodigoSeguranca.Text.Length == 3) || !int.TryParse(CodigoSeguranca.Text, out int n) || string.IsNullOrEmpty(CodigoSeguranca.Text))
            {
                ut.showErrorMessageByLbl("Digite corretamente o CVV", CodigoSeguranca, lblCodigo);
                a[4] = false;
            }
            else
            {
                ut.removeErrorMessageByLbl("Código", CodigoSeguranca, lblCodigo);
                a[4] = true;
            }
            
            if(!a.Contains(false))
            {
                //List<String> t = (List<String>)HttpContext.Current.Session["teclados"];
                //List<String> marcas;
                //switch(t.Count)
                //{
                //    case 1:
                //        marcas = sql.selectCampos("marca", "tblProdutoDaLoja", "id_produto IN (" + t[0] + ")");
                //        sql.insertCompra(marcas[0]);
                //        break;
                //    case 2:
                //        marcas = sql.selectCampos("marca", "tblProdutoDaLoja", "id_produto IN (" + t[0] + ","+t[1]+")");
                //        sql.insertCompra(marcas[0]);
                //        sql.insertCompra(marcas[1]);
                //        break;
                //    case 3:
                //        marcas = sql.selectCampos("marca", "tblProdutoDaLoja", "id_produto IN (" + t[0] + "," + t[1] + ","+t[2]+")");
                //        sql.insertCompra(marcas[0]);
                //        sql.insertCompra(marcas[1]);
                //        sql.insertCompra(marcas[2]);
                //        break;
                //}
                

                Response.Redirect("sucesso-cc.aspx");
            }
                
            
            
        }
    }
}