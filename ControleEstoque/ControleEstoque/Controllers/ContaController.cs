using ControleEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ControleEstoque.Controllers
{
    public class ContaController : Controller
    {
        //Anotação dentro Sobre AllowAnonymous
        #region
        //Esse metodo de Login deve estar publico para que qualquer um consiga acessar
        //Para tornar ele acessivel a qualquer um, decore o metodo com o [AllowAnonymous]
        //Todos os outro metodos dentro dos outros Controllers devem estar privados, pois, ele só 
        //Serão vistos se você acessar com o login, para deixar privado use a 
        //anotação(decoração semelhante a AllowAnonymous mas escrito de outra forma )
        //Anotação para deixar os metodos privados caso você não tenh feito login ainda: Authorize

        //IMPORTANTE: você precisa configurar a sua aplicação para trabalhar com form authentication
        //Abra o arqui do webConfig e faça a configuração lá
        //Inclua duas sessões, Authorization e Autentication

        //<!---Você passa a url de login por parametro(~/Conta/Login) e da o nome da autenticação---->
        //Abaixo as linhas de código para inclusão no WebConfig
        //<Authentication mode = "Forms" >
        //  < forms loginsUrl="~/Conta/Login" name=".controlestoque"></forms>
        //</Authentication>
        //<!---na linha abaixo ele nega para todos que não são autorizados---->
        //<Authorization>
        //  <deny users = "?" />
        //</ Authorization >

        #endregion
        [AllowAnonymous]
        //Anotação sobre Metodo Login
        #region
        //Este tipo de configuração com parametro de retorno na chamada Get diz o seguinte
        //Quando o usuário tentar acessar uma url privada ela será passado nesse parametro dentro do
        //metodo de login e ao ser redirecionado para a tela de login e quando o usuario se logar o sistema
        //vai voltar pra Url que ele tentou acessar      
        #endregion
        public ActionResult Login(String ReturnUrl)
        {
            ViewBag.Returnurl = ReturnUrl;
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(LoginViewModel login, String returnUrl) 
        {
            //Validar os dados que o usuário digitou para saber se está correto
            if (!ModelState.IsValid)
            {
                //Essa string de retorno é a view de login
                //Se ainda estiver invalido é exibido novamente a pagina de login
                return View(login);
            }

            //Nessa validação abaixo é posto uma condicional para saber se o usuario
            //Foi encontrado na base de dados ficticia
            //Variavel tipada de acordo com o retorno
            // var achou = (login.Usuario == "Pedro" && login.Senha == "123");
            var achou = UsuarioModel.ValidarUsuario(login.Usuario, login.Senha);

            if (achou)
            {
                //Caso o usuário seja valido seta os parametro dentro da 
                //sessão de cookies do authentication
                FormsAuthentication.SetAuthCookie(login.Usuario, login.LembrarMe);

                //Nesse trecho você valida se a URL passado como parametro está 
                //dentro do dominio da aplicação
                //Caso não esteja dentro do dominio redireciona pra home
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    //RedirectToAction redireciona o fluxo para o action Index dentro do controller Home
                    RedirectToAction("Index", "Home");
                }
            }
            //Este Else mostra uma mensagem de validação caso os dados de credenciais
            //Sejam digitados de forma errada
            else
            {
                ModelState.AddModelError("", "Login inválido.");
            }
            return View(login);       
        }

        //Esse metodos de Logout tem que ser AllowAnonymous para ser visto por todos os modos na aplicação
        
        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }

    }
}