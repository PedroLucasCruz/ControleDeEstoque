using ControleEstoque.Business.Base;
using ControleEstoque.Models;
using Newtonsoft.Json.Converters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Web;

namespace ControleEstoque.DAO
{
    public class GrupoProdutoDao : DAOabstract<GrupoProdutoModel>
    {

        public override Result<GrupoProdutoModel> Alterar(GrupoProdutoModel entidade)
        {
            //if (base.conectar())
            //{
            try
            {
                base.conectar();

                if (VerificarConexao())
                {
                    cmd = new SqlCommand("procedure aqui", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("nome_paramentro_da_proceduroAqui", entidade.Id);
                    cmd.ExecuteReader();
                }
                else
                {
                    result.mensagens.Add("banco não conectado");
                }
            }
            catch (Exception ex)
            {
                result.mensagens.Add("");
            }
            finally
            {
                base.desconectar();
            }

            return result;

            //}
            //else
            //{
            //}
            //throw new NotImplementedException();
        }

        public override Result<GrupoProdutoModel> Excluir(GrupoProdutoModel entidade)
        {
            Result<GrupoProdutoModel> result = new Result<GrupoProdutoModel>(new List<GrupoProdutoModel>());

            base.conectar();
            if (VerificarConexao())
            {
            
                cmd = new SqlCommand("STP_GrupoProduto_DeletarPorId", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", entidade.Id);
                SqlDataReader sqlData = cmd.ExecuteReader();
                //  result.callBackBool = cmd.ExecuteNonQuery() > 0 ? true : false;

                if (sqlData.HasRows)
                {
                    while (sqlData.Read())
                    {
                        GrupoProdutoModel grupoProdutoModel = new GrupoProdutoModel();

                        grupoProdutoModel.Id = int.Parse(sqlData[0].ToString());
                        grupoProdutoModel.Nome = sqlData[1].ToString();
                        grupoProdutoModel.Ativo =  (bool)sqlData[2];

                        result.entidades.Add(grupoProdutoModel);
                    }
                }    

            }
            return result;
        }

        public override Result<GrupoProdutoModel> GetById(GrupoProdutoModel entidade)
        {


            Result<GrupoProdutoModel> result = new Result<GrupoProdutoModel>(new List<GrupoProdutoModel>());
            try
            {

                base.conectar();
                if (VerificarConexao())
                {
                    cmd = new SqlCommand("STP_GrupoProduto_GetById", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", entidade.Id);

                    SqlDataReader sqlData = cmd.ExecuteReader();

                    if (sqlData.HasRows)
                    {
                        while (sqlData.Read())
                        {
                            GrupoProdutoModel grupoProdutoModel = new GrupoProdutoModel();

                            grupoProdutoModel.Id = int.Parse(sqlData[0].ToString());
                            grupoProdutoModel.Nome = sqlData[1].ToString();
                            grupoProdutoModel.Ativo = (bool)sqlData[2];

                            result.entidades.Add(grupoProdutoModel);
                            PropertyInfo info = grupoProdutoModel.GetType().GetProperty("Nome");
                        }
                    }
                }
                else
                {
                    result.mensagens.Add("Banco de dados não conectado");
                }
            }
            catch (Exception ex)
            {
                result.mensagens.Add(ex.Message);
            }
            finally
            {
                base.desconectar();
            }
            return result;

        }

        public override Result<GrupoProdutoModel> Listar()
        {

            Result<GrupoProdutoModel> result = new Result<GrupoProdutoModel>(new List<GrupoProdutoModel>());

            try
            {
                base.conectar();
                if (VerificarConexao())
                {
                    cmd = new SqlCommand("STP_GrupoProduto_Todos", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlData = cmd.ExecuteReader();

                    if (sqlData.HasRows)
                    {
                        while (sqlData.Read())
                        {
                            GrupoProdutoModel grupoProdutoModel = new GrupoProdutoModel();

                            grupoProdutoModel.Id = int.Parse(sqlData[0].ToString());
                            grupoProdutoModel.Nome = sqlData[1].ToString();
                            grupoProdutoModel.Ativo = Boolean.Parse(sqlData[2].ToString());

                            result.entidades.Add(grupoProdutoModel);
                        }
                    }
                }
                else
                {
                    result.mensagens.Add("Banco de dados não conectado");
                }
            }
            catch (Exception ex)
            {
                result.mensagens.Add(ex.Message);
            }
            finally
            {
                base.desconectar();
            }
            return result;
        }
        public override Result<GrupoProdutoModel> Salvar(GrupoProdutoModel entidade)
        {
            throw new NotImplementedException();
        }
    }
}