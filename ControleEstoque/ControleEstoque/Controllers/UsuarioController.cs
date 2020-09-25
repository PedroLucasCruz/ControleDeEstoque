using ControleEstoque.Business;
using ControleEstoque.Business.Base;
using ControleEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleEstoque.Controllers
{
    public class UsuarioController : Controller 
    {
        // GET: Usuario
        public ActionResult Usuario()
        {
            return View();
        }

        public ActionResult UsuariosListar(UsuariosModel usuariosModel)
        {   
            var callback = new Result<UsuariosModel>();
            
                callback.entidades =  new UsuarioB(HttpContext.Request).Listar()?.entidades;
           
            return Json(new { Obj = callback.entidades, Mensagens = callback.mensagens });
        }

        public ActionResult UsuariosAlterar(UsuariosModel usuariosModel)
        {           
            var callback = new Result<UsuariosModel>();

            if (!ModelState.IsValid)
            {
                callback.mensagens = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                callback.entidades = new UsuarioB(HttpContext.Request).Alterar(usuariosModel)?.entidades;
            }
            return Json(new { Obj = callback.entidades, Mensagens = callback.mensagens });
        }

        public ActionResult UsuarioSalvar(UsuariosModel usuarioModel)
        {         

            var callback = new Result<UsuariosModel>();

            if (!ModelState.IsValid)
            {
                callback.mensagens = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                callback.entidades = new UsuarioB(HttpContext.Request).Salvar(usuarioModel)?.entidades;
            }
            return Json(new { Obj = callback.entidades, Mensagens = callback.mensagens });
        }

        public ActionResult UsuarioGetById(UsuariosModel usuariosModel)
        {
            var callback = new Result<UsuariosModel>();                  
            
                callback.entidades = new UsuarioB(HttpContext.Request).GetById(usuariosModel)?.entidades;
            
            return Json(new { Obj = callback.entidades, Mensagens = callback.mensagens });
        }

    }
}