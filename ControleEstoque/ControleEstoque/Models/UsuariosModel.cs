using ControleEstoque.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleEstoque.Models
{
    public class UsuariosModel : AbstractEntidadeDominio
    {
        public String Nome { get; set; }
        public String SobreNome { get; set; }
        public String Email { get; set; }
        public String Telefone { get; set; }
        public String Celular { get; set; }
        public String Cnpj { get; set; }
        public String Cpf { get; set; }
        public String Rg { get; set; }
        public DateTime DataNascimento { get; set; }
        public int ? IdEndereco  {get; set;}
    }
}