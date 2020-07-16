using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Interface
{
    interface ICrud<T>
    {
        List<T> Listar(T entidade);
        List<T> GetById(T entidade);
        bool Excluir(T entidade);
        bool Salvar(T entidade);
        bool Alterar(T entidade);
    }
}
