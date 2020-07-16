using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControleEstoque.Business;
using ControleEstoque.Interface;

namespace ControleEstoque.Business.Base
{
    public abstract class AbstractBusiness<T> : ICrud<T>   
    {
        public bool Alterar(T entidade)
        {
            throw new NotImplementedException();
        }

        public bool Excluir(T entidade)
        {
            throw new NotImplementedException();
        }

        public List<T> GetById(T entidade)
        {
            throw new NotImplementedException();
        }

        public List<T> Listar(T entidade)
        {
            throw new NotImplementedException();
        }

        public bool Salvar(T entidade)
        {
            throw new NotImplementedException();
        }
    }
}