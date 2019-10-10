using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


public class SQLMetodos
{

    public bool selectHasRows(string campos, string tabela, string condicao)
    {
        string select = "EXEC usp_select '"+campos+"', '"+tabela+"', '"+condicao+"'";
        using (SqlConnection conexao_SQL = new SqlConnection(Conexao.nome_conexao))
        {
            if (conexao_SQL.State == ConnectionState.Closed)
                conexao_SQL.Open();
            using (SqlCommand comando_sql = new SqlCommand(select, conexao_SQL))
            {
                using (SqlDataReader leitor = comando_sql.ExecuteReader())
                {
                    if (leitor.HasRows)
                        return true;
                    else
                        return false;
                }
            }
        }
    }

    public void update(string tabela, string condicao, string novaAtribuicao)
    {
        //string update = "UPDATE " + tabela + " SET " + novaAtribuicao + " WHERE " + condicao;
        string update = "EXEC usp_update "+tabela+", "+condicao+", "+novaAtribuicao;
        using (SqlConnection conexao_SQL = new SqlConnection(Conexao.nome_conexao))
        {
            if (conexao_SQL.State == ConnectionState.Closed)
                conexao_SQL.Open();
            using (SqlCommand comando_sql = new SqlCommand(update, conexao_SQL))
            {
                comando_sql.ExecuteNonQuery();
            }
        }
    }

    public void updateImagem(byte[] imgBytes, string usuario)
    {
        string update = "EXEC usp_updateImagemCliente @image, '"+usuario+"'";
        using (SqlConnection conexao_SQL = new SqlConnection(Conexao.nome_conexao))
        {
            if (conexao_SQL.State == ConnectionState.Closed)
                conexao_SQL.Open();
            using (SqlCommand comando_sql = new SqlCommand(update, conexao_SQL))
            {
                comando_sql.Parameters.AddWithValue("@image", imgBytes);
                comando_sql.ExecuteNonQuery();
            }
        }
    }

    public object selectImagem(string campo, string tabela, string condicao)
    {
        string select = "SELECT " + campo + " FROM " + tabela + " WHERE " + condicao;
        using (SqlConnection conexao_SQL = new SqlConnection(Conexao.nome_conexao))
        {
            if (conexao_SQL.State == ConnectionState.Closed)
                conexao_SQL.Open();
            using (SqlCommand comando_sql = new SqlCommand(select, conexao_SQL))
            {
                using (SqlDataReader leitor = comando_sql.ExecuteReader())
                {
                    leitor.Read();
                    return leitor[0];
                }
            }
        }
    }

    public List<string> selectCampos(string campos, string tabela, string condicao)
    {
        string select = "EXEC usp_select '" + campos + "', '" + tabela + "', '" + condicao + "'";
        using (SqlConnection conexao_SQL = new SqlConnection(Conexao.nome_conexao))
        {
            if (conexao_SQL.State == ConnectionState.Closed)
                conexao_SQL.Open();
            using (SqlCommand comando_sql = new SqlCommand(select, conexao_SQL))
            {
                using (SqlDataReader leitor = comando_sql.ExecuteReader())
                {
                    leitor.Read();
                    List<string> lista = new List<string>();
                    for (int i = 0; i < leitor.FieldCount; i++)
                        lista.Add(leitor[i].ToString());

                    return lista;
                }
            }
        }
    }

    public void delete(string tabela, string condicao)
    {
        string delete = "EXEC usp_delete "+tabela+", " + condicao;
        using (SqlConnection conexao_SQL = new SqlConnection(Conexao.nome_conexao))
        {
            if (conexao_SQL.State == ConnectionState.Closed)
                conexao_SQL.Open();
            using (SqlCommand comando_sql = new SqlCommand(delete, conexao_SQL))
                comando_sql.ExecuteNonQuery();
        }
    }

    public void insertCompra(string marca)
    {
        string delete = "EXEC usp_insertMarca " + marca;
        using (SqlConnection conexao_SQL = new SqlConnection(Conexao.nome_conexao))
        {
            if (conexao_SQL.State == ConnectionState.Closed)
                conexao_SQL.Open();
            using (SqlCommand comando_sql = new SqlCommand(delete, conexao_SQL))
                comando_sql.ExecuteNonQuery();
        }
    }

    public DataSet retornaDs(string select)
    {
        DataSet ds = new DataSet();
        using (SqlConnection conexao_SQL = new SqlConnection(Conexao.nome_conexao))
        {
            try
            {
                if (conexao_SQL.State != ConnectionState.Open)
                    conexao_SQL.Open();

                using (SqlDataAdapter da = new SqlDataAdapter(select, conexao_SQL))
                {
                    da.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                conexao_SQL.Close();
                return ds;
            }
        }
    }

    public bool segundoGaleria(string usu)
    {
        using (SqlConnection conexao_SQL = new SqlConnection(Conexao.nome_conexao))
        {
            try
            {
                if (conexao_SQL.State != ConnectionState.Open)
                    conexao_SQL.Open();
                String select = "EXEC usp_segundoGaleria "+usu;

                using (SqlCommand comando_SQL = new SqlCommand(select, conexao_SQL))
                {
                    using (SqlDataReader tabela = comando_SQL.ExecuteReader())
                    {
                        tabela.Read();
                        if (tabela.HasRows)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                }


            }
            catch (Exception ex)
            {
                conexao_SQL.Close();
                return false;
            }
        }
    }

    public byte[] GetImage(string select, string param, string id)
    {
        using (SqlConnection conexao_SQL = new SqlConnection(Conexao.nome_conexao))
        {
            byte[] a = null;
            try
            {
                if (conexao_SQL.State != ConnectionState.Open)
                    conexao_SQL.Open();

                using (SqlCommand comando_SQL = new SqlCommand(select, conexao_SQL))
                {
                    comando_SQL.Parameters.Add(param, SqlDbType.Int).Value = Int32.Parse(id);
                    using (SqlDataReader tabela = comando_SQL.ExecuteReader())
                    {
                        tabela.Read();
                        if (tabela.HasRows)
                        {
                            return (byte[])tabela["imagem_colecao"];
                        }
                        else
                        {
                            return a;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                conexao_SQL.Close();
                return a;
            }
        }
    }

}
