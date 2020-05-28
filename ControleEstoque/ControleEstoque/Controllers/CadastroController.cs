using ControleEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleEstoque.Controllers
{
    public class CadastroController : Controller
    {
        #region
        //Este é um outro modelo de implementação de lista
        //Neste modelo é usado um metodo 
        //Primeiro é feito a estancia da lista 
        //O que está entre <> logo apos o nome "List" é o tipo de modelo da classe que será usado
        //Logo apos estanciar a lista é estancia o objeto dentro da lista e adicionando este objeto com .Add
        public List<GrupoProdutoModel> ListaProduto()
        {
            List<GrupoProdutoModel> lista = new List<GrupoProdutoModel>();
            lista.Add(new GrupoProdutoModel(1, "pera", true));
            return lista;
        }
        #endregion

        #region
        //Essa sintaxe consiste e estancia uma lista e estanciar os objetos e jogar dentro da lista
        //A primeira linha estancia a lista que é do tipo flexivel
        //Abaixo é considero estancia do objeto ao usar new 
        //Para separar cada objeto é utilizado virgula
        //para adicionar os objetos basta que eles estejam dentro das chaves da lista
        //no final das chaves da lista é importante colocar o ponto e virgula para que compile de acordo com a sintaxe
        #endregion
        public List<GrupoProdutoModel> ListaGrupoProduto = new List<GrupoProdutoModel>()
        {
            new GrupoProdutoModel(){Id=1,Nome = "Pera", Ativo = true },
            new GrupoProdutoModel(){Id=2,Nome = "Melão", Ativo = true },
            new GrupoProdutoModel(){Id=3,Nome = "Abacaxi", Ativo = true }
        };

        [Authorize]
        public ActionResult GrupoProduto()
        {
            return View(ListaGrupoProduto);
        }

        [Authorize]
        public ActionResult MarcaProduto()
        {
            return View();
        }

        [Authorize]
        public ActionResult LocalProduto()
        {
            return View();
        }

        [Authorize]
        public ActionResult UnidadeMedida()
        {
            return View();
        }

        [Authorize]
        public ActionResult Produto()
        {
            return View();
        }

        [Authorize]
        public ActionResult Pais()
        {
            return View();
        }

        [Authorize]
        public ActionResult Estado()
        {
            return View();
        }

        [Authorize]
        public ActionResult Cidade()
        {
            return View();
        }

        [Authorize]
        public ActionResult Fornecedor()
        {
            return View();
        }

        [Authorize]
        public ActionResult PerfilUsuario()
        {
            return View();
        }

        [Authorize]
        public ActionResult Usuario()
        {
            return View();
        }


    }
}