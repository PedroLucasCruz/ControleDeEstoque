using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleEstoque.Models
{
    public class LoginViewModel
    {
        
        [Required(ErrorMessage ="Informe um usuário válido")] //Definido que o campo não pode ficarm em branco se não mostra a msg
        [Display(Name = "Usuario: ")] //Aqui você definiu o nome do campo que será exibiado em tela "Usuario"
        public String Usuario { get; set; }

        [Required(ErrorMessage = "Informe uma senha válida")]  //Definido que o campo não pode ficarm em branco se não mostra a msg       
        [DataType(DataType.Password)] //aqui você definiu o tipo de dados para o campo senha
        [Display(Name = "Senha: ")]  //Aqui você definiu o nome do campo que será exibiado em tela "Senha"
        public String Senha { get; set; }

        [Display(Name = "Lembrar me: ")]
        public bool LembrarMe { get; set; }
    }
}