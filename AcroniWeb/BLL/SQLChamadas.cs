using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SQLChamadas
    {
        DAL.SQLMetodos sql = new DAL.SQLMetodos();

        public bool selectHasRows(string campos, string tabela, string condicao)
        {
            return sql.selectHasRows(campos, tabela, condicao);
        }

        public void update(string tabela, string condicao, string novaAtribuicao)
        {
            sql.update(tabela, condicao, novaAtribuicao);
        }

        public void updateImagem(byte[] imgBytes, string tabela, string condicao)
        {
            sql.updateImagem(imgBytes, tabela, condicao);
        }

        public object selectImagem(string campo, string tabela, string condicao)
        {
            return sql.selectImagem(campo, tabela, condicao);
        }

        public List<string> selectCampos(string campos, string tabela, string condicao)
        {
            return sql.selectCampos(campos, tabela, condicao);
        }

        public void delete(string tabela, string condicao)
        {
            sql.delete(tabela, condicao);
        }

        public void inserirUsuario(string nome, string usu, string email, string cpf, string senha)
        {
            sql.inserirUsuario(nome, usu, email, cpf, senha);
        }

        public DataSet retornaDs(string select)
        {
            return sql.retornaDs(select);
        }

        public bool segundoGaleria(string usu)
        {
            return sql.segundoGaleria(usu);
        }

        public byte[] GetImage(string select, string param, string id)
        {
            return sql.GetImage(select, param, id);
        }

        public void retirarSQLEXPRESS()
        {
            sql.retirarSQLEXPRESS();
        }
    }
}
