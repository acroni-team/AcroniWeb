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


    //Validacões utilizando regex
    public bool validarCep(string cep)
    {
        bool retorno = false;
        Regex rgx = new Regex("[0-9]{5}-[0-9]{3}");
        if (cep.Length < 8)
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
        
    public bool validarNome(string nome)
    {
        Regex rg = new Regex(@"^[a-zA-Z áàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÒÖÚÇÑ]{4,}$");
        bool retorno = false;
        
        if(rg.IsMatch(nome))
            retorno = true;
        else
            retorno = false;
        
        return retorno;
    }

    public bool validarUsu(string usu)
    {
        Regex rg = new Regex(@"[a-zA-ZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÒÖÚÇÑ]{4,}[0-9_\-]{0,}");
        bool retorno = false;

        if (rg.IsMatch(usu))
            retorno = true;
        else
            retorno = false;

        return retorno;
    }
    
    public bool validarEmail(string email)
    {
        bool retorno = false;
        Regex validacao_email = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        if (validacao_email.IsMatch(email))
            retorno = true;
        else
            retorno = false;

        return retorno;
    }


}
