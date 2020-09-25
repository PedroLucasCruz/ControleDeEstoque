using ControleEstoque.Business.Base;
using ControleEstoque.DAO;
using ControleEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleEstoque.Business
{
    public class GrupoProdutoB : AbstractBusiness<GrupoProdutoModel>
    {
        public GrupoProdutoB(HttpRequestBase request) : base(request, new GrupoProdutoDao(), new Result<GrupoProdutoModel>())
        {
            
        }

        public override Result<GrupoProdutoModel> Alterar(GrupoProdutoModel grupoProdutoModel)
        {
            try
            {
               return base.Alterar(grupoProdutoModel);
            }
            catch
            {
                base.result.mensagens.Add("Erro ao entrar no base de Alterar");
            }
            return result;
        }

        public override Result<GrupoProdutoModel> Salvar(GrupoProdutoModel grupoProdutoModel)
        {

            try
            {
              return  base.Salvar(grupoProdutoModel);
            }
            catch
            {
                base.result.mensagens.Add("Erro ao tentar salvar dados no banco");
            }
            return result;
        }

        public override Result<GrupoProdutoModel> Listar()
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

        public override Result<GrupoProdutoModel> Excluir(GrupoProdutoModel grupoProdutoModel)
        {
            try
            {
                return base.Excluir(grupoProdutoModel);
            }
            catch
            {
                base.result.mensagens.Add("Erro ao excluir item");
                return result;
            }

        }

        public override Result<GrupoProdutoModel> GetById(GrupoProdutoModel grupoProdutoModel)
        {
            try
            {
                return base.GetById(grupoProdutoModel);
            }
            catch
            {
                base.result.mensagens.Add("Erro ao retornar objeto por Id");
                return result;
            }

        }

    }
}