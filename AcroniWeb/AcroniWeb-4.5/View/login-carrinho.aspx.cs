using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcroniWeb_4._5.View
{
    public partial class login_carrinho : System.Web.UI.Page
    {
        Utilitarios ut = new Utilitarios();
        SQLMetodos sql = new SQLMetodos();
        public string stringConfirmacao;
        string email = "";
        public string Email { get; set; }
        Default d = new Default();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["logado"].ToString() == "1") {
                Response.Redirect("escolher-pagamento.aspx");
            }
        }

        protected void btnEntra_Click(object sender, EventArgs e)
        {
            d.btnEntra(txtUsu, txtPass, ckbLogin, lblMsg, "~/View/escolher-pagamento.aspx");
            SCPanel.Update();
        }

        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            d.btnSendEmail(step1, txtEmail, lblErro1, step2, modal);
            SCPanel2.Update();
        }

        protected void btnSendCode_Click(object sender, EventArgs e)
        {
            d.btnSendCode(step2, txtCodigo, lblErro1, modal, step3, overflow, btnSendCode, lblErro2);
            SCPanel2.Update();
        }

        protected void btnTrocaSenha_Click(object sender, EventArgs e)
        {
            d.btnTrocaSenha(step2, step3, txtSenha, lblErro3, txtCSenha);
            SCPanel2.Update();
        }
    }
}