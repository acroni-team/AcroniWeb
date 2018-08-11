using System;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

public class Valida
{
    
    public bool validarData(String data)
    {
        bool ret = false;
        DateTime dataValida = DateTime.MinValue;
        if (DateTime.TryParse(data.Trim(), out dataValida))
            ret = true;
        else
            ret = false;

        return ret;
    }

    
    public bool validarCPF(String CPF)
    {
        int verify = 0, verifyCheck = 0, cont = 0;
        bool firstStep, secondStep, retorno;
        CPF = CPF.Replace(".", "").Replace(",", "").Replace("-", "");

        if (CPF.Length != 11)
            return retorno = false;
        else
        {
            if (CPF == "00000000000" || CPF == "11111111111" || CPF == "22222222222" || CPF == "33333333333" || CPF == "44444444444" || CPF == "55555555555" || CPF == "66666666666" || CPF == "77777777777" || CPF == "88888888888" || CPF == "99999999999")
            {
                firstStep = false;
                secondStep = false;
            }
            else
            {
                for (int i = 10; i >= 2; i--)
                {
                    verify += Convert.ToInt32(CPF[cont].ToString()) * i;
                    cont++;
                }

                verifyCheck = verify * 10 % 11;

                if (verifyCheck == 10)
                    verifyCheck = 0;

                if (verifyCheck == Convert.ToInt16(CPF[9] + ""))
                    firstStep = true;
                else
                    return false;

                cont = 0;
                verify = 0;
                verifyCheck = 0;

                for (int i = 11; i >= 2; i--)
                {
                    verify += Convert.ToInt16(CPF[cont] + "") * i;
                    cont++;
                }

                verifyCheck = verify * 10 % 11;

                if (verifyCheck == 10)
                    verifyCheck = 0;

                if (verifyCheck == Convert.ToInt16(CPF[10] + ""))
                    secondStep = true;
                else
                    return false;
            }


            if (firstStep == true && secondStep == true)
                retorno = true;
            else
                retorno = false;

            return retorno;

        }
    }

    public bool validarCNPJ(String cnpj)
    {
        int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int soma;
        int resto;
        string digito;
        string tempCnpj;
        cnpj = cnpj.Trim();
        cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
        if (cnpj.Length != 14)
            return false;
        tempCnpj = cnpj.Substring(0, 12);
        soma = 0;
        for (int i = 0; i < 12; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
        resto = (soma % 11);
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito = resto.ToString();
        tempCnpj = tempCnpj + digito;
        soma = 0;
        for (int i = 0; i < 13; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
        resto = (soma % 11);
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito = digito + resto.ToString();
        return cnpj.EndsWith(digito);
    }

    public bool ValidaCep(string cep)
    {
        bool retorno = false;
        Regex rgx = new Regex("[0-9]{5}-[0-9]{3}");
        if (cep.Length < 9)
        {
            return retorno = false;
        }
        else
        {
            if (rgx.IsMatch(cep))
                retorno = true;
            else
                retorno = false;

            return retorno;
        }
    }

    public bool validarEmail(String email)
    {
        Regex Rgx = new Regex(@"\A[a-z0-9]+([-._][a-z0-9]+)*@([a-z0-9]+(-[a-z0-9]+)*\.)+[a-z]{2,4}\z");
        bool d = true;
        if (!Rgx.IsMatch(email))
            d = false;
        else
            d = true;

        return d;
    }

    

}
