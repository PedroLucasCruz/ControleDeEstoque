﻿using ControleEstoque.Business.Base;
using ControleEstoque.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace ControleEstoque.DAO
{
    public class GrupoProdutoDao : DAOabstract<GrupoProdutoModel>
    {
        
        public override Result<GrupoProdutoModel> Alterar(GrupoProdutoModel entidade)
        {
           if(base.conectar())
            {
                cmd = new SqlCommand("procedure aqui", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("nome_paramentro_da_proceduroAqui",entidade.Id);
                cmd.ExecuteReader();               
            }
            else
            {

            }
            throw new NotImplementedException();
        }

        public override Result<GrupoProdutoModel> Excluir(GrupoProdutoModel entidade)
        {
            throw new NotImplementedException();
        }

        public override Result<GrupoProdutoModel> GetById(GrupoProdutoModel entidade)
        {
            throw new NotImplementedException();
        }

        public override Result<GrupoProdutoModel> Listar()
        {
            List<GrupoProdutoModel> lista = new List<GrupoProdutoModel>();            
            Result<GrupoProdutoModel> resul = new Result<GrupoProdutoModel>(new List<GrupoProdutoModel>());

            cmd = new SqlCommand("tab_grupo_produto", conn);
            cmd.Parameters.AddWithValue("@Int_Ntipo", 1);

            SqlDataReader sqlData = cmd.ExecuteReader();

            if (sqlData.HasRows)
            {
                while (sqlData.Read())
                {

                }
            }

            GrupoProdutoModel grupoProdutoModel = new GrupoProdutoModel();           
            
            grupoProdutoModel.Id = 1;
            grupoProdutoModel.Ativo = true;
            grupoProdutoModel.Nome = "Pera";                   

            resul.entidades.Add();
            
            //resul.mensagens.Add("Teste");            
            //resul.entidadeTT.Add();            
            //= grupoProdutoModel;
            //resul.entidadeTT.Add(grupoProdutoModel);            
            //result.entidades.Add(grupoProdutoModel);           
            //result.entidade = grupoProdutoModel;
            //Console.WriteLine(result);
            //Console.ReadKey();
            return resul;            
        }

        public override Result<GrupoProdutoModel> Salvar(GrupoProdutoModel entidade)
        {
            throw new NotImplementedException();
        }
    }
}