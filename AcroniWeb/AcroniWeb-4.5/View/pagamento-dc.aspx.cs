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
    public partial class pagamento_dc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalva_Click(object sender, EventArgs e)
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
                    CPFCNPJ = "03861018250",
                    Endereco = new Boleto2Net.Endereco()
                    {
                        Bairro = "Apex",
                        CEP = "14154710",
                        Cidade = "Legends",
                        LogradouroComplemento = "",
                        LogradouroEndereco = "Bar da esquina",
                        LogradouroNumero = "569",
                        UF = "SP"
                    },
                    Nome = "Gibraltar dos Santos",
                    Observacoes = ""
                };
                Titulo.CodigoOcorrencia = "01";
                Titulo.DescricaoOcorrencia = "Remessa Registrar";
                Titulo.NumeroDocumento = "345434";
                Titulo.NumeroControleParticipante = "12";
                Titulo.NossoNumero = ("123456");
                Titulo.DataEmissao = DateTime.Now;
                Titulo.DataVencimento = DateTime.Now.AddDays(15);
                Titulo.ValorTitulo = 1200;
                Titulo.Aceite = "N";
                Titulo.EspecieDocumento = TipoEspecieDocumento.DM;
                Titulo.DataDesconto = DateTime.Now.AddDays(15);
                Titulo.ValorDesconto = 100;
                // 
                // PARTE DA MULTA
                Titulo.DataMulta = DateTime.Now.AddDays(15);
                Titulo.PercentualMulta = 2;
                Titulo.ValorMulta = (Titulo.ValorTitulo
                            * (Titulo.PercentualMulta / 100));
                Titulo.MensagemInstrucoesCaixa = "Razer BlackWidow X Chroma.";
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
            
            
            Response.Clear();
            MemoryStream ms = new MemoryStream(boletoBancario.MontaBytesPDF());
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=boleto.pdf");
            Response.Buffer = true;
            ms.WriteTo(Response.OutputStream);
            Response.End();
        }
    }
}