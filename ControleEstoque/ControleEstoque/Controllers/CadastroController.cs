using ControleEstoque.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
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
        //A lista em memoria deve estár statica para ser enxergadas por todas a aplicação
        //Caso contrario qualquer execução que tenha a lista como envolvida terá que estanciar a lista
        //novamente, sendo assim, os objetos da lista serão incluidos novamente dentro da lista.
        public static List<GrupoProdutoModel> ListaGrupoProduto = new List<GrupoProdutoModel>()
        {
            new GrupoProdutoModel(){Id=1,Nome = "Pera", Ativo = true },
            new GrupoProdutoModel(){Id=2,Nome = "Melão", Ativo = false },
            new GrupoProdutoModel(){Id=3,Nome = "Abacaxi", Ativo = true }
        };

        [Authorize]
        public ActionResult GrupoProduto()
        {
            return View(ListaGrupoProduto);
        }

        [HttpPost]
        [Authorize]
        public ActionResult RecuperarGrupoProduto(int id)
        {
            return Json(ListaGrupoProduto.Find(x => x.Id == id));
        }


        [HttpPost]
        [Authorize]
        public ActionResult ExcluirGrupoProduto(int id)
        {
            //var resposta = false;

            //Nesta linha de execução é passado pelo cliente(frontEnd) um Id como parametro
            //Esse Id é usado como parametro para varrer a lista e então o metodo find retorna
            //O item que foi encontrado dentro dessa lista
            //Essa item passado como parametro pode ser ou não ser encotrado em uma busca
            //Tendo em vista então que apos a busca o metodo find retornar de dentro da lista o
            //O objeto encontrado, podendo este objeto ter mais de um atributo
            //Apo esse retorno do valor, o objeto é gravado em uma variavel tipada e validado mais a baixo
            var Item = ListaGrupoProduto.Find(x => x.Id == id);
            //Validação para identificar se contem itens retornados            
            if (Item != null)
            {
                //Esse metodo remove o objeto encontrado de dentro da lista
                ListaGrupoProduto.Remove(Item);
                //resposta = true;
            }
            return Json(true);
        }

        public ActionResult SalvarGrupoProduto(GrupoProdutoModel model)
        {
            //Nessa primeira linha é verificado se o registro já existe dentro da 
            //base de dados, pois foi pesquisado dentro da lista pelo seu identificador(Id)
            var localizado = ListaGrupoProduto.Find(x => x.Id == model.Id);
                         
            //Apos ser feita a busca do registro no banco, é verificado se o registro existe ou nao
            //caso não existe é incluido um novo registro no banco de dados
            //Caso o registro exista, é retornado o registro existente sem mudanças
            if (localizado == null)
            {
                // Com este metodo abaixo é atribuito a variavel tipada os dados de model passada como parametro
                // Em seguida os é adicionado o Id de incremento a mesma.
                //localizado = model;
                //localizado.Id = ListaGrupoProduto.Max(x => x.Id) + 1;
                //ListaGrupoProduto.Add(localizado);

                //return Json(localizado);

                ////Estancia o objeto 
                GrupoProdutoModel novoRegistro = new GrupoProdutoModel();

                //Preenche os campos do objeto
                novoRegistro.Id = ListaGrupoProduto.Max(x => x.Id) + 1;
                novoRegistro.Nome = model.Nome;
                novoRegistro.Ativo = model.Ativo;

                //Inclui o objeto no banco de dados
                ListaGrupoProduto.Add(novoRegistro);
                return Json(novoRegistro);
            }
            else
            {
            //    localizado.Nome = model.Nome;
            //    localizado.Ativo = model.Ativo;
                return Json(localizado);                 
            }
            var ret = Json(localizado);
            return ret;
            // return Json(ListaGrupoProduto);
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