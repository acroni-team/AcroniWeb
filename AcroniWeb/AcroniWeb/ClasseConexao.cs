using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

    public class ClasseConexao
    {
        SqlConnection conexao = new SqlConnection();

        private SqlConnection conectar()
        {
            try
            {
            String strConexao = "Password=banco123; Persist Security Info=True; User ID=sa; Initial Catalog=DB; Data Source=" + Environment.MachineName + "\\SQLEXPRESS";
                conexao.ConnectionString = strConexao;
                conexao.Open();
                return conexao;
            }
            catch (Exception)
            {
                desconectar();
                return null;
            }
        }

        public void desconectar()
        {
            try
            {
                if ((conexao.State == ConnectionState.Open))
                {
                    conexao.Close();
                    conexao.Dispose();
                    conexao = null;
                }
            }
            catch (Exception) { }
        }

        public DataSet executa_sql(String comando_sql)
        {
            try
            {
                SqlDataAdapter adaptador = new SqlDataAdapter(comando_sql, conectar());
                DataSet ds = new DataSet();
                adaptador.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                desconectar();
            }
        }

        public DataTable executa_Procedure(String x)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                conectar();
                cmd = new SqlCommand("minha_procedure", conectar()); //não digitar Exec, não passar os parâmetros
                cmd.Parameters.Add(new SqlParameter("@par1", x));
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (Exception){}
            return dt;
        }


        public bool manutencao(String comando_sql) //teste
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = comando_sql;
                comando.Connection = conectar();
                conexao.Open();
                comando.ExecuteScalar();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                desconectar();
            }
        }
    }
