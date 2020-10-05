using ControleEstoque.Business.Base;
using ControleEstoque.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ControleEstoque.DAO
{
    public class UsuarioDao : DAOabstract<UsuariosModel>
    { 
        public override Result<UsuariosModel> Alterar(UsuariosModel entidade)
        {
            Result<UsuariosModel> result = new Result<UsuariosModel>(new List<UsuariosModel>());
            try
            {   
                base.conectar();

                if (VerificarConexao())
                {   
                    cmd = new SqlCommand("PROCEDURE_USUARIO ALTERACAO", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", entidade.Id);
                    cmd.Parameters.AddWithValue("@Nome", entidade.Nome);
                    cmd.Parameters.AddWithValue("@SobreNome", entidade.SobreNome);
                    cmd.Parameters.AddWithValue("@Email", entidade.Email);
                    cmd.Parameters.AddWithValue("@Telefone", entidade.Telefone);
                    cmd.Parameters.AddWithValue("@Celular", entidade.Celular);
                    cmd.Parameters.AddWithValue("@Cpf", entidade.Cpf);
                    cmd.Parameters.AddWithValue("@Rg", entidade.Rg);
                    cmd.Parameters.AddWithValue("@DataNascimento", entidade.DataNascimento);
                    cmd.Parameters.AddWithValue("@IdEndereco", entidade.IdEndereco);

                    SqlDataReader sqlData = cmd.ExecuteReader();

                    if (sqlData.HasRows)
                    {
                        while (sqlData.Read())
                        {
                            UsuariosModel usuariosModel = new UsuariosModel();

                            usuariosModel.Id = int.Parse(sqlData[0].ToString());
                            usuariosModel.IdEndereco = int.Parse(sqlData[1].ToString());
                            usuariosModel.Nome = sqlData[2].ToString();
                            usuariosModel.SobreNome = sqlData[3].ToString();
                            usuariosModel.Email = sqlData[4].ToString();
                            usuariosModel.Telefone = sqlData[5].ToString();
                            usuariosModel.Celular = sqlData[6].ToString();
                            usuariosModel.Cnpj = sqlData[7].ToString();
                            usuariosModel.Cpf = sqlData[8].ToString();
                            usuariosModel.Rg = sqlData[9].ToString();
                            usuariosModel.DataNascimento = DateTime.Parse(sqlData[10].ToString());

                            result.entidades.Add(usuariosModel);
                        }
                    }
                }
                else
                {
                    result.mensagens.Add("banco não conectado");
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

        public override Result<UsuariosModel> Excluir(UsuariosModel entidade)
        {
            Result<UsuariosModel> result = new Result<UsuariosModel>(new List<UsuariosModel>());

            base.conectar();
            if (VerificarConexao())
            {

                cmd = new SqlCommand("PROCEDURE_USUARIO EXCLUSAO", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", entidade.Id);
                SqlDataReader sqlData = cmd.ExecuteReader();
                //  result.callBackBool = cmd.ExecuteNonQuery() > 0 ? true : false;

                if (sqlData.HasRows)
                {
                    while (sqlData.Read())
                    {
                        UsuariosModel usuariosModel = new UsuariosModel();

                        usuariosModel.Id = int.Parse(sqlData[0].ToString());
                        usuariosModel.IdEndereco = int.Parse(sqlData[1].ToString());
                        usuariosModel.Nome = sqlData[2].ToString();
                        usuariosModel.SobreNome = sqlData[3].ToString();
                        usuariosModel.Email = sqlData[4].ToString();
                        usuariosModel.Telefone = sqlData[5].ToString();
                        usuariosModel.Celular = sqlData[6].ToString();
                        usuariosModel.Cnpj = sqlData[7].ToString();
                        usuariosModel.Cpf = sqlData[8].ToString();
                        usuariosModel.Rg = sqlData[9].ToString();
                        usuariosModel.DataNascimento = DateTime.Parse(sqlData[10].ToString());

                        result.entidades.Add(usuariosModel);
                    }
                }
            }
            return result;
        }

        public override Result<UsuariosModel> GetById(UsuariosModel entidade)
        {
            Result<UsuariosModel> result = new Result<UsuariosModel>(new List<UsuariosModel>());
            try
            {
                base.conectar();
                
                if (VerificarConexao())
                {
                    cmd = new SqlCommand("PROCEDURE_USUARIO PEGAR POR ID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", entidade.Id);

                    SqlDataReader sqlData = cmd.ExecuteReader();

                    if (sqlData.HasRows)
                    {
                        while (sqlData.Read())
                        {
                            UsuariosModel usuariosModel = new UsuariosModel();

                            usuariosModel.Id = int.Parse(sqlData[0].ToString());
                            usuariosModel.IdEndereco = int.Parse(sqlData[1].ToString());
                            usuariosModel.Nome = sqlData[2].ToString();
                            usuariosModel.SobreNome = sqlData[3].ToString();
                            usuariosModel.Email = sqlData[4].ToString();
                            usuariosModel.Telefone = sqlData[5].ToString();
                            usuariosModel.Celular = sqlData[6].ToString();
                            usuariosModel.Cnpj = sqlData[7].ToString();
                            usuariosModel.Cpf = sqlData[8].ToString();
                            usuariosModel.Rg = sqlData[9].ToString();
                            usuariosModel.DataNascimento = DateTime.Parse(sqlData[10].ToString());
                         
                            result.entidades.Add(usuariosModel);
                            //PropertyInfo info = grupoProdutoModel.GetType().GetProperty("Nome");
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

        public override Result<UsuariosModel> Listar()
        {   
            Result<UsuariosModel> result = new Result<UsuariosModel>(new List<UsuariosModel>());
            
            try
            {
                base.conectar();
                if (VerificarConexao())
                {
                    cmd = new SqlCommand("STP_Usuario_Todos", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlData = cmd.ExecuteReader();

                    if (sqlData.HasRows)
                    {
                        while (sqlData.Read())
                        {
                            UsuariosModel usuariosModel = new UsuariosModel();

                            usuariosModel.Id = int.Parse(sqlData[0].ToString());
                            usuariosModel.IdEndereco = int.Parse(sqlData[1].ToString());
                            usuariosModel.Nome = sqlData[2].ToString();
                            usuariosModel.SobreNome = sqlData[3].ToString();
                            usuariosModel.Email = sqlData[4].ToString();
                            usuariosModel.Telefone = sqlData[5].ToString();
                            usuariosModel.Celular = sqlData[6].ToString();
                            usuariosModel.Cnpj = sqlData[7].ToString();
                            usuariosModel.Cpf = sqlData[8].ToString();
                            usuariosModel.Rg = sqlData[9].ToString();
                            usuariosModel.DataNascimento = DateTime.Parse(sqlData[10].ToString());
                            var teste = (String.Format("{0:d/M/yyyy HH:mm:ss}", sqlData[10].ToString()));
                            result.entidades.Add(usuariosModel);
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

        public override Result<UsuariosModel> Salvar(UsuariosModel entidade)
        {
            Result<UsuariosModel> result = new Result<UsuariosModel>(new List<UsuariosModel>());

            base.conectar();
            try
            {
                if (VerificarConexao())
                {
                    cmd = new SqlCommand("STP_GrupoProduto_Salvar", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", entidade.Id);
                    cmd.Parameters.AddWithValue("@Nome", entidade.Nome);
                    cmd.Parameters.AddWithValue("@SobreNome", entidade.SobreNome);
                    cmd.Parameters.AddWithValue("@Email", entidade.Email);
                    cmd.Parameters.AddWithValue("@Telefone", entidade.Telefone);
                    cmd.Parameters.AddWithValue("@Celular", entidade.Celular);
                    cmd.Parameters.AddWithValue("@Cpf", entidade.Cpf);
                    cmd.Parameters.AddWithValue("@Rg", entidade.Rg);
                    cmd.Parameters.AddWithValue("@DataNascimento", entidade.DataNascimento);
                    cmd.Parameters.AddWithValue("@IdEndereco", entidade.IdEndereco);

                    // result.callBackBool = cmd.ExecuteNonQuery() > 0 ? true : false;
                    SqlDataReader sqlData = cmd.ExecuteReader();

                    if (sqlData.HasRows)
                    {
                        while (sqlData.Read())
                        {
                            UsuariosModel usuariosModel = new UsuariosModel();

                            usuariosModel.Id = int.Parse(sqlData[0].ToString());
                            usuariosModel.IdEndereco = int.Parse(sqlData[1].ToString());
                            usuariosModel.Nome = sqlData[2].ToString();
                            usuariosModel.SobreNome = sqlData[3].ToString();
                            usuariosModel.Email = sqlData[4].ToString();
                            usuariosModel.Telefone = sqlData[5].ToString();
                            usuariosModel.Celular = sqlData[6].ToString();
                            usuariosModel.Cnpj = sqlData[7].ToString();
                            usuariosModel.Cpf = sqlData[8].ToString();
                            usuariosModel.Rg = sqlData[9].ToString();
                            usuariosModel.DataNascimento = DateTime.Parse(sqlData[10].ToString());

                            result.entidades.Add(usuariosModel);
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
            return result;
        }
    }
}