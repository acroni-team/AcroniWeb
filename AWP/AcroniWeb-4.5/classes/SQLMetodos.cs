﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


public class SQLMetodos
{
     
    public bool selectHasRows(string campos, string tabela, string condicao)
    {
        string select = "SELECT " + campos + " FROM " + tabela + " WHERE " + condicao;
        using (SqlConnection conexao_SQL = new SqlConnection(acroni.classes.Conexao.nome_conexao))
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
        string update = "UPDATE " + tabela + " SET " +  novaAtribuicao + " WHERE " + condicao;
        using (SqlConnection conexao_SQL = new SqlConnection(acroni.classes.Conexao.nome_conexao))
        {
            if (conexao_SQL.State == ConnectionState.Closed)
                conexao_SQL.Open();
            using (SqlCommand comando_sql = new SqlCommand(update, conexao_SQL))
            {
                comando_sql.ExecuteNonQuery();
            }
        }
    }

    public void updateImagem(byte[] imgBytes, string tabela, string condicao)
    {
        string update = "UPDATE " + tabela + " SET imagem_cliente = (@image) WHERE "+condicao;
        using (SqlConnection conexao_SQL = new SqlConnection(acroni.classes.Conexao.nome_conexao))
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
        using (SqlConnection conexao_SQL = new SqlConnection(acroni.classes.Conexao.nome_conexao))
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
        string select = "SELECT " + campos + " FROM " + tabela + " WHERE " + condicao;
        using (SqlConnection conexao_SQL = new SqlConnection(acroni.classes.Conexao.nome_conexao))
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
                    {
                        lista.Add(leitor[i].ToString());
                    }

                    return lista;
                }
            }
        }

    }
}