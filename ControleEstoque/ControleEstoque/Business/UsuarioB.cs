using ControleEstoque.Business.Base;
using ControleEstoque.DAO;
using ControleEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleEstoque.Business
{
    public class UsuarioB : AbstractBusiness<UsuariosModel>
    {

        public UsuarioB(HttpRequestBase request) : base(request, new UsuarioDao(), new Result<UsuariosModel>())
        {
            
        }

        public override Result<UsuariosModel> Alterar(UsuariosModel usuariosModel)
        {
            try
            {
                return base.Alterar(usuariosModel);
            }
            catch
            {
                base.result.mensagens.Add("Erro ao entrar no base de Alterar");
            }
            return result;
        }


        public override Result<UsuariosModel> Salvar(UsuariosModel usuariosModel)
        {
            try
            {
                return base.Salvar(usuariosModel);
            }
            catch
            {
                base.result.mensagens.Add("Erro ao tentar salvar dados no banco");
            }
            return result;
        }


        public override Result<UsuariosModel> Listar()
        {
            try
            {
                return base.Listar();
            }
            catch
            {
                base.result.mensagens.Add("Erro ao listar");
            }
            return result;
        }


        public override Result<UsuariosModel> Excluir(UsuariosModel usuariosModel)
        {
            try
            {
                return base.Excluir(usuariosModel);
            }
            catch
            {
                base.result.mensagens.Add("Erro ao excluir item");
                return result;
            }
        }

        public override Result<UsuariosModel> GetById(UsuariosModel usuariosModel)
        {
            try
            {
                return base.GetById(usuariosModel);
            }
            catch
            {
                base.result.mensagens.Add("Erro ao retornar objeto por Id");
                return result;
            }
        }


    }
}