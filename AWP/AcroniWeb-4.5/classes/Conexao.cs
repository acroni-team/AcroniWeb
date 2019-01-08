using System.Data.SqlClient;
using System.Data;
using System;

namespace acroni.classes
{
    class Conexao
    {
        internal static String nome_usuario { get; set; }
        internal static String param = "Data Source = " + Environment.MachineName + "; Initial Catalog = ACRONI_SQL; User ID = acroni; Password = acroni7";
        internal static SqlConnection conexao = new SqlConnection(param);
        internal static String nome_conexao = "Data Source = " + Environment.MachineName + "; Initial Catalog = ACRONI_SQL; User ID = acroni; Password = acroni7";

        public void AbrirConexao()
        {
            if (conexao.State == ConnectionState.Closed)
            {
                conexao.OpenAsync();
            }
            else
            {
                throw new Exception("A conexão com o banco já está aberta");
            }
        }
        public void FecharConexao()
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
            else
            {
                throw new Exception("A conexão com o banco já está fechada");
            }
        }
    }
}
