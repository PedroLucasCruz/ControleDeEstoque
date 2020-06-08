using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ControleEstoque.Models
{
    public class ConexãoBanco
    {
        //ExecuteScalar - Retorna apenas um valor após a execução de uma consulta.
        //Use ExecuteScalar quando quiser um valor apenas (uma linha e uma coluna).

        //ExecuteReader - Retorna um DataReader com os dados da consulta e executa apenas o comando SELECT.
        //ExecuteReader retorna uma tabela de dados lidos selecionados do banco
        public static bool conectarBanco(string comandoExec,byte tipoConsultaBd)
        {

            var conexao = new SqlConnection();
            conexao.ConnectionString = @"Data Source=DESKTOP-5U7PVKK;Initial Catalog=controle_estoque;User Id=Controleestoque;Password=controle55";
            conexao.Open();

            var comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = comandoExec;
           
            switch (tipoConsultaBd) 
            {
                case 1:
                    int valor = (int)comando.ExecuteScalar();
                    break;

                case 2:
                    List<GrupoProdutoModel> ListaRetorno = new List<GrupoProdutoModel>();
                    var ret = comando.ExecuteReader();
                    while (ret.Read())
                    {                     
                        ListaRetorno.Add(new GrupoProdutoModel {
                            
                        Id = (int)ret["Id"],
                        Nome = (String)ret["Nome"],
                        Ativo = (bool)ret["Ativo"]
                        });
                    }
                    break;
                default:
                    break;
            }
        }

    }
}