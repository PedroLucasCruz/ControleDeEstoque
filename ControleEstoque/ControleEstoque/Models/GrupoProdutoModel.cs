using ControleEstoque.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ControleEstoque.Models
{
    public  class GrupoProdutoModel : AbstractEntidadeDominio
    {
        
        [Required(ErrorMessage ="Informe um nome válido!" )]
        public String Nome { get; set; }
        public bool Ativo { get; set; }

        //public GrupoProdutoModel(int id, string nome, bool Ativo)
        //{
        //    this.Id = id;
        //    this.Nome = nome;
        //    this.Ativo = Ativo;
        //}

        //public GrupoProdutoModel()
        //{

        //}      
    }
}