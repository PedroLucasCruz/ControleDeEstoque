using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControleEstoque.Business;
using ControleEstoque.Interface;
using ControleEstoque.Models;
using ControleEstoque.Models.Base;

namespace ControleEstoque.Business.Base
{
    public abstract class AbstractBusiness<T> : ICrud<T> where T : AbstractEntidadeDominio  
    {
        protected DAOabstract<T> dao;
        protected Result<T> result;       
        protected HttpRequestBase request;

       public  AbstractBusiness(HttpRequestBase request, DAOabstract<T> dao, Result<T> result)
        {
            this.dao = dao;
            this.result = result;
            this.request = request;
            //Se precisar implementar o parametro de request
        }

        public virtual Result<T> Alterar(T entidade)
        {
            try
            {
             return dao.Alterar(entidade);
            }
            catch
            {
                result.mensagens.Add("Erro ao Alterar");
            }
            return result;           
        }

        public virtual Result<T> Excluir(T entidade)
        {          
            try
            {
                //result.entidadeT =  dao.Excluir(entidade);
                //return result;      
                return dao.Excluir(entidade);
            }
            catch
            {
                  result.mensagens.Add("");           
            }
            return result;
        }

        public virtual Result<T> GetById(T entidade)
        {

            try
            {
                dao.GetById(entidade);
            }
            catch
            {
                result.mensagens.Add("Erro ao buscar por Id");
            }
            return result;
        }

        public virtual Result<T> Listar()
        {
            try
            {
              return dao.Listar();
            }
            catch(Exception ex)
            {
                result.mensagens.Add(ex.Message);
                result.mensagens.Add("Erro ao retornar todos os registros");
            }
            return result;
            //dao.Listar();
            //throw new NotImplementedException();
        }       

        public virtual Result<T> Salvar(T entidade)
        {

            try
            {
                dao.Salvar(entidade);
            }
            catch
            {
                result.mensagens.Add("Falha");
            }
            return result;
            //throw new NotImplementedException();
        }
    }
}