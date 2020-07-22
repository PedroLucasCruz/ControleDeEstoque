using ControleEstoque.Business.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Interface
{
    interface ICrud<T>
    {
        Result<T> Listar();
        Result<T> GetById(T entidade);
        Result<T> Excluir(T entidade);
        Result<T> Salvar(T entidade);
        Result<T> Alterar(T entidade);       
    }
}
