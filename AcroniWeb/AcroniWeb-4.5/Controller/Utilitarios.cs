using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Boleto2Net;

public class Utilitarios
{
    SqlCommand comando_SQL;
    Valida v = new Valida();
    string select = "";
    public bool verificarCampoExistenteBanco(string atributo, string campo)
    {
        using (SqlConnection conexao_SQL = new SqlConnection(Conexao.nome_conexao))
        {
            bool retorno = false;
            try
            {
                if (conexao_SQL.State == ConnectionState.Closed)
                    conexao_SQL.Open();

                if (atributo.Equals("usuario"))
                    select = "SELECT * FROM tblCliente WHERE usuario = '" + campo + "'";
                else if (atributo.Equals("email"))
                    select = "SELECT * FROM tblCliente WHERE email = '" + campo + "'";
                else if (atributo.Equals("cpf"))
                    select = "SELECT * FROM tblCliente WHERE cpf = '" + campo + "'";

                using (SqlCommand comando_SQL = new SqlCommand(select, conexao_SQL))
                {
                    using (SqlDataReader resposta = comando_SQL.ExecuteReader())
                    {
                        resposta.Read();
                        if (resposta.HasRows)
                        {
                            resposta.Close();
                            conexao_SQL.Close();
                            return retorno = true;
                        }
                        else
                        {
                            resposta.Close();
                            conexao_SQL.Close();
                            return retorno = false;
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                conexao_SQL.Close();

            }
            return retorno;
        }
    }


    public string retirarEspacos(string campo)
    {
        if (!string.IsNullOrEmpty(campo) || !string.IsNullOrWhiteSpace(campo))
        {
            while (campo[0].Equals(' '))
                campo = campo.Remove(0, 1);

            while (campo[campo.Length - 1].Equals(' '))
                campo = campo.Remove(campo.Length - 1, 1);
        }
        return campo;
    }

    public string gerarStringConfirmacao()
    {
        string stringConfirmacao = "";
        char[] alfabeto = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        Random r = new Random();
        for (int i = 0; i < 7; i++)
        {
            if (r.Next(2) == 0)
            {
                //alfabeto
                stringConfirmacao += alfabeto[r.Next(26)];
            }
            else
            {
                //numero
                stringConfirmacao += r.Next(10);
            }
        }

        return stringConfirmacao;
    }

    public void enviarEmailConfirmacao(string codigo, string email, string titulo, string msg)
    {
        string[] divide = email.Split('@');

        string corpo = File.ReadAllText(HttpContext.Current.Server.MapPath("email.html"));
        string replaceCodigo = corpo.Replace("#Codigo#", codigo);
        string replaceNome = replaceCodigo.Replace("#NomedeUsuario#", divide[0]);
        string mensagem = replaceNome.Replace("#Mensagem#", msg);
        MailMessage mail = new MailMessage("acroni.acroni7@gmail.com", email, titulo, mensagem);
        mail.IsBodyHtml = true;
        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
        client.EnableSsl = true;
        client.Credentials = new System.Net.NetworkCredential("acroni.acroni7@gmail.com", "acroni77");
        client.Send(mail);
    }

    public void inserirUsuario(string nome, string usu, string email, string cpf, string senha)
    {
        using (SqlConnection conexao_SQL = new SqlConnection(Conexao.nome_conexao))
        {
            try
            {
                if (conexao_SQL.State == ConnectionState.Closed)
                    conexao_SQL.Open();

                string insert = "Exec usp_insertCliente '"+v.vacina(nome)+"', '"+v.vacina(usu)+"', '"+v.vacina(senha)+"', '"+v.vacina(email)+"', '"+v.vacina(cpf)+"'";
                using (comando_SQL = new SqlCommand(insert, conexao_SQL))
                {
                    comando_SQL.ExecuteNonQuery();
                    conexao_SQL.Close();
                }
            }
            catch
            {
                conexao_SQL.Close();
            }
        }
    }

    public byte[] ConvertImageToByteArray(System.Drawing.Image imageToConvert, System.Drawing.Imaging.ImageFormat formatOfImage)
    {
        byte[] Ret;
        try
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageToConvert.Save(ms, formatOfImage);
                Ret = ms.ToArray();
            }
        }
        catch (Exception) { throw; }
        return Ret;
    }
    
    // Mensagens de erro

    public void showErrorMessage(string title, string msg, Label titleErro, Label msgErro,  HtmlGenericControl modal, HtmlGenericControl modalback, HtmlGenericControl overflow)
    {
        titleErro.Text = title;
        msgErro.Text = msg;
        modal.Attributes["class"] = "modal-wrap minha-conta is-showing";
        modalback.Attributes.Add("style", "pointer-events:auto");
        overflow.Attributes["class"] = "modal-overflow modal-overflow-alt";
    }

    public void showErrorMessageByLbl(string msg, TextBox txtCampoErrado, Label lblCampoErrado)
    {

        txtCampoErrado.BorderColor = System.Drawing.Color.Red;
        txtCampoErrado.Text = "";
        lblCampoErrado.Text = msg;
        lblCampoErrado.ForeColor = System.Drawing.Color.Red;

    }

    public void removeErrorMessageByLbl(string msg, TextBox txtCampoErrado, Label lblCampoErrado)
    {

        txtCampoErrado.BorderColor = Color.Transparent;
        txtCampoErrado.Text = "";
        lblCampoErrado.Text = msg;
        lblCampoErrado.ForeColor = Color.FromArgb(1, 114, 118, 125);

    }

    public void gerarBoleto(string nome, string cpf, string produtos, decimal desconto, decimal preco)
    {
        Boletos objBoletos = new Boletos();

        // 'CRIA��O DA PARTE DO CEDENTE
        // Cabe�alho do Banco 756
        objBoletos.Banco = Banco.Instancia(Bancos.Bradesco);
        objBoletos.Banco.Cedente = new Cedente();
        objBoletos.Banco.Cedente.CPFCNPJ = "24.368.434/0001-07";
        objBoletos.Banco.Cedente.Nome = "Acroni Ink";
        objBoletos.Banco.Cedente.Observacoes = "Pague isso logo carinha que estou precisando...rs";
        ContaBancaria conta = new ContaBancaria();
        conta.Agencia = "1234";
        conta.DigitoAgencia = "0";
        conta.OperacaoConta = String.Empty;
        conta.Conta = "12345";
        conta.DigitoConta = "0";
        conta.CarteiraPadrao = "09";
        conta.VariacaoCarteiraPadrao = "";
        conta.TipoCarteiraPadrao = TipoCarteira.CarteiraCobrancaSimples;
        conta.TipoFormaCadastramento = TipoFormaCadastramento.ComRegistro;
        conta.TipoImpressaoBoleto = TipoImpressaoBoleto.Empresa;
        conta.TipoDocumento = TipoDocumento.Tradicional;
        Endereco ender = new Endereco();
        ender.LogradouroEndereco = "Avenida Tiradentes";
        ender.LogradouroNumero = "";
        ender.LogradouroComplemento = "";
        ender.Bairro = "Bom Retiro";
        ender.Cidade = "São Paulo";
        ender.UF = "SP";
        ender.CEP = "01101010";
        objBoletos.Banco.Cedente.Codigo = "123456";
        objBoletos.Banco.Cedente.CodigoDV = "6";
        objBoletos.Banco.Cedente.CodigoTransmissao = "000000";
        objBoletos.Banco.Cedente.ContaBancaria = conta;
        objBoletos.Banco.Cedente.Endereco = ender;
        objBoletos.Banco.FormataCedente();

        // 'CRIA��O DO TITULO
        Boleto Titulo = new Boleto(objBoletos.Banco);
        Titulo.Sacado = new Sacado()
        {
            CPFCNPJ = cpf,
            Endereco = new Boleto2Net.Endereco()
            {
                Bairro = "",
                CEP = "",
                Cidade = "",
                LogradouroComplemento = "",
                LogradouroEndereco = "",
                LogradouroNumero = "",
                UF = ""
            },
            Nome = nome,
            Observacoes = ""
        };
        Titulo.CodigoOcorrencia = "01";
        Titulo.DescricaoOcorrencia = "Remessa Registrar";
        Titulo.NumeroDocumento = "345434";
        Titulo.NumeroControleParticipante = "12";
        Titulo.NossoNumero = ("123456");
        Titulo.DataEmissao = DateTime.Now;
        Titulo.DataVencimento = DateTime.Now.AddDays(15);
        Titulo.ValorTitulo = preco;
        Titulo.Aceite = "N";
        Titulo.EspecieDocumento = TipoEspecieDocumento.DM;
        Titulo.DataDesconto = DateTime.Now.AddDays(15);
        Titulo.ValorDesconto = desconto;
        // 
        // PARTE DA MULTA
        Titulo.DataMulta = DateTime.Now.AddDays(15);
        Titulo.PercentualMulta = 2;
        Titulo.ValorMulta = (Titulo.ValorTitulo
                    * (Titulo.PercentualMulta / 100));
        Titulo.MensagemInstrucoesCaixa = produtos;
        Titulo.DataJuros = DateTime.Now.AddDays(15);
        Titulo.PercentualJurosDia = (10 / 30);
        Titulo.ValorJurosDia = (Titulo.ValorTitulo
                    * (Titulo.PercentualJurosDia / 100));
        string instrucoes = "Acroni, mais que um teclado, o seu.";
        if (string.IsNullOrEmpty(Titulo.MensagemInstrucoesCaixa))
        {
            Titulo.MensagemInstrucoesCaixa = instrucoes;
        }
        else
        {
            Titulo.MensagemInstrucoesCaixa = (Titulo.MensagemInstrucoesCaixa
                        + (Environment.NewLine + instrucoes));
        }

        // 
        // Titulo.CodigoInstrucao1 = String.Empty
        // Titulo.ComplementoInstrucao1 = String.Empty
        // Titulo.CodigoInstrucao2 = String.Empty
        // Titulo.ComplementoInstrucao2 = String.Empty
        // Titulo.CodigoInstrucao3 = String.Empty
        // Titulo.ComplementoInstrucao3 = String.Empty
        Titulo.CodigoProtesto = TipoCodigoProtesto.NaoProtestar;
        Titulo.DiasProtesto = 0;
        Titulo.CodigoBaixaDevolucao = TipoCodigoBaixaDevolucao.NaoBaixarNaoDevolver;
        Titulo.DiasBaixaDevolucao = 0;
        Titulo.ValidarDados();
        objBoletos.Add(Titulo);


        var boletoBancario = new BoletoBancario();
        boletoBancario.Boleto = objBoletos[0];


        HttpContext.Current.Response.Clear();
        MemoryStream ms = new MemoryStream(boletoBancario.MontaBytesPDF());
        HttpContext.Current.Response.ContentType = "application/pdf";
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=boleto.pdf");
        HttpContext.Current.Response.Buffer = true;
        ms.WriteTo(HttpContext.Current.Response.OutputStream);
        HttpContext.Current.Response.End();
    }
}
