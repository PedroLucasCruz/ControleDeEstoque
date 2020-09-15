using ControleEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleEstoque.Business.Base
{
    public class Result<T>
    {
        public T entidade { get; set; }
        
        //public Result<T> entidadeT { get; set; }
        public List<T> entidades { get; set; }
        
        public List<String> mensagens { get; set; }        
        
        public bool callBackBool { get; set; }
        

        //Contrutores
        public Result(List<T> entidadeT)
        {
            this.entidades = entidadeT;
        }

        public Result(List<String> mensagens)
        {
            this.mensagens = mensagens;
        }
         
        public Result(bool b)
        {
            this.callBackBool = b;
        }

        public Result()
        {
         
        }
    }
}